using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CodeSnippets
{
    public class SqlHelper
    {
        public async Task<SqlDataReader> ExecuteReaderAsync(string sql, SqlParameter[] parameters)
        {
            var connectionString = ConfigurationManager.AppSettings["ConnectionString"];
            try
            {
                var connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
                var command = new SqlCommand(sql, connection);
                await connection.OpenAsync();
                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
                var reader = await command.ExecuteReaderAsync();
                return reader;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<SqlDataReader> ExecuteReaderAsync(string sql)
        {
            return await ExecuteReaderAsync(sql, new SqlParameter[0]);
        }

        public async Task<SqlDataReader> ExecuteReaderAsync(string sql, SqlParameter parameter)
        {
            return await ExecuteReaderAsync(sql, new SqlParameter[] {parameter});
        }

        public async Task<object> ExecuteScalarAsync(string sql, SqlParameter[] parameters)
        {
            using (var connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            using (var command = new SqlCommand(sql, connection))
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }

                return await command.ExecuteScalarAsync();
            }
        }

    }
}