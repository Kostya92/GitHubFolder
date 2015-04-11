using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace EnglishStudyHelper
{
    
    class DBManager
    {
        private String conString;
        private SQLiteConnection sqlCon;
        private SQLiteCommand sqlCmd;
        private SQLiteDataAdapter DB;
        private DataSet DS;
        private DataTable DT;
        Dictionary<String, String> paramsValues;
     
       
        public DBManager()
        {
                conString = @"Data Source=Helper.db;Version=3;New=False;Compress=True;";
                            
                DS = new DataSet();
                DT = new DataTable();
                paramsValues = new Dictionary<string, string>();
        }

      
        /************************************************************/
        //общий метод для выполнения запросов, не возвр. набор данных
        /************************************************************/
        private void ExecuteQuery(string txtQuery)
        {
            using (sqlCon = new SQLiteConnection(conString))
            {
                try
                {
                    sqlCon.Open();
                    sqlCmd = sqlCon.CreateCommand();
                    sqlCmd.CommandText = txtQuery;
                    sqlCmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlCon.Close();
                }

            }
        }

        private void ExecuteQueryWithParam(string txtQuery, Dictionary<String, String> paramsAndValues)
        {
            using (sqlCon = new SQLiteConnection(conString))
            {
                try
                {
                    sqlCon.Open();
                    sqlCmd = sqlCon.CreateCommand();
                    sqlCmd.CommandText = txtQuery;

                    if (paramsAndValues != null)
                    {
                        foreach (KeyValuePair<String, String> pair in paramsAndValues)
                        {
                            sqlCmd.Parameters.AddWithValue(pair.Key, pair.Value);
                        }
                    }
                   
                    sqlCmd.ExecuteNonQuery();
                     
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlCon.Close();
                }

            }
        }


        /**********************************************************/
        //общий метод для выполнения запросов, возвр. набор данных
        /*************************************************************/
        private DataTable LoadData(string commandText)
        {
          
             using (sqlCon = new SQLiteConnection(conString))
            {
                try
                {
                    sqlCon.Open();

                    sqlCmd = sqlCon.CreateCommand();

                  
                    DB = new SQLiteDataAdapter(commandText, sqlCon);
                    DS.Reset();
                    DB.Fill(DS);
                    DT = DS.Tables[0];

                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlCon.Close();
                }


            }

            return DT;
        }

        private DataTable LoadDataWithParam(string commandText, Dictionary<String, String> paramsAndValues)
        {

            using (sqlCon = new SQLiteConnection(conString))
            {
                try
                {
                    sqlCon.Open();

                    sqlCmd = sqlCon.CreateCommand();
                    sqlCmd.CommandText = commandText;
          
                 

                    DB = new SQLiteDataAdapter(sqlCmd.CommandText, sqlCon);
                    if (paramsAndValues != null)
                    {
                        foreach (KeyValuePair<String, String> pair in paramsAndValues)
                        {
                            DB.SelectCommand.Parameters.AddWithValue(pair.Key, pair.Value);

                        }
                    }

                    DS.Reset();
                    DB.Fill(DS);
                    DT = DS.Tables[0];

                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlCon.Close();
                }


            }

            return DT;
        }


        //запрос возвращающий целое значение
        private int ExecuteScalarQuery(string txtQuery)
        {
           

            using (sqlCon = new SQLiteConnection(conString))
            {
                try
                {
                    sqlCon.Open();
                    sqlCmd = sqlCon.CreateCommand();
                    sqlCmd.CommandText = txtQuery;
                    Object obj = sqlCmd.ExecuteScalar();
                    if (obj != null)
                    {
                        return Convert.ToInt32(obj);
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlCon.Close();
                   
                }

            }

            return 0;
        }


        /**************************************************************************************/
        /*запросы к таблице words (id integer primarykey autoincrement, wordEN text, wordRU text, catId int)
        /****************************************************************************************/
        public DataTable SelectWords()
        {
            return LoadData("SELECT w.id, w.wordEN, t.wordRU, c.name as category FROM words w"
                                           + " LEFT OUTER JOIN translates t ON w.Id = t.idWordEn"
                                           + " LEFT OUTER JOIN categories c ON w.catId = c.id");
       

        }

        public DataTable SelectWordsForTest()
        {

            return LoadData("SELECT w.wordEN,  t.wordRU, c.name as category FROM words w "
                 + " LEFT OUTER JOIN translates t ON w.Id = t.idWordEn"
                 + " LEFT OUTER JOIN categories c ON w.catId = c.id where c.isSelected = 1");
                                           
        }

        public DataTable SelectWordsForCat(string idCat, bool isContaine)
        {
            paramsValues.Clear();
            paramsValues.Add("@idCat", idCat);

            if (isContaine)
                return LoadDataWithParam("SELECT wordEN FROM words where catId = @idCat", paramsValues);
            else
                return LoadDataWithParam("SELECT wordEN FROM words where catId <> @idCat", paramsValues);


        }

        public void InsertWordTrans(String word, String trans, String catId = "0")
        {
            paramsValues.Clear();
            paramsValues.Add("@word", word);
            paramsValues.Add("@catId", catId);

            ExecuteQueryWithParam("insert into words (wordEN, catId) values (@word, @catId)", paramsValues);
            int idWord = ExecuteScalarQuery("SELECT max(id) FROM words");

            paramsValues.Clear();
            paramsValues.Add("@trans", trans);
            paramsValues.Add("@idWord", idWord.ToString());

            ExecuteQueryWithParam("insert into translates (wordRU, idWordEn) values (@trans, @idWord)", paramsValues);
            
        }

        public void UpdateWordCategory(string catId, string wordsId)
        {
            paramsValues.Clear();
            paramsValues.Add("@catId", catId);
            paramsValues.Add("@wordsId", wordsId);
            ExecuteQueryWithParam("update words set catId = @catId where id in ( @wordsId )", paramsValues);
        }

        /*******************************************************************************************/
        //запросы к таблице categories
        /*******************************************************************************************/

        public DataTable SelectCategories()
        {
            return LoadData("SELECT c.id, name, count(w.id) as words FROM categories c "
                                           + "LEFT JOIN words w ON w.catId = c.id GROUP BY name");
        }

        public DataTable SelectCategoriesList()
        {
         
                return LoadData("SELECT c.id, name FROM categories c ");
       
        }

        public DataTable SelectCategoriesSettings()
        {
            return LoadData("SELECT c.id, name, isSelected FROM categories c ");
        }

 

 
        public void InsertCategory(string name)
        {
            paramsValues.Clear();
            paramsValues.Add("@name", name);
            
            ExecuteQueryWithParam("insert into categories (name, isSelected) values (@name, 0)", paramsValues);
        }

        public void UpdateCategory(String name, String flag)
        {
            paramsValues.Clear();
            paramsValues.Add("@name", name);
            paramsValues.Add("@flag", flag);
            ExecuteQueryWithParam("update categories set isSelected = @flag where name = @name", paramsValues);
        }

        public void InitDataBase()
        {
            CreateDB();
            CreateTables();
        }

        //создание базы
        private void CreateDB()
        {
            SQLiteConnection.CreateFile("helper.db");
        }

        //создание таблиц
        private void CreateTables()
        {
            //слова 
            ExecuteQuery("create table words (id integer primary key autoincrement, wordEN text, catId int)");
            //переводы
            ExecuteQuery("create table translates (id integer primary key autoincrement, wordRU text, idWordEn int)");
            //категории
            ExecuteQuery("create table categories (id integer primary key autoincrement, name text, isSelected int)");

        }
    }
}
