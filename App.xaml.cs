using System.Windows;

namespace MenuManager
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // 设置全局异常处理
            DispatcherUnhandledException += (sender, ex) =>
            {
                MessageBox.Show($"发生未处理的异常: {ex.Exception.Message}", "错误", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
                ex.Handled = true;
            };

            // 创建并显示主窗口
            var mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
