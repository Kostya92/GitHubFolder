using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace EnglishStudyHelper
{
    //структура - параметр ф-ции
   // [StructLayout(LayoutKind.Sequential)]

    public struct LASTINPUTINFO
    {

        public uint cbSize;

        //время последней активности юзера
        public uint dwTime;

    }

    //импортирум неупарвляемую ф-цию GetLastInputInfo
    class InactiveTimeCalculator
    {
        [DllImport("user32.dll")]

        static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        //возвращает промежуток времени между временем последней активности юзера
        //и текущим системным

        public TimeSpan? GetInactiveTime()
        {

            LASTINPUTINFO info = new LASTINPUTINFO();

            info.cbSize = (uint)Marshal.SizeOf(info);

            if (GetLastInputInfo(ref info))

                return 
                    TimeSpan.FromMilliseconds(Environment.TickCount - info.dwTime);

            else

                return null;

        }
    }
}
