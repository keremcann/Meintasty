using Microsoft.Extensions.Configuration;

namespace Meintasty.Core.Configuration
{
    /// <summary>
    /// appsettings.json dosyasından key-value döndürür
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// Temel DB
        /// </summary>
        /// <returns></returns>
        public static string? GetConnectionString()
        {
            var builder = new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory).AddJsonFile("appsettings.json", true, false);
            IConfiguration configuration = builder.Build();
            return configuration.GetConnectionString("Meintasty");
        }

        /// <summary>
        /// Jwt Token şifreleme anahtarı
        /// </summary>
        /// <returns></returns>
        public static string? GetSecretKey()
        {
            var builder = new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory).AddJsonFile("appsettings.json", true, false);
            IConfiguration configuration = builder.Build();
            return configuration.GetSection("Jwt").GetSection("SecretKey").Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string? GetLogFilePath()
        {
            var builder = new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory).AddJsonFile("appsettings.json", true, false);
            IConfiguration configuration = builder.Build();
            return configuration.GetSection("Paths").GetSection("LogFilePath").Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string? GetCryptographyKey()
        {
            var builder = new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory).AddJsonFile("appsettings.json", true, false);
            IConfiguration configuration = builder.Build();
            return configuration.GetSection("CryptoKey").Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string? GetConnectionStringPassword()
        {
            var builder = new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory).AddJsonFile("appsettings.json", true, false);
            IConfiguration configuration = builder.Build();
            return configuration.GetSection("CnnStrPassKey").Value;
        }
    }
}
