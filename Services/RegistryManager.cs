using System.Diagnostics;
using System.Security.Principal;
using Microsoft.Win32;
using MenuManager.Models;

namespace MenuManager.Services
{
    /// <summary>
    /// 注册表管理器
    /// </summary>
    public class RegistryManager
    {
        /// <summary>
        /// 检查是否以管理员权限运行
        /// </summary>
        public bool IsAdmin()
        {
            try
            {
                using var identity = WindowsIdentity.GetCurrent();
                var principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 以管理员权限重新启动程序
        /// </summary>
        public bool RelaunchAsAdmin()
        {
            try
            {
                var executable = Process.GetCurrentProcess().MainModule?.FileName;
                if (string.IsNullOrEmpty(executable))
                    return false;

                var processInfo = new ProcessStartInfo
                {
                    FileName = executable,
                    UseShellExecute = true,
                    Verb = "runas"
                };

                Process.Start(processInfo);
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"重新启动失败: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// 检查菜单是否已启用
        /// </summary>
        public bool IsMenuEnabled(MenuConfig config)
        {
            try
            {
                var keyPath = GetRegistryKeyPath(config);
                using var key = Registry.ClassesRoot.OpenSubKey(keyPath);
                return key != null;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 添加右键菜单
        /// </summary>
        public void AddMenu(MenuConfig config)
        {
            if (!IsAdmin())
                throw new UnauthorizedAccessException("需要管理员权限才能修改注册表");

            try
            {
                // 根据配置添加对应范围的菜单
                if (config.ForFiles)
                {
                    AddMenuForScope(config, true);
                }
                if (config.ForDirectories)
                {
                    AddMenuForScope(config, false);
                }
                if (config.ForDesktop)
                {
                    AddMenuForDesktop(config);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"添加菜单失败: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// 为特定范围添加菜单
        /// </summary>
        private void AddMenuForScope(MenuConfig config, bool forFiles)
        {
            var scope = forFiles ? "*" : "Directory";
            var keyPath = $@"{scope}\shell\{config.Root}";
            var commandKeyPath = $"{keyPath}\\command";
            var commandValue = forFiles
                ? $"\"{config.Path}\" \"%1\""
                : $"\"{config.Path}\" \"%V\"";

            // 创建主菜单项
            using (var key = Registry.ClassesRoot.CreateSubKey(keyPath))
            {
                key.SetValue("", config.Name);
                key.SetValue("Icon", $"\"{config.Path}\"");
            }

            // 创建命令子键
            using (var commandKey = Registry.ClassesRoot.CreateSubKey(commandKeyPath))
            {
                commandKey.SetValue("", commandValue);
            }
        }

        /// <summary>
        /// 为桌面背景添加菜单
        /// </summary>
        private void AddMenuForDesktop(MenuConfig config)
        {
            var keyPath = $@"Directory\Background\shell\{config.Root}";
            var commandKeyPath = $"{keyPath}\\command";
            var commandValue = $"\"{config.Path}\" \"%V\"";

            // 创建主菜单项
            using (var key = Registry.ClassesRoot.CreateSubKey(keyPath))
            {
                key.SetValue("", config.Name);
                key.SetValue("Icon", $"\"{config.Path}\"");
            }

            // 创建命令子键
            using (var commandKey = Registry.ClassesRoot.CreateSubKey(commandKeyPath))
            {
                commandKey.SetValue("", commandValue);
            }
        }

        /// <summary>
        /// 删除右键菜单
        /// </summary>
        public void RemoveMenu(MenuConfig config)
        {
            if (!IsAdmin())
                throw new UnauthorizedAccessException("需要管理员权限才能修改注册表");

            try
            {
                // 根据配置删除对应范围的菜单
                if (config.ForFiles)
                {
                    RemoveMenuForScope(config, true);
                }
                if (config.ForDirectories)
                {
                    RemoveMenuForScope(config, false);
                }
                if (config.ForDesktop)
                {
                    RemoveMenuForDesktop(config);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"删除菜单失败: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// 为特定范围删除菜单
        /// </summary>
        private void RemoveMenuForScope(MenuConfig config, bool forFiles)
        {
            var scope = forFiles ? "*" : "Directory";
            var keyPath = $@"{scope}\shell\{config.Root}";
            Registry.ClassesRoot.DeleteSubKeyTree(keyPath, false);
        }

        /// <summary>
        /// 删除桌面背景菜单
        /// </summary>
        private void RemoveMenuForDesktop(MenuConfig config)
        {
            var keyPath = $@"Directory\Background\shell\{config.Root}";
            Registry.ClassesRoot.DeleteSubKeyTree(keyPath, false);
        }

        /// <summary>
        /// 更新菜单状态（启用或禁用）
        /// </summary>
        public void UpdateMenuStatus(MenuConfig config, bool enabled)
        {
            // UpdateMenuStatus现在只负责添加或删除菜单
            // 不再修改config.ForFiles或config.ForDirectories，因为那是UI层的职责

            if (enabled)
            {
                AddMenu(config);
            }
            else
            {
                RemoveMenu(config);
            }
        }

        /// <summary>
        /// 刷新配置中的菜单状态
        /// </summary>
        public List<MenuConfig> RefreshMenuStatus(List<MenuConfig> configs)
        {
            foreach (var config in configs)
            {
                // 检查注册表中每个范围的实际状态
                bool forFilesEnabled = CheckMenuEnabledForScope(config, true);
                bool forDirectoriesEnabled = CheckMenuEnabledForScope(config, false);
                bool forDesktopEnabled = CheckMenuEnabledForDesktop(config);

                // 同步到配置对象
                config.ForFiles = forFilesEnabled;
                config.ForDirectories = forDirectoriesEnabled;
                config.ForDesktop = forDesktopEnabled;
            }
            return configs;
        }

        /// <summary>
        /// 检查特定范围的菜单是否启用
        /// </summary>
        private bool CheckMenuEnabledForScope(MenuConfig config, bool forFiles)
        {
            try
            {
                var keyPath = forFiles
                    ? $@"*\shell\{config.Root}"
                    : $@"Directory\shell\{config.Root}";
                using var key = Registry.ClassesRoot.OpenSubKey(keyPath);
                return key != null;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 检查桌面菜单是否启用
        /// </summary>
        private bool CheckMenuEnabledForDesktop(MenuConfig config)
        {
            try
            {
                var keyPath = $@"Directory\Background\shell\{config.Root}";
                using var key = Registry.ClassesRoot.OpenSubKey(keyPath);
                return key != null;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 获取注册表键路径
        /// </summary>
        private string GetRegistryKeyPath(MenuConfig config)
        {
            return config.ForFiles 
                ? $@"*\shell\{config.Root}"
                : $@"Directory\shell\{config.Root}";
        }

        /// <summary>
        /// 测试注册表访问权限
        /// </summary>
        public bool TestRegistryAccess()
        {
            try
            {
                const string testKeyPath = @"Directory\shell\__test_access__";
                
                // 尝试创建测试键
                using (var testKey = Registry.ClassesRoot.CreateSubKey(testKeyPath))
                {
                    testKey.SetValue("test", "test");
                }

                // 删除测试键
                Registry.ClassesRoot.DeleteSubKeyTree(testKeyPath, false);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
