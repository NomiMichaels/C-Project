using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public interface Idal
    {
        /// <summary>
        /// הוספת טסטר
        /// </summary>
        /// <param name="addingTester">הטסטר שרוצים להוסיף</param>
        void addTester(Tester addingTester);
        /// <summary>
        /// מחיקת טסטר
        /// </summary>
        /// <param name="removingTester">הטסטר למחיקה</param>
        void removeTester(Tester removingTester);
        /// <summary>
        /// עידכון טסטר
        /// </summary>
        /// <param name="UpdatingTester">הטסטר לעידכון</param>
        void updateTester(Tester UpdatingTester);
        /// <summary>
        /// חיפוש טסטר
        /// </summary>
        /// <param name="testerID">הטסטר שמחפשים</param>
        /// <returns></returns>
        Tester findTester(string testerID);

        /// <summary>
        /// הוספת תלמיד
        /// </summary>
        /// <param name="addingTrainee">הסטודנט להוספה</param>
        void addTrainee(Trainee addingTrainee);
        /// <summary>
        /// מחיקת תלמיד
        /// </summary>
        /// <param name="removingTrainee">התלמיד למחיקה</param>
        void removeTrainee(Trainee removingTrainee);
        /// <summary>
        /// עדכון תלמיד
        /// </summary>
        /// <param name="UpdatingTrainee">התלמיד לעדכון</param>
        void updateTrainee(Trainee UpdatingTrainee);
        /// <summary>
        /// חיפוש תלמיד
        /// </summary>
        /// <param name="traineeID">התלמיד לחיפוש </param>
        /// <returns></returns>
        Trainee findTrainee(string traineeID);

        /// <summary>
        /// הוספת טסט
        /// </summary>
        /// <param name="addingTest">הטסט להוספה</param>
        void addTest(Test addingTest);
        /// <summary>
        /// עידכון טסט
        /// </summary>
        /// <param name="UpdatingTest">הטסט לעדכון</param>
        void updateTest(Test UpdatingTest);
        /// <summary>
        /// מחיקת טסט
        /// </summary>
        /// <param name="removedTest">טסט למחיקה</param>
        void removeTest(Test removedTest);
        /// <summary>
        /// חיפוש טסט
        /// </summary>
        /// <param name="testID"> מספר הטסט המבוקש</param>
        /// <returns>הטסט המבוקש</returns>
        Test findTest(int testID);

        /// <summary>
        /// קבלת רשימת הטסטרים
        /// </summary>
        /// <returns>רשימת הטסטרים</returns>
        List<Tester> getTesterList();
        /// <summary>
        /// קבלת רשימת התלמידים
        /// </summary>
        /// <returns>שימת התלמידים</returns>
        List<Trainee> getTraineeList();
        /// <summary>
        /// קבלת רשימת התלמידים
        /// </summary>
        /// <returns>רשימת התלמידים</returns>
        List<Test> getTestList();
    }
}
