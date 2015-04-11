using System;
using System.Collections.Generic;
using System.Linq;


namespace EnglishStudyHelper.Entities
{
    public class Word
    {
        public int WordId { get; set; }
        public string WordName { get; set; }
        public int TranslateId { get; set; }
        public string Translate { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    

        public Word() { }

        public Word(int id, string wordName, int transId, string translate, int categoryId, string categoryName) 
        {
            this.WordId = id;
            this.WordName = wordName;
            this.TranslateId = transId;
            this.Translate = translate;
            this.CategoryId = categoryId;
            this.CategoryName = categoryName;
        
            
        }

        public Word(string wordName, int transId, int categoryId) : this(0, wordName, transId, string.Empty, categoryId, string.Empty) { } 

     
    }


}
