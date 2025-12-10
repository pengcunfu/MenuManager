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
                var keyPath = GetRegistryKeyPath(config);
                var commandKeyPath = $"{keyPath}\\command";

                // 创建主菜单项
                using (var key = Registry.ClassesRoot.CreateSubKey(keyPath))
                {
                    key.SetValue("", config.Name);
                    key.SetValue("Icon", $"\"{config.Path}\"");
                }

                // 创建命令子键
                using (var commandKey = Registry.ClassesRoot.CreateSubKey(commandKeyPath))
                {
                    var commandValue = config.ForFiles 
                        ? $"\"{config.Path}\" \"%1\""
                        : $"\"{config.Path}\" \"%V\"";
                    commandKey.SetValue("", commandValue);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"添加菜单失败: {ex.Message}", ex);
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
                var keyPath = GetRegistryKeyPath(config);
                Registry.ClassesRoot.DeleteSubKeyTree(keyPath, false);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"删除菜单失败: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// 更新菜单状态（启用或禁用）
        /// </summary>
        public void UpdateMenuStatus(MenuConfig config, bool enabled)
        {
            if (enabled == config.Enabled)
                return; // 状态未改变

            if (enabled)
            {
                AddMenu(config);
            }
            else
            {
                RemoveMenu(config);
            }

            config.Enabled = enabled;
        }

        /// <summary>
        /// 刷新配置中的菜单状态
        /// </summary>
        public List<MenuConfig> RefreshMenuStatus(List<MenuConfig> configs)
        {
            foreach (var config in configs)
            {
                config.Enabled = IsMenuEnabled(config);
            }
            return configs;
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
