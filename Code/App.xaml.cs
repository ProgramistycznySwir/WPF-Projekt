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

namespace WPF_Project
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; } 
        public IConfiguration Configuration { get; private set; }
    
        protected override void OnStartup(StartupEventArgs e)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                // .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .SetBasePath(Directory.GetCurrentDirectory());
    
            Configuration = builder.Build();
    
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
    
            ServiceProvider = serviceCollection.BuildServiceProvider();
    
            //var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            //mainWindow.Show();
        }
    
        private void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlite("Filename=ElloApp.db"));
    
            //services.AddTransient(typeof(MainWindow));
        }
    }
}
