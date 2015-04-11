using System;
using System.Collections.Generic;
using System.Data.SQLite;
using EnglishStudyHelper.Entities;

namespace EnglishStudyHelper.DAL
{
    public class CategoriesRepo : BaseContext, IRepository<Category>
    {

        public IEnumerable<Category> GetListAll()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText =
                        "SELECT Id, Name, IsSelected FROM Category";

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var categories = new Category(reader.GetInt32(0), reader.GetString(1), reader.GetBoolean(2));

                        yield return categories;
                    }
                }
            }
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Category obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Category obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(Category obj)
        {
            throw new NotImplementedException();
        }
    }
}
