using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;

namespace XamarinProjektZaliczeniowy
{

    //Baza danych i zapytania do niej
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Word>().Wait();
        }

        public Task<List<Word>> GetWordsAsync()
        {
            return _database.Table<Word>().ToListAsync();
        }

        public Task<int> SaveWordAsync(Word word)
        {
            return _database.InsertAsync(word);
        }

        public Task<List<Word>> GetLanguageAsync()
        {
            return _database.QueryAsync<Word>("SELECT DISTINCT language FROM Word");
        }

        public Task<List<Word>> GetCategoryAsync(string lang)
        {
            return _database.QueryAsync<Word>($"SELECT DISTINCT category FROM Word WHERE language = \"{lang}\"");
        }

        public Task<List<Word>> UpdateWordAsync(int id, string word, string trans, string lang, string cat)
        {
            return _database.QueryAsync<Word>($"UPDATE Word SET word = \"{word}\", translation = \"{trans}\", language = \"{lang}\", category = \"{cat}\" WHERE ID = \"{id}\"");
        }

        public Task<List<Word>> GetWordsByCategoryAsync(string lang, string cat)
        {
            return _database.QueryAsync<Word>($"SELECT * FROM Word WHERE category = \"{cat}\" AND language = \"{lang}\"");
        }

        public Task<List<Word>> DeleteWordAsync(int id)
        {
            return _database.QueryAsync<Word>($"DELETE FROM Word WHERE ID = \"{id}\"");
        }

    }
}
