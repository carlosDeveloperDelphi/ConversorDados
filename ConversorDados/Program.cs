using ConversorDados.Context;
using System.Configuration;
using Vinum.Core.Negocios;
using Vinum.Entidades.Sistema;
using Vinum.Infra.Data;

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

            new PostgreSqlContext(ConfigurationManager.AppSettings["servidor"], ConfigurationManager.AppSettings["bancoPostgresql"], ConfigurationManager.AppSettings["porta"]);

            Sessao.Instancia.V000Con = new V000ConNG().Buscar().Result;
        }
    }
}