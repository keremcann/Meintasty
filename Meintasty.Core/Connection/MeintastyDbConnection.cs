using Meintasty.Core.Configuration;
using Meintasty.Core.Cryptography;
using Meintasty.Core.Log;
using System.Data;
using System.Data.SqlClient;

namespace Meintasty.Core.Connection
{
    public abstract class MeintastyDbConnection
    {
        public DbConnectionResult connection;

        /// <summary>
        /// 
        /// </summary>
        public MeintastyDbConnection()
        {
            connection = OpenConnection();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private DbConnectionResult OpenConnection()
        {
            var response = new DbConnectionResult();
            try
            {
                string connectionStr = AppSettings.GetConnectionString() ?? Domain.Shared.Constants.Connection.ConnectionString;
                //EditConnectionString(AppSettings.GetConnectionString() ?? "");

                IDbConnection _db = new SqlConnection(connectionStr);
                _db.Open();
                response.db = _db;
                response.Success = true;
                response.InfoMessage = "Success";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
                FileLog log = new FileLog();
                log.Error(ex.Message);
            }
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        private static string DecryptPassword(string connectionString)
        {
            int indexStart = connectionString.IndexOf("Password") + "Password".Length;
            int indexEnd = connectionString.IndexOf(";", indexStart);
            return connectionString.Substring(indexStart, indexEnd - indexStart);
        }

        /// <summary>
        /// ConnectionString'teki Encrypt'li DB kullanıcı şifresini çözer ve ConnectionString'e geri ekler.
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        private static string EditConnectionString(string connectionString)
        {
            string secretPassword = AppSettings.GetConnectionStringPassword() ?? "";
            string password = Decryption.DecryptWithDefaultKey(secretPassword);
            connectionString = connectionString.Replace("#password#", password);
            return connectionString;
        }
    }
}
