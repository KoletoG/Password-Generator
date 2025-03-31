using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace password_generator
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Log.Logger = new LoggerConfiguration()
           .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
           .CreateLogger();
            IServiceProvider serviceProvider = new ServiceCollection()
            .AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddSerilog();
            })
            .AddSingleton<Form1>()
            .AddSingleton<IMethodService,MethodService>()
            .BuildServiceProvider();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(serviceProvider.GetService<Form1>());
        }
    }
}
