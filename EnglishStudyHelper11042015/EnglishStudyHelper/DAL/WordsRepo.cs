using System;
using System.Collections.Generic;
using System.Data.SQLite;
using EnglishStudyHelper.Entities;

namespace EnglishStudyHelper.DAL
{
    public class WordsRepo : BaseContext, IRepository<Word>
    {
      
        public IEnumerable<Word> GetListAll()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT w.id, w.wordEN, t.id, t.wordRU, c.id, c.name as category FROM words w"
                                           + " LEFT OUTER JOIN translates t ON w.Id = t.idWordEn"
                                           + " LEFT OUTER JOIN categories c ON w.catId = c.id";

                    using (var reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            var words = new Word(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3), reader.GetInt32(4), reader.GetString(5));

                            yield return words;
                        }
                    }
                }
            }
        }

        public void Insert(Word word)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "insert into words (wordEN, catId) values (@word, @catId)";

                    command.Parameters.AddWithValue("@wordEN", word.WordName);
                    command.Parameters.AddWithValue("@catId", word.CategoryId);
                    command.ExecuteNonQuery();

                    command.Parameters.Clear();
                    command.CommandText = "SELECT max(id) FROM words";

                    word.WordId = Convert.ToInt32(command.ExecuteScalar());

                    command.Parameters.Clear();
                    command.CommandText = "insert into translates (wordRU, idWordEn) values (@trans, @idWord)";
                    command.Parameters.AddWithValue("@wordRU", word.Translate);
                    command.Parameters.AddWithValue("@idWord", word.WordId);
                    command.ExecuteNonQuery();

                    command.Parameters.Clear();
                    command.CommandText = "SELECT max(id) FROM translates";

                    word.TranslateId = Convert.ToInt32(command.ExecuteScalar());  
               

                }
            }
        }


        public void Update(Word word) { throw new NotImplementedException(); }

        public void Delete(Word word) { throw new NotImplementedException(); }

        public Word GetById(int id) { throw new NotImplementedException(); }
    }
}
