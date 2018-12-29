using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    /// <summary>
    /// מבנה שמכיל את הדירוג של הטסטר ע"י כל הנבחנים שלו
    /// </summary>
    public struct TesterRating
    {
        public float sumOfRatings { get; set; }  //סכום הדרוג
        public float numOfRaters { get; set; }  //מספר מדרגים

        public TesterRating(int num1 = 0, int num2 = 0)
        {
            sumOfRatings = num1;
            numOfRaters = num2;
        }
    }
}
