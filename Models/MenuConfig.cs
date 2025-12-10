using System.ComponentModel;
using Newtonsoft.Json;

namespace MenuManager.Models
{
    /// <summary>
    /// 右键菜单配置项
    /// </summary>
    public class MenuConfig : INotifyPropertyChanged
    {
        private string _name = string.Empty;
        private string _root = string.Empty;
        private string _path = string.Empty;
        private bool _forFiles;
        private bool _enabled;

        /// <summary>
        /// 显示名称
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        /// <summary>
        /// 注册表键名
        /// </summary>
        [JsonProperty("root")]
        public string Root
        {
            get => _root;
            set
            {
                if (_root != value)
                {
                    _root = value;
                    OnPropertyChanged(nameof(Root));
                }
            }
        }

        /// <summary>
        /// 程序路径
        /// </summary>
        [JsonProperty("path")]
        public string Path
        {
            get => _path;
            set
            {
                if (_path != value)
                {
                    _path = value;
                    OnPropertyChanged(nameof(Path));
                }
            }
        }

        /// <summary>
        /// 是否应用于文件（否则应用于目录）
        /// </summary>
        [JsonProperty("for_files")]
        public bool ForFiles
        {
            get => _forFiles;
            set
            {
                if (_forFiles != value)
                {
                    _forFiles = value;
                    OnPropertyChanged(nameof(ForFiles));
                }
            }
        }

        /// <summary>
        /// 是否启用
        /// </summary>
        [JsonProperty("enabled")]
        public bool Enabled
        {
            get => _enabled;
            set
            {
                if (_enabled != value)
                {
                    _enabled = value;
                    OnPropertyChanged(nameof(Enabled));
                    OnPropertyChanged(nameof(StatusText));
                }
            }
        }

        /// <summary>
        /// 状态文本（用于UI显示）
        /// </summary>
        [JsonIgnore]
        public string StatusText => Enabled ? "✓ 已启用" : "○ 已禁用";

        /// <summary>
        /// 应用范围文本（用于UI显示）
        /// </summary>
        [JsonIgnore]
        public string ScopeText => ForFiles ? "文件" : "目录";

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// 创建配置的副本
        /// </summary>
        public MenuConfig Clone()
        {
            return new MenuConfig
            {
                Name = this.Name,
                Root = this.Root,
                Path = this.Path,
                ForFiles = this.ForFiles,
                Enabled = this.Enabled
            };
        }
    }

    /// <summary>
    /// 配置文件结构
    /// </summary>
    public class ConfigFile
    {
        [JsonProperty("configs")]
        public List<MenuConfig> Configs { get; set; } = new List<MenuConfig>();
    }
}
