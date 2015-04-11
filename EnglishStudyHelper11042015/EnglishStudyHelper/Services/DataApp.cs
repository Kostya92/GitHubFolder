using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SQLite;
using EnglishStudyHelper.Entities;
using EnglishStudyHelper.DAL;


namespace EnglishStudyHelper.Services
{
    public interface IDataApp
    {
        List<Word> Words { get; set; }
        List<Category> Categories { get; set; }
    }

    public class DataApp: IDataApp
    {
        private WordsRepo _wordsRepo = new WordsRepo();
        private CategoriesRepo _categoriesRepo = new CategoriesRepo();
        
        public List<Word> Words { get; set; }
        public List<Category> Categories { get; set; }

        DataApp()
        {
     
            Words = _wordsRepo.GetListAll().ToList();
            Categories = _categoriesRepo.GetListAll().ToList();
        }
    }
}
