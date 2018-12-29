using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SingeltonDAL // קבלת מופע של שכבת הדל, ככה לא נצטרך לדעת במה הימדע שמור ונשתמש במשתנה כללי
    {
        public static Idal instance = null;

        public static Idal getInstance()
        {
            if (instance == null) //אם עוד לא הגדרנו אחד כזה
                instance = new Dal_imp();
            return instance;
        }
        
    }
}
