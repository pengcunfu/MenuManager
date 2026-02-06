using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using MenuManager.Models;
using MenuManager.Services;

namespace MenuManager
{
    /// <summary>
    /// 主窗口交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ConfigManager _configManager;
        private readonly RegistryManager _registryManager;
        private readonly Win11ContextMenuManager _win11MenuManager;
        private readonly ObservableCollection<MenuConfig> _configs;
        private MenuConfig? _selectedConfig;
        private int _selectedIndex = -1;
        private bool _isUpdatingUI = false;
        private bool _isAddingNew = false;

        public MainWindow()
        {
            InitializeComponent();
            
            _configManager = new ConfigManager();
            _registryManager = new RegistryManager();
            _win11MenuManager = new Win11ContextMenuManager();
            _configs = new ObservableCollection<MenuConfig>();
            
            ConfigListBox.ItemsSource = _configs;
            
            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // 检查管理员权限
                CheckAdminPermissions();
                
                // 加载配置
                await LoadConfigsAsync();
            }
            catch (Exception ex)
            {
                ShowError($"初始化失败: {ex.Message}");
            }
        }

        /// <summary>
        /// 检查管理员权限
        /// </summary>
        private void CheckAdminPermissions()
        {
            if (!_registryManager.IsAdmin())
            {
                var result = MessageBox.Show(
                    "此程序需要管理员权限才能修改注册表。\n是否以管理员身份重新启动？",
                    "需要管理员权限",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    if (_registryManager.RelaunchAsAdmin())
                    {
                        Application.Current.Shutdown();
                        return;
                    }
                    else
                    {
                        ShowError("以管理员身份重新启动失败");
                    }
                }
                else
                {
                    ShowWarning("没有管理员权限，部分功能可能无法正常使用");
                }
            }
        }

        /// <summary>
        /// 加载配置
        /// </summary>
        private async Task LoadConfigsAsync()
        {
            try
            {
                await _configManager.LoadAsync();
                var configs = _configManager.GetConfigs();

                // 刷新菜单状态
                var refreshedConfigs = _registryManager.RefreshMenuStatus(configs);

                // 保存当前选中状态
                int selectedIndex = ConfigListBox.SelectedIndex;

                _configs.Clear();
                foreach (var config in refreshedConfigs)
                {
                    _configs.Add(config);
                }

                // 恢复选中状态（不触发UI更新）
                if (selectedIndex >= 0 && selectedIndex < _configs.Count)
                {
                    _isUpdatingUI = true;
                    ConfigListBox.SelectedIndex = selectedIndex;
                    _selectedConfig = _configs[selectedIndex];
                    _isUpdatingUI = false;
                }
            }
            catch (Exception ex)
            {
                ShowError($"加载配置失败: {ex.Message}");
            }
        }

        /// <summary>
        /// 配置列表选择变更
        /// </summary>
        private void ConfigListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // 如果正在添加新配置，退出添加模式
            _isAddingNew = false;
            
            if (ConfigListBox.SelectedIndex >= 0 && ConfigListBox.SelectedIndex < _configs.Count)
            {
                _selectedIndex = ConfigListBox.SelectedIndex;
                _selectedConfig = _configs[_selectedIndex];
                LoadConfigToUI(_selectedConfig);
            }
            else
            {
                _selectedIndex = -1;
                _selectedConfig = null;
                ClearUI();
            }
        }

        /// <summary>
        /// 将配置加载到UI
        /// </summary>
        private void LoadConfigToUI(MenuConfig config)
        {
            _isUpdatingUI = true;

            NameTextBox.Text = config.Name;
            RootTextBox.Text = config.Root;
            PathTextBox.Text = config.Path;
            ForFilesCheckBox.IsChecked = config.ForFiles;
            ForDirectoriesCheckBox.IsChecked = config.ForDirectories;

            // 更新标题
            ConfigDetailsGroupBox.Header = $"配置详情 - {config.Name}";

            // 更新按钮状态
            UpdateButtonStates();

            _isUpdatingUI = false;
        }

        /// <summary>
        /// 清空UI
        /// </summary>
        private void ClearUI()
        {
            _isUpdatingUI = true;

            NameTextBox.Text = string.Empty;
            RootTextBox.Text = string.Empty;
            PathTextBox.Text = string.Empty;
            ForFilesCheckBox.IsChecked = false;
            ForDirectoriesCheckBox.IsChecked = false;

            // 更新标题
            ConfigDetailsGroupBox.Header = _isAddingNew ? "配置详情 - 新增配置" : "配置详情";

            // 更新按钮状态
            UpdateButtonStates();

            _isUpdatingUI = false;
        }

        /// <summary>
        /// 更新按钮状态
        /// </summary>
        private void UpdateButtonStates()
        {
            bool hasSelection = _selectedConfig != null || _isAddingNew;
            
            // 删除菜单项需要有选中项且不在添加模式
            RemoveConfigMenuItem.IsEnabled = _selectedConfig != null && !_isAddingNew;
            
            // 保存、应用更改、测试路径按钮需要有选中项或在添加模式
            SaveButton.IsEnabled = hasSelection;
            ApplyButton.IsEnabled = hasSelection;
            TestPathButton.IsEnabled = hasSelection;
        }

        /// <summary>
        /// 添加配置
        /// </summary>
        private void AddConfigButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // 进入添加模式
                _isAddingNew = true;
                _selectedConfig = null;
                _selectedIndex = -1;
                
                // 清空列表选择
                ConfigListBox.SelectedIndex = -1;
                
                // 设置默认值
                _isUpdatingUI = true;
                NameTextBox.Text = "新配置";
                RootTextBox.Text = "";
                PathTextBox.Text = "";
                ForFilesCheckBox.IsChecked = false;
                ForDirectoriesCheckBox.IsChecked = false;
                _isUpdatingUI = false;
                
                // 更新标题
                ConfigDetailsGroupBox.Header = "配置详情 - 新增配置";
                
                // 更新按钮状态
                UpdateButtonStates();
                
                // 聚焦到名称输入框
                NameTextBox.Focus();
                NameTextBox.SelectAll();
            }
            catch (Exception ex)
            {
                ShowError($"添加配置失败: {ex.Message}");
            }
        }

        /// <summary>
        /// 保存配置（不更新菜单）
        /// </summary>
        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // 验证输入
                var name = NameTextBox.Text.Trim();
                var root = RootTextBox.Text.Trim();
                var path = PathTextBox.Text.Trim();

                var newConfig = new MenuConfig
                {
                    Name = name,
                    Root = root,
                    Path = path,
                    ForFiles = ForFilesCheckBox.IsChecked ?? false,
                    ForDirectories = ForDirectoriesCheckBox.IsChecked ?? false
                };

                // 验证配置
                _configManager.ValidateConfig(newConfig);

                // 如果是添加模式，自动生成根键名
                if (_isAddingNew && string.IsNullOrEmpty(root))
                {
                    newConfig.Root = GenerateUniqueRoot(name);
                }

                // 检查根键名唯一性
                if (!_configManager.CheckRootUnique(newConfig.Root, _isAddingNew ? -1 : _selectedIndex))
                {
                    ShowError("注册表键名已存在，请使用其他名称");
                    return;
                }

                // 检查路径
                if (!_configManager.ValidatePath(path))
                {
                    var result = MessageBox.Show(
                        "程序路径不存在，是否继续？",
                        "路径警告",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Warning);

                    if (result != MessageBoxResult.Yes)
                        return;
                }

                if (_isAddingNew)
                {
                    // 添加新配置
                    await _configManager.AddConfigAsync(newConfig);
                    await LoadConfigsAsync();
                    
                    // 选中新添加的配置
                    var newIndex = _configs.Count - 1;
                    ConfigListBox.SelectedIndex = newIndex;
                    _isAddingNew = false;
                    
                    ShowInfo("配置添加成功");
                }
                else
                {
                    // 更新现有配置
                    await _configManager.UpdateConfigAsync(_selectedIndex, newConfig);
                    await LoadConfigsAsync();
                    
                    ConfigListBox.SelectedIndex = _selectedIndex;
                    ShowInfo("配置保存成功");
                }
                
                UpdateButtonStates();
            }
            catch (Exception ex)
            {
                ShowError($"保存配置失败: {ex.Message}");
            }
        }

        /// <summary>
        /// 生成唯一的根键名
        /// </summary>
        private string GenerateUniqueRoot(string name)
        {
            var baseRoot = name.ToLower().Replace(" ", "").Replace("-", "").Replace("_", "");
            var root = baseRoot;
            var counter = 1;

            while (!_configManager.CheckRootUnique(root, _isAddingNew ? -1 : _selectedIndex))
            {
                root = $"{baseRoot}{counter}";
                counter++;
            }

            return root;
        }

        /// <summary>
        /// 删除配置
        /// </summary>
        private async void RemoveConfigButton_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedIndex < 0 || _selectedConfig == null || _isAddingNew)
            {
                ShowWarning("请先选择要删除的配置");
                return;
            }

            var deleteMessage = $"确定要删除配置 \"{_selectedConfig.Name}\" 吗？\n\n";
            deleteMessage += $"注册表键名: {_selectedConfig.Root}\n";
            deleteMessage += $"程序路径: {_selectedConfig.Path}\n";
            deleteMessage += $"应用范围: {_selectedConfig.ScopeText}\n";
            deleteMessage += $"当前状态: {_selectedConfig.StatusText}";
            
            if (_selectedConfig.Enabled)
            {
                deleteMessage += "\n\n⚠️ 该配置当前已启用，删除后右键菜单也将被移除。";
            }

            var result = MessageBox.Show(
                deleteMessage,
                "确认删除配置",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result != MessageBoxResult.Yes)
                return;

            try
            {
                // 如果菜单已启用，先删除菜单
                if (_selectedConfig.Enabled)
                {
                    try
                    {
                        _registryManager.RemoveMenu(_selectedConfig);
                    }
                    catch (Exception ex)
                    {
                        ShowWarning($"删除菜单失败: {ex.Message}");
                    }
                }

                // 删除配置
                await _configManager.RemoveConfigAsync(_selectedIndex);
                await LoadConfigsAsync();

                _selectedIndex = -1;
                _selectedConfig = null;
                _isAddingNew = false;
                ClearUI();
            }
            catch (Exception ex)
            {
                ShowError($"删除配置失败: {ex.Message}");
            }
        }

        /// <summary>
        /// 刷新状态
        /// </summary>
        private async void RefreshStatusButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await LoadConfigsAsync();
            }
            catch (Exception ex)
            {
                ShowError($"刷新状态失败: {ex.Message}");
            }
        }

        /// <summary>
        /// 应用更改（保存配置并更新菜单）
        /// </summary>
        private async void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // 验证输入
                var name = NameTextBox.Text.Trim();
                var root = RootTextBox.Text.Trim();
                var path = PathTextBox.Text.Trim();
                var enabled = (ForFilesCheckBox.IsChecked ?? false) || (ForDirectoriesCheckBox.IsChecked ?? false);

                var newConfig = new MenuConfig
                {
                    Name = name,
                    Root = root,
                    Path = path,
                    ForFiles = ForFilesCheckBox.IsChecked ?? false,
                    ForDirectories = ForDirectoriesCheckBox.IsChecked ?? false
                };

                // 验证配置
                _configManager.ValidateConfig(newConfig);

                // 如果是添加模式，自动生成根键名
                if (_isAddingNew && string.IsNullOrEmpty(root))
                {
                    newConfig.Root = GenerateUniqueRoot(name);
                }

                // 检查根键名唯一性
                if (!_configManager.CheckRootUnique(newConfig.Root, _isAddingNew ? -1 : _selectedIndex))
                {
                    ShowError("注册表键名已存在，请使用其他名称");
                    return;
                }

                // 检查路径
                if (!_configManager.ValidatePath(path))
                {
                    var result = MessageBox.Show(
                        "程序路径不存在，是否继续？",
                        "路径警告",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Warning);

                    if (result != MessageBoxResult.Yes)
                        return;
                }

                // 处理菜单状态
                bool originalEnabled = _isAddingNew ? false : (_selectedConfig?.Enabled ?? false);
                
                if (_isAddingNew)
                {
                    // 添加新配置
                    await _configManager.AddConfigAsync(newConfig);
                    await LoadConfigsAsync();
                    
                    // 选中新添加的配置
                    var newIndex = _configs.Count - 1;
                    var savedConfig = _configs[newIndex];
                    
                    // 如果要启用菜单
                    if (enabled)
                    {
                        try
                        {
                            _registryManager.UpdateMenuStatus(savedConfig, true);
                            ShowInfo("配置添加成功，右键菜单已启用");
                        }
                        catch (Exception ex)
                        {
                            ShowWarning($"配置已添加，但启用菜单失败: {ex.Message}");
                        }
                    }
                    else
                    {
                        ShowInfo("配置添加成功");
                    }
                    
                    ConfigListBox.SelectedIndex = newIndex;
                    _isAddingNew = false;
                }
                else
                {
                    // 更新现有配置
                    try
                    {
                        // 如果启用状态发生变化或配置信息改变，更新注册表
                        if (originalEnabled != enabled)
                        {
                            if (enabled)
                            {
                                // 要启用菜单
                                _registryManager.UpdateMenuStatus(newConfig, true);
                            }
                            else
                            {
                                // 要禁用菜单
                                _registryManager.UpdateMenuStatus(_selectedConfig!, false);
                            }
                        }
                        else if (enabled)
                        {
                            // 如果保持启用状态，但配置信息可能改变，需要更新注册表
                            _registryManager.UpdateMenuStatus(newConfig, true);
                        }

                        // 更新配置
                        await _configManager.UpdateConfigAsync(_selectedIndex, newConfig);
                        await LoadConfigsAsync();
                        
                        ConfigListBox.SelectedIndex = _selectedIndex;
                        ShowInfo("配置已应用，右键菜单已更新");
                    }
                    catch (Exception ex)
                    {
                        ShowError($"应用配置失败: {ex.Message}");
                        return;
                    }
                }
                
                UpdateButtonStates();
            }
            catch (Exception ex)
            {
                ShowError($"应用更改失败: {ex.Message}");
            }
        }

        /// <summary>
        /// 启用状态变更
        /// </summary>
        /// <summary>
        /// 应用范围CheckBox变更事件
        /// </summary>
        private async void ForScopeCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (_isUpdatingUI || _selectedConfig == null || _selectedIndex < 0)
                return;

            try
            {
                var forFiles = ForFilesCheckBox.IsChecked ?? false;
                var forDirectories = ForDirectoriesCheckBox.IsChecked ?? false;
                var enabled = forFiles || forDirectories;

                // 保存原始状态
                var originalForFiles = _selectedConfig.ForFiles;
                var originalForDirectories = _selectedConfig.ForDirectories;

                // 如果要启用（至少选中一个范围），先验证配置
                if (enabled)
                {
                    var tempConfig = new MenuConfig
                    {
                        Name = NameTextBox.Text.Trim(),
                        Root = RootTextBox.Text.Trim(),
                        Path = PathTextBox.Text.Trim(),
                        ForFiles = forFiles,
                        ForDirectories = forDirectories
                    };

                    try
                    {
                        _configManager.ValidateConfig(tempConfig);
                    }
                    catch (Exception ex)
                    {
                        ShowError($"请先完善配置信息: {ex.Message}");
                        _isUpdatingUI = true;
                        ForFilesCheckBox.IsChecked = originalForFiles;
                        ForDirectoriesCheckBox.IsChecked = originalForDirectories;
                        _isUpdatingUI = false;
                        return;
                    }

                    if (!_configManager.ValidatePath(tempConfig.Path))
                    {
                        var result = MessageBox.Show(
                            "程序路径不存在，是否继续启用？",
                            "路径警告",
                            MessageBoxButton.YesNo,
                            MessageBoxImage.Warning);

                        if (result != MessageBoxResult.Yes)
                        {
                            _isUpdatingUI = true;
                            ForFilesCheckBox.IsChecked = originalForFiles;
                            ForDirectoriesCheckBox.IsChecked = originalForDirectories;
                            _isUpdatingUI = false;
                            return;
                        }
                    }

                    // 更新配置信息
                    _selectedConfig.Name = tempConfig.Name;
                    _selectedConfig.Root = tempConfig.Root;
                    _selectedConfig.Path = tempConfig.Path;
                }

                // 更新菜单状态
                // 检查每个范围的变化
                var addedForFiles = forFiles && !originalForFiles;
                var addedForDirectories = forDirectories && !originalForDirectories;
                var removedForFiles = !forFiles && originalForFiles;
                var removedForDirectories = !forDirectories && originalForDirectories;

                if (addedForFiles || addedForDirectories)
                {
                    // 添加新选中的范围
                    var tempConfig = new MenuConfig
                    {
                        Name = _selectedConfig.Name,
                        Root = _selectedConfig.Root,
                        Path = _selectedConfig.Path,
                        ForFiles = addedForFiles,
                        ForDirectories = addedForDirectories
                    };
                    _registryManager.AddMenu(tempConfig);
                }

                if (removedForFiles || removedForDirectories)
                {
                    // 删除取消选中的范围（使用原始状态）
                    var tempConfig = new MenuConfig
                    {
                        Name = _selectedConfig.Name,
                        Root = _selectedConfig.Root,
                        Path = _selectedConfig.Path,
                        ForFiles = removedForFiles ? originalForFiles : false,
                        ForDirectories = removedForDirectories ? originalForDirectories : false
                    };
                    _registryManager.RemoveMenu(tempConfig);
                }

                // 更新配置对象
                _selectedConfig.ForFiles = forFiles;
                _selectedConfig.ForDirectories = forDirectories;

                // 保存配置
                await _configManager.UpdateConfigAsync(_selectedIndex, _selectedConfig);
                await LoadConfigsAsync();

                ConfigListBox.SelectedIndex = _selectedIndex;
            }
            catch (Exception ex)
            {
                ShowError($"更新菜单状态失败: {ex.Message}");

                // 恢复原状态
                _isUpdatingUI = true;
                ForFilesCheckBox.IsChecked = _selectedConfig.ForFiles;
                ForDirectoriesCheckBox.IsChecked = _selectedConfig.ForDirectories;
                _isUpdatingUI = false;
            }
        }

        /// <summary>
        /// 浏览路径
        /// </summary>
        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Title = "选择程序",
                Filter = "可执行文件 (*.exe)|*.exe|所有文件 (*.*)|*.*",
                CheckFileExists = true
            };

            if (dialog.ShowDialog() == true)
            {
                PathTextBox.Text = dialog.FileName;
            }
        }

        /// <summary>
        /// 测试路径
        /// </summary>
        private void TestPathButton_Click(object sender, RoutedEventArgs e)
        {
            var path = PathTextBox.Text.Trim();
            if (string.IsNullOrEmpty(path))
            {
                ShowWarning("请先输入程序路径");
                return;
            }

            if (_configManager.ValidatePath(path))
            {
                ShowInfo("✓ 路径有效");
            }
            else
            {
                ShowInfo("✗ 路径不存在");
            }
        }

        /// <summary>
        /// 显示错误消息
        /// </summary>
        private static void ShowError(string message)
        {
            MessageBox.Show(message, "错误", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// 显示警告消息
        /// </summary>
        private static void ShowWarning(string message)
        {
            MessageBox.Show(message, "警告", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        /// <summary>
        /// 显示信息消息
        /// </summary>
        private static void ShowInfo(string message)
        {
            MessageBox.Show(message, "信息", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        #region Win11菜单切换功能

        /// <summary>
        /// 禁用Win11一级菜单
        /// </summary>
        private async void DisableWin11MenuMenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // 验证系统兼容性
                var (isCompatible, message) = _win11MenuManager.ValidateSystemCompatibility();
                if (!isCompatible)
                {
                    ShowWarning(message);
                    return;
                }

                // 检查当前状态
                if (_win11MenuManager.IsWin11MenuDisabled())
                {
                    ShowInfo("Win11一级菜单已经是禁用状态（当前显示完整二级菜单）");
                    return;
                }

                // 确认操作
                var result = MessageBox.Show(
                    "确定要禁用Win11一级菜单吗？\n\n" +
                    "这将切换到Win10样式的右键菜单，显示完整的二级菜单。\n" +
                    "操作完成后会自动重启资源管理器。",
                    "确认禁用Win11一级菜单",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (result != MessageBoxResult.Yes)
                    return;

                // 执行禁用操作
                await Task.Run(() => _win11MenuManager.DisableWin11Menu());
                
                ShowInfo("Win11一级菜单已禁用，已切换到Win10样式的完整右键菜单");
            }
            catch (Exception ex)
            {
                ShowError($"禁用Win11菜单失败: {ex.Message}");
            }
        }

        /// <summary>
        /// 恢复Win11默认菜单
        /// </summary>
        private async void EnableWin11MenuMenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // 验证系统兼容性
                var (isCompatible, message) = _win11MenuManager.ValidateSystemCompatibility();
                if (!isCompatible)
                {
                    ShowWarning(message);
                    return;
                }

                // 检查当前状态
                if (!_win11MenuManager.IsWin11MenuDisabled())
                {
                    ShowInfo("Win11默认菜单已经是启用状态");
                    return;
                }

                // 确认操作
                var result = MessageBox.Show(
                    "确定要恢复Win11默认菜单吗？\n\n" +
                    "这将恢复Win11的默认右键菜单样式（显示一级菜单）。\n" +
                    "操作完成后会自动重启资源管理器。",
                    "确认恢复Win11默认菜单",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (result != MessageBoxResult.Yes)
                    return;

                // 执行恢复操作
                await Task.Run(() => _win11MenuManager.EnableWin11Menu());
                
                ShowInfo("Win11默认菜单已恢复");
            }
            catch (Exception ex)
            {
                ShowError($"恢复Win11菜单失败: {ex.Message}");
            }
        }

        /// <summary>
        /// 检查Win11菜单状态
        /// </summary>
        private void CheckWin11StatusMenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var statusMessage = "=== Win11右键菜单状态检查 ===\n\n";
                
                // 系统版本检查
                statusMessage += $"系统版本: {Environment.OSVersion}\n";
                statusMessage += $"是否为Windows 11: {(_win11MenuManager.IsWindows11() ? "是" : "否")}\n";
                
                // 权限检查
                statusMessage += $"管理员权限: {(_win11MenuManager.IsAdmin() ? "是" : "否")}\n";
                
                // 菜单状态
                statusMessage += $"当前状态: {_win11MenuManager.GetMenuStatusDescription()}\n\n";
                
                // 兼容性检查
                var (isCompatible, compatMessage) = _win11MenuManager.ValidateSystemCompatibility();
                statusMessage += $"系统兼容性: {(isCompatible ? "✓ 兼容" : "✗ 不兼容")}\n";
                if (!isCompatible)
                {
                    statusMessage += $"原因: {compatMessage}\n";
                }
                
                // 注册表访问测试
                statusMessage += $"注册表访问: {(_win11MenuManager.TestRegistryAccess() ? "✓ 正常" : "✗ 受限")}\n";

                MessageBox.Show(statusMessage, "Win11菜单状态", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                ShowError($"检查状态失败: {ex.Message}");
            }
        }

        /// <summary>
        /// 关于系统
        /// </summary>
        private void AboutWin11MenuMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var aboutDialog = new AboutDialog
            {
                Owner = this
            };
            aboutDialog.ShowDialog();
        }

        #endregion
    }
}