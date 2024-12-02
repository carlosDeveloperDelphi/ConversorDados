using ConversorDados.Context;
using System.Configuration;

namespace ConversorDados
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            CarregarDados();
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmConversorDados());
        }

        private static void CarregarDados() 
        {
            new SqlServerContext(ConfigurationManager.AppSettings["banco"]);
        }
    }
}