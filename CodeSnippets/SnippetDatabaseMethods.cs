﻿using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using SqlObjectHydrator;

namespace CodeSnippets
{
    public class SnippetDatabaseMethods
    {
        public async Task<List<Snippet>> Get()
        {
            var sql = @"
SELECT
	[Id],
	[Key],
	[Value],
	[UsedCount],
	[LanguageId]
FROM
	[Snippets]
";
            var sqlHelper = new SqlHelper();
            var reader = await sqlHelper.ExecuteReaderAsync(sql);
            return reader.DataReaderToList<Snippet>();
        }

        public async Task<List<Snippet>> GetForLanguage(Language language)
        {
            var sql = @"
SELECT
	[Id],
	[Key],
	[Value],
	[UsedCount],
	[LanguageId]
FROM
	[Snippets]
WHERE
    [LanguageId] = @LanguageId
";
            var sqlHelper = new SqlHelper();
            var reader = await sqlHelper.ExecuteReaderAsync(sql, new SqlParameter("@LanguageId", language.Id));
            return reader.DataReaderToList<Snippet>();
        }
    }
}