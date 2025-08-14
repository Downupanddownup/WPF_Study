using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;
using WpfApp1.Dao;
using WpfApp1.Dao.Repository;
using WpfApp1.Service;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // 配置依赖注入容器
            var services = new ServiceCollection();
            services.AddSingleton<DbConnectionFactory>();
            services.AddSingleton<DbInitializer>();
            services.AddTransient<MyRecordRepository>();
            services.AddTransient<MyRecordService>();

            ServiceProvider = services.BuildServiceProvider();

            // 应用程序启动时进行数据库初始化
            var initializer = ServiceProvider.GetRequiredService<DbInitializer>();
            initializer.Initialize();

            // 创建主窗口
            //var mainWindow = new MainWindow();
            //mainWindow.Show();
        }
    }

}
