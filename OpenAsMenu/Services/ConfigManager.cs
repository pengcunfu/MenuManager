using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using OpenAsMenu.Models;

namespace OpenAsMenu.Services
{
    /// <summary>
    /// 配置管理器
    /// </summary>
    public class ConfigManager
    {
        private readonly string _configPath;
        private List<MenuConfig> _configs = new List<MenuConfig>();

        public ConfigManager()
        {
            var executablePath = Assembly.GetExecutingAssembly().Location;
            var directory = Path.GetDirectoryName(executablePath) ?? AppDomain.CurrentDomain.BaseDirectory;
            _configPath = Path.Combine(directory, "menu_configs.json");
        }

        /// <summary>
        /// 加载配置
        /// </summary>
        public async Task LoadAsync()
        {
            try
            {
                if (!File.Exists(_configPath))
                {
                    CreateDefaultConfigs();
                    await SaveAsync();
                    return;
                }

                var json = await File.ReadAllTextAsync(_configPath);
                var configFile = JsonConvert.DeserializeObject<ConfigFile>(json);
                
                if (configFile?.Configs != null && configFile.Configs.Count > 0)
                {
                    _configs = configFile.Configs;
                }
                else
                {
                    CreateDefaultConfigs();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"加载配置失败: {ex.Message}");
                CreateDefaultConfigs();
            }
        }

        /// <summary>
        /// 保存配置
        /// </summary>
        public async Task SaveAsync()
        {
            try
            {
                var configFile = new ConfigFile { Configs = _configs };
                var json = JsonConvert.SerializeObject(configFile, Formatting.Indented);
                await File.WriteAllTextAsync(_configPath, json);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"保存配置失败: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// 获取所有配置
        /// </summary>
        public List<MenuConfig> GetConfigs() => new List<MenuConfig>(_configs);

        /// <summary>
        /// 根据索引获取配置
        /// </summary>
        public MenuConfig? GetConfig(int index)
        {
            if (index < 0 || index >= _configs.Count)
                return null;
            return _configs[index];
        }

        /// <summary>
        /// 添加新配置
        /// </summary>
        public async Task AddConfigAsync(MenuConfig config)
        {
            config.Root = GenerateUniqueRoot(config.Name);
            _configs.Add(config);
            await SaveAsync();
        }

        /// <summary>
        /// 更新配置
        /// </summary>
        public async Task UpdateConfigAsync(int index, MenuConfig config)
        {
            if (index < 0 || index >= _configs.Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            // 检查根键名是否重复（除了当前配置）
            if (!CheckRootUnique(config.Root, index))
                throw new InvalidOperationException("注册表键名已存在");

            _configs[index] = config;
            await SaveAsync();
        }

        /// <summary>
        /// 删除配置
        /// </summary>
        public async Task RemoveConfigAsync(int index)
        {
            if (index < 0 || index >= _configs.Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            _configs.RemoveAt(index);
            await SaveAsync();
        }

        /// <summary>
        /// 验证文件路径是否存在
        /// </summary>
        public bool ValidatePath(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                return false;
            return File.Exists(path);
        }

        /// <summary>
        /// 验证配置有效性
        /// </summary>
        public void ValidateConfig(MenuConfig config)
        {
            if (string.IsNullOrWhiteSpace(config.Name))
                throw new ArgumentException("显示名称不能为空");

            if (string.IsNullOrWhiteSpace(config.Root))
                throw new ArgumentException("注册表键名不能为空");

            if (string.IsNullOrWhiteSpace(config.Path))
                throw new ArgumentException("程序路径不能为空");
        }

        /// <summary>
        /// 检查根键名是否唯一
        /// </summary>
        public bool CheckRootUnique(string root, int excludeIndex = -1)
        {
            for (int i = 0; i < _configs.Count; i++)
            {
                if (i != excludeIndex && _configs[i].Root == root)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 生成唯一的根键名
        /// </summary>
        private string GenerateUniqueRoot(string name)
        {
            var baseRoot = name.ToLower().Replace(" ", "").Replace("-", "").Replace("_", "");
            var root = baseRoot;
            var counter = 1;

            while (!CheckRootUnique(root))
            {
                root = $"{baseRoot}{counter}";
                counter++;
            }

            return root;
        }

        /// <summary>
        /// 创建默认配置
        /// </summary>
        private void CreateDefaultConfigs()
        {
            _configs = new List<MenuConfig>
            {
                new MenuConfig { Name = "VSCode", Root = "vscode", Path = @"C:\Program Files\Microsoft VS Code\Code.exe", ForFiles = false, Enabled = false },
                new MenuConfig { Name = "PyCharm", Root = "pycharm", Path = @"D:\App\IDE\JetBrains\PyCharm 2023.3.1\bin\pycharm64.exe", ForFiles = false, Enabled = false },
                new MenuConfig { Name = "IDEA", Root = "idea64", Path = @"D:\App\Dev\JetBrains\IntelliJ IDEA 2023.3.1\bin\idea64.exe", ForFiles = false, Enabled = false },
                new MenuConfig { Name = "PhpStorm", Root = "phpstorm", Path = @"D:\Peng\App\Software\JetBrains\PhpStorm 2023.3.1\bin\phpstorm64.exe", ForFiles = false, Enabled = false },
                new MenuConfig { Name = "GoLand", Root = "goland", Path = @"D:\App\IDE\JetBrains\GoLand 2023.3.1\bin\goland64.exe", ForFiles = false, Enabled = false },
                new MenuConfig { Name = "Cursor", Root = "cursor", Path = @"D:\App\IDE\Cursor\Cursor.exe", ForFiles = false, Enabled = false },
                new MenuConfig { Name = "Trae", Root = "trae", Path = @"D:\App\IDE\Trae\Trae.exe", ForFiles = false, Enabled = false },
                new MenuConfig { Name = "Notepad++", Root = "notepadpp", Path = @"C:\Program Files\Notepad++\notepad++.exe", ForFiles = true, Enabled = false },
                new MenuConfig { Name = "Sublime Text", Root = "sublimetext", Path = @"C:\Program Files\Sublime Text\sublime_text.exe", ForFiles = true, Enabled = false },
                new MenuConfig { Name = "记事本", Root = "notepad", Path = @"C:\Windows\System32\notepad.exe", ForFiles = true, Enabled = false }
            };
        }
    }
}
