using System.Reflection;
using System.Windows;
using System.Windows.Navigation;

namespace MenuManager
{
    /// <summary>
    /// AboutDialog.xaml 的交互逻辑
    /// </summary>
    public partial class AboutDialog : Window
    {
        public string VersionText { get; }

        public AboutDialog()
        {
            InitializeComponent();

            // 获取版本信息
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            VersionText = $"当前版本：v{version?.ToString(3) ?? "0.0.1"}";

            // 设置数据上下文
            DataContext = this;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            try
            {
                // 使用默认浏览器打开链接
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = e.Uri.AbsoluteUri,
                    UseShellExecute = true
                });
                e.Handled = true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"无法打开链接：{ex.Message}", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}