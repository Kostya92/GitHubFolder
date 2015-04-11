using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace EnglishStudyHelper
{
    /*
     * класс - библиотека функций, проверяющих ввод (для данного приложения понадобилась всего одна)
     */
    class Validator
    {
       public enum Alphabets { Ru, En };


        /*
         * проверяет, что строка сожержит только буквы соответствующего алфавита
         * string word - строка для проверки
         * string alphabet - строка идетификатор алфивита, может принимать значения из перечисления Alphabets
         * out string errorMessage - выходной параметр, срока сообщения об ошибке
         */
        public static bool ValidText(string word, Alphabets alphabet, out string errorMessage)
        {
            if (String.IsNullOrEmpty(word))
            {
                errorMessage = "Текст обязательный";
                return false;
            }

         
                string regEx = "";

                if (alphabet == Alphabets.Ru)
                    regEx = "^[А-Яа-я]+$";
                else if (alphabet == Alphabets.En)
                    regEx = "^[A-Za-z]+$";

                if (Regex.IsMatch(word, regEx))
                {
                    errorMessage = String.Empty;
                    return true;
                }
            


            errorMessage = "Слово должно состоять только из " + alphabet +" алфавита";
            return false;
        }
    }
}
