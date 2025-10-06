using System.Diagnostics;
using System.Security.Principal;
using Microsoft.Win32;

namespace OpenAsMenu.Services
{
    /// <summary>
    /// Win11右键菜单管理器
    /// 用于切换Win11的右键菜单样式（一级菜单 vs 完整二级菜单）
    /// </summary>
    public class Win11ContextMenuManager
    {
        // Win11右键菜单控制的注册表键
        private const string WIN11_CONTEXT_MENU_KEY = @"Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\InprocServer32";
        
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
        /// 检查当前系统是否为Windows 11
        /// </summary>
        public bool IsWindows11()
        {
            try
            {
                var version = Environment.OSVersion.Version;
                // Windows 11 的版本号是 10.0.22000 或更高
                return version.Major == 10 && version.Build >= 22000;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 检查Win11一级菜单是否已禁用（即是否显示完整的二级菜单）
        /// </summary>
        public bool IsWin11MenuDisabled()
        {
            try
            {
                using var key = Registry.CurrentUser.OpenSubKey(WIN11_CONTEXT_MENU_KEY);
                return key != null;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 禁用Win11一级菜单（显示完整二级菜单，类似Win10样式）
        /// </summary>
        public void DisableWin11Menu()
        {
            if (!IsAdmin())
                throw new UnauthorizedAccessException("需要管理员权限才能修改注册表");

            if (!IsWindows11())
                throw new InvalidOperationException("此功能仅支持Windows 11系统");

            try
            {
                using var key = Registry.CurrentUser.CreateSubKey(WIN11_CONTEXT_MENU_KEY);
                key.SetValue("", "", RegistryValueKind.String);
                
                RestartExplorer();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"禁用Win11菜单失败: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// 恢复Win11默认菜单（启用一级菜单）
        /// </summary>
        public void EnableWin11Menu()
        {
            if (!IsAdmin())
                throw new UnauthorizedAccessException("需要管理员权限才能修改注册表");

            if (!IsWindows11())
                throw new InvalidOperationException("此功能仅支持Windows 11系统");

            try
            {
                Registry.CurrentUser.DeleteSubKeyTree(@"Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}", false);
                
                RestartExplorer();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"恢复Win11菜单失败: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// 获取当前菜单状态描述
        /// </summary>
        public string GetMenuStatusDescription()
        {
            if (!IsWindows11())
                return "当前系统不是Windows 11";

            if (IsWin11MenuDisabled())
                return "Win11一级菜单已禁用（显示完整二级菜单，Win10样式）";
            else
                return "Win11默认菜单已启用（显示一级菜单）";
        }

        /// <summary>
        /// 重启资源管理器以应用更改
        /// </summary>
        private void RestartExplorer()
        {
            try
            {
                // 结束explorer.exe进程
                var explorerProcesses = Process.GetProcessesByName("explorer");
                foreach (var process in explorerProcesses)
                {
                    process.Kill();
                    process.WaitForExit(5000); // 等待最多5秒
                }

                // 启动新的explorer.exe
                Process.Start("explorer.exe");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"重启资源管理器失败: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// 验证系统兼容性
        /// </summary>
        public (bool IsCompatible, string Message) ValidateSystemCompatibility()
        {
            if (!IsWindows11())
            {
                return (false, "此功能仅支持Windows 11系统");
            }

            if (!IsAdmin())
            {
                return (false, "需要管理员权限才能修改右键菜单设置");
            }

            return (true, "系统兼容，可以使用Win11右键菜单切换功能");
        }

        /// <summary>
        /// 测试注册表访问权限
        /// </summary>
        public bool TestRegistryAccess()
        {
            try
            {
                const string testKeyPath = @"Software\Classes\CLSID\__test_win11_access__";
                
                // 尝试创建测试键
                using (var testKey = Registry.CurrentUser.CreateSubKey(testKeyPath))
                {
                    testKey.SetValue("test", "test");
                }

                // 删除测试键
                Registry.CurrentUser.DeleteSubKeyTree(testKeyPath, false);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
