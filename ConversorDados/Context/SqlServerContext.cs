namespace ConversorDados.Context
{
    public class SqlServerContext
    {
        private static string _servidor = "DESKTOP-662CJ0I";
        private static string connectionString;
        public static string ConnectionString { get { return connectionString; } }

        public SqlServerContext(string banco)
        {
            connectionString = $"Server={_servidor};Database={banco};Trusted_Connection=True";
        }

    }
}
