using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Configuration //מכיל את כל המשתנים הגלובלים כשדות סטטיים
    {
        public static readonly int minLessonNum = 20;
        public static readonly int maxTesterAge = 65;
        public static readonly int minTesterAge = 40;
        public static readonly int minTrainieeAge = 18;
        public static readonly int DaysBetweenTests = 7;
        public static int testIDcounter = 10000000;
    }
}
