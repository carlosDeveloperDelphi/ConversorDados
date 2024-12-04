namespace ConversorDados.Context
{
    public class SqlServerContext
    {
        private static string _servidor = "DESKTOP-662CJ0I";
        private static string connectionString;
        public static string ConnectionString { get { return connectionString; } }

        public SqlServerContext(string banco)
        {
            connectionString = $"Server={_servidor};Database={banco};User ID=sa;Password=#grunt1234@;Integrated Security=SSPI;TrustServerCertificate=True";
        }

    }
}
