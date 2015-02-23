using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnglishStudyHelper
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //предотвращение запуска второго экземпляра приложения
            using (Mutex mutex = new Mutex(false, applicationGuid))
            {
                if (!mutex.WaitOne(0, false))
                {
                    MessageBox.Show("Программа уже запущена!!!");
                    return;
                }


                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormMain());
            }


        }

        //уникальный идентификатор приложения
        private static string applicationGuid = "fc096a36-433c-48be-9189-1de10433b0a9";
    }

 
}
