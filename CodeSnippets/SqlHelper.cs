using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CodeSnippets
{
    public class SqlHelper
    {
        public async Task ExecuteNonQueryAsync(string sql, SqlParameter[] parameters)
        {
            try
            {
                var connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
                var command = new SqlCommand(sql, connection);
                await connection.OpenAsync();
                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }

                await command.ExecuteNonQueryAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task ExecuteNonQueryAsync(string sql, SqlParameter parameter)
        {
            await ExecuteNonQueryAsync(sql, new SqlParameter[] {parameter});
        }

        public async Task ExecuteNonQueryAsync(string sql)
        {
            await ExecuteNonQueryAsync(sql, new SqlParameter[0]);
        }

        public async Task<SqlDataReader> ExecuteReaderAsync(string sql, SqlParameter[] parameters)
        {
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