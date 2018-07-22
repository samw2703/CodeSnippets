using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using SqlObjectHydrator;

namespace CodeSnippets
{
    public class LanguageDatabaseMethods
    {
        public async Task<List<Language>> Get()
        {
            const string sql = @"
SELECT
	[Id],
	[Value]
FROM
	[Languages]";
            var sqlHelper = new SqlHelper();
            var reader = await sqlHelper.ExecuteReaderAsync(sql);
            return reader.DataReaderToList<Language>();
        }

        public async Task<Language> Get(int id)
        {
            const string sql = @"
SELECT
	[Id],
	[Value]
FROM
	[Languages]
WHERE
    Id = @Id";
            var sqlHelper = new SqlHelper();
            var reader = await sqlHelper.ExecuteReaderAsync(sql, new SqlParameter("@Id", id));
            return reader.DataReaderToList<Language>().First();
        }

        public async Task Post(Language language)
        {
            const string sql = @"
INSERT INTO [Languages]
    ([Value])
    VALUES(@Value)
";
            var sqlHelper = new SqlHelper();
            await sqlHelper.ExecuteNonQueryAsync(sql, new SqlParameter("@Value", language.Value));
        }

        public void Put(int Id, Language language)
        {
            const string sql = @"
SELECT
	[Id],
	[Value]
FROM
	[Languages]
WHERE
    Id = @Id";
        }

        public void Delete(int Id)
        {
            const string sql = @"
SELECT
	[Id],
	[Value]
FROM
	[Languages]
WHERE
    Id = @Id";
        }
    }

    public class Language
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
}