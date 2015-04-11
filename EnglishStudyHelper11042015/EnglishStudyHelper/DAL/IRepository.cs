using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishStudyHelper.DAL
{
    interface IRepository<T>
        where T : class
    {
        IEnumerable<T> GetListAll();
        T GetById(int id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(T obj);
        
    }
}
