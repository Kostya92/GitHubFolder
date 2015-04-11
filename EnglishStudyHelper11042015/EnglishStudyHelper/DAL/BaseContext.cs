using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishStudyHelper.DAL
{
    public class BaseContext
    {
        protected string ConnectionString = Properties.Settings.Default.connectionString;
    }
}
