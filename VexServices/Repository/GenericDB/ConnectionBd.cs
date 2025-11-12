namespace VexServices.Repository.GenericBd
{
    public class ConnectionBd
    {
        public static readonly IConfiguration _configuration;

        static string? connectionString { get; set; }
        static string? providerName { get; set; }

        static ConnectionBd()
        {
            try
            {
                _configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                connectionString = _configuration.GetConnectionString("DefaultConnection");
                providerName = _configuration.GetConnectionString("DefaultConnection");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static string ConnectionString
        {
            get { return connectionString; }
        }

        public static string ProviderName
        {
            get { return providerName; }
        }
    }
}
