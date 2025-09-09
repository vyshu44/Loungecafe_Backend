namespace LoungeCafe.Database
{
    public class ApplicationDbContext
    {
        private readonly IConfiguration _configuration;
        public string ConnectionString { get; }

        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("DefaultConnection");
        }


    }
}
