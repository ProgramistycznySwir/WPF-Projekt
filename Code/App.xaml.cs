using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WPF_Project.Data;
using WPF_Project.Services;
using WPF_Project.Services.Interfaces;

namespace WPF_Project
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; } 
        public IConfiguration Configuration { get; private set; }


        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
    
            ServiceProvider = services.BuildServiceProvider();
        }
    
        private void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlite("Filename=ElloApp.db"));

            void RegisterDependancies(IServiceCollection services)
            {
                services.AddScoped<ITaskService, TaskService>();
                services.AddScoped<IColumnService, ColumnService>();
                services.AddScoped<ITagService, TagService>();
            }
            RegisterDependancies(services);

            services.AddSingleton<MainWindow>();
            //services.AddScoped<Task>();
            //services.AddTransient(typeof(MainWindow));
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = ServiceProvider.GetService<MainWindow>();
            mainWindow!.Show();
        }
    }
}
