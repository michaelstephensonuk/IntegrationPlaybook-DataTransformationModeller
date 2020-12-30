using DataMappingDesigner.Exporters;
using IntegrationPlaybook.Analysis.DataTransformation.Modeller;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataMappingDesigner
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string logPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\IntegrationPlaybook\\DataTransformationModeller.AppLog.txt";

            try
            {
                Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.File(logPath, shared: true)
                .CreateLogger();

                if (File.Exists(logPath) == false)
                {
                    Log.Information("Creating log file");
                }

                //var currentDirectory = Directory.GetCurrentDirectory();
                //Log.Information($"App Directory: {currentDirectory}");

                Application.ThreadException += Application_ThreadException;
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                var configuration = new ConfigurationBuilder()                    
                    .AddJsonFile("appsettings.json")
                    .Build();

                var host = Host.CreateDefaultBuilder()
                     .ConfigureAppConfiguration((context, builder) =>
                     {
                         builder.AddConfiguration(configuration);
                     })          
                     .UseSerilog((hostingContext, loggerConfiguration) => 
                        
                        loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration)
                        .Enrich.FromLogContext()
                     )
                     .ConfigureServices((context, services) =>
                     {
                         ConfigureServices(context.Configuration, services);
                     })
                     .Build();

                var services = host.Services;
                var mainForm = services.GetRequiredService<Form1>();
                Application.Run(mainForm);

            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                MessageBox.Show("Fatal error occured, please refer to application log files and support if the problem persists", "Error");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {

            services.AddSingleton<Form1>();

            services.AddTransient<AddMultipleChildNodesForm>();
            services.AddTransient<DestinationTreeNodePropertiesForm>();
            services.AddTransient<ExportForm>();
            services.AddTransient<ModelDetailsForm>();
            services.AddTransient<AboutBox1>();

            services.AddTransient<WordExporter>();

        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {

            MessageBox.Show(e.Exception.ToString(), "Error");
        }
    }
}
