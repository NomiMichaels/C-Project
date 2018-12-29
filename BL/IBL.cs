using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BL
{
    /// <summary>
    /// הצהרות על הדילגייטים
    /// </summary>
    public delegate bool checkTesterBusyDel(Tester T, DateTime D);
    public delegate bool conditionTest(Test T);

    public interface IBL
    {

        /// <summary>
        /// הוספת טסטר
        /// </summary>
        /// <param name="addingTester">הטסטר החדש שרוצים להוסיף </param>
        void addTester(Tester addingTester);
        /// <summary>
        /// עדכון פרטי הטסטר
        /// </summary>
        /// <param name="updated">טסטר מעודכן</param>
        void updateTester(Tester updated);
        /// <summary>
        /// מחיקת טסטר
        /// </summary>
        /// <param name="removed">טסטר למחיקה</param>
        void removeTester(Tester removed);
        /// <summary>
        /// מציאת טסטר
        /// </summary>
        /// <param name="testerID">תז הטסטר</param>
        /// <returns>טסטר מבוקש</returns>
        Tester findTester(string testerID);
        /// <summary>
        /// קבלת רשימת הטסטרים
        /// </summary>
        /// <returns>רשימת הטסטרים</returns>
        List<Tester> getTesterList();
        

        /// <summary>
        /// הוספת תלמיד
        /// </summary>
        /// <param name="addingTrainee">התלמיד שרוצים להוסיף</param>
        void addTrainee(Trainee addingTrainee);
        /// <summary>
        /// מעדכן את פרטי התלמיד
        /// </summary>
        /// <param name="updated">תלמיד מעודכן</param>
        void updateTrainee(Trainee updated);
        /// <summary>
        /// מחיקת תלמיד
        /// </summary>
        /// <param name="remove">תלמיד למחיקה</param>
        void removeTrainee(Trainee remove);
        /// <summary>
        /// מציאת תלמיד
        /// </summary>
        /// <param name="traineeID">תז התלמיד</param>
        /// <returns>תלמיד מבוקש</returns>
        Trainee findTrainee(string traineeID);
        /// <summary>
        /// קבלת רשימת התלמידים
        /// </summary>
        /// <returns>רשימת התלמידים</returns>
        List<Trainee> getTraineeList();

        //קריטריונים להוספת טסט
        /// <summary>
        /// בודק שעברו 7 ימים בין הטסטים ונעשו 20 שיעורים
        /// </summary>
        /// <param name="addingTest">הטסט להוספה</param>
        /// <returns>אם ניתן להוסיף או לא</returns>
        bool enoughTimeAndLessons(Test addingTest);
        /// <summary>
        /// עוד לא עבר טסט על סוג רכב זה
        /// </summary>
        /// <param name="addingTest">הטסט להוספה</param>
        /// <returns>האם ניצן להוסיף או לא</returns>
        bool studentStillLearning(Test addingTest);
        /// <summary>
        /// בודק האם הטסטר מתאים לטסט מבחינת הקריטריונים
        /// </summary>
        /// <param name="t">טסטר לבדיקה</param>
        /// <param name="addingTest">טסט להוספה</param>
        /// <returns>האם הטסטר מתאים לטסט או לא</returns>
        bool testerSuitable(Tester t, Test addingTest);
        /// <summary>
        /// קבוצת הטסטרים שמתאימים מבחינת הקריטריונים והטווח
        /// </summary>
        /// <param name="addingTest">הטסט להוספה</param>
        /// <returns>קבוצת הטסרים המתאימים</returns>
        IEnumerable<Tester> findTesters(Test addingTest);
        /// <summary>
        /// מביא תאריך העוקב לקביעת טסט
        /// </summary>
        /// <param name="testTime">התאריך הקודם</param>
        /// <returns>התאריך העוקב</returns>
        DateTime findNextTime(DateTime testTime);
        /// <summary>
        /// בודק שהתלמיד כשיר להבחן ומוצא טסטר
        /// </summary>
        /// <param name="addingTest">טסט להוספה</param>
        /// <returns>הטסט הסופי עם הפרטים המעודכנים</returns>
        Test findTest(Test addingTest);
        /// <summary>
        /// מוסיף טסט ומעדכן את הגורמים הרלוונטים
        /// </summary>
        /// <param name="addingTest">טסט להוספה</param>
        void addTest(Test addingTest);

        /// <summary>
        /// עדכון תוצאות הטסט
        /// </summary>
        /// <param name="updatingTest">משוב הטסטר</param>
        /// <param name="test">הטסט לעדכון</param>
        void updateTest(TestFeedback testFeedback, Test test);
        /// <summary>
        /// מחיקת טסט
        /// </summary>
        /// <param name="removed">הטסט למחיקה</param>
        void removeTest(Test removed);
        /// <summary>
        /// חיפוש טסט לפי ת.ז.
        /// </summary>
        /// <param name="testID">ת.ז. הטסט</param>
        /// <returns>הטסט המבוקש</returns>
        Test searchTest(int testID);
        /// <summary>
        /// קבלת רשימת כל הטסטים
        /// </summary>
        /// <returns>רשימת הטסטים</returns>
        List<Test> getTestList();


        /// <summary>
        /// פונקציית עזר לבדיקת המרחק המתאים בין הטסטר למוצא המבחן
        /// </summary>
        /// <param name="T">הטסטר שרוצים לבדוק אצלו</param>
        /// <returns>אם במרחק או לא</returns>
        bool checkTesterInRange(Tester T);
        /// <summary>
        /// פונקציה שמחזירה את כל הטסטרים שבמרחק המתאים
        /// </summary>
        /// <param name="departureAddress">מוצא הטסט</param>
        /// <returns>הטסטרים המתאימים</returns>
        IEnumerable<Tester> testersInRange(Address departureAddress);

        /// <summary>
        /// פונקצית עזר שבודקת אם הטסטר פנוי באותו הזמן ולא עבר את מכסת הטסטים השבועית
        /// </summary>
        /// <param name="T">הטסטר הנבדק</param>
        /// <param name="dateTime">המועד הרצוי</param>
        /// <returns>האם פנוי או לא</returns>
        bool checkTesterBusy(Tester T, DateTime dateTime);
        /// <summary>
        /// פונקציית עזר שבודקת האם זמין בשעה הזאת והאם זה נמצא בשעות עבודה
        /// </summary>
        /// <param name="t">הטסטר הרצוי</param>
        /// <param name="d">הזמן הרצוי</param>
        /// <returns></returns>
        bool checkAvailableTestersList(Tester t, DateTime d);
        /// <summary>
        /// מחזירה את הטסטרים הפנויים במועד הרצוי
        /// </summary>
        /// <param name="dateTime">המועד הרצוי</param>
        /// <returns>הטסטרים הפנויים</returns>
        IEnumerable<Tester> availableTesters(DateTime dateTime);

        /// <summary>
        /// מחזירה את כל המבחנים העומדים בתנאי שנשלח
        /// </summary>
        /// <param name="condition">התנאי הרצוי</param>
        /// <returns>כל המבחנים העומדים בתנאי</returns>
        IEnumerable<Test> specificTests(conditionTest condition);
        /// <summary>
        ///  מחזירה את מספר הטסטים שעשה התלמיד
        /// </summary>
        /// <param name="trainee">התלמיד אצלו בודקים</param>
        /// <returns>מספר הטסטים שעשה</returns>
        int numOfTest(Trainee trainee);
        /// <summary>
        /// בודק האם זכאי לרישיון
        /// </summary>
        /// <param name="trainee">התלמיד הנבדק</param>
        /// <returns>האם זכאי או לא</returns>
        bool entitleToLicense(Trainee trainee);
        /// <summary>
        /// מחזיר את רשימת הטסטים העתידיים בסדר ממוין יום/חודש
        /// </summary>
        /// <returns>רשימת הטסטים</returns>
        IEnumerable<Test> futureTest();

       /// <summary>
        /// מספר התלמידים שלומדים על אופנוע
        /// </summary>
        /// <returns>מספר התלמידים</returns>
       int numberOfStudentsOnTwoWeels();
        /// <summary>
        /// יוצר אוסף של כל הטסטרים שיהיו באותו יום
        /// </summary>
        /// <param name="date">יום מבוקש</param>
        /// <returns>אוסף הטסטים</returns>
        IEnumerable<object> testerDayScedule(DateTime date);
        /// <summary>
        /// בודק את כל הטסטרים שרישיון הטסטר שלהם פג תוקף ב30 יום הקרובים
        /// </summary>
        /// <returns>רשימת הטסטרים</returns>
        List<Tester> withinMonthExpiredTesterCertification();
        /// <summary>
        /// בודק אלו טסטרים מגיעים לגיל הפרישה השנה
        /// </summary>
        /// <returns>רשימת הטסטרים</returns>
        List<Tester> testersThatRetireThisYear();


        /// <summary>
        /// מחלקת את הטסטרים לפי ההתמחות שלהם
        /// </summary>
        /// <param name="ifSort">האם למיין את הקבוצות המחולקות</param>
        /// <returns>קבוצות הטסטרים מחולקים</returns>
        //  IEnumerable<IGrouping<GearBox, Tester>> testersByExpertise(bool ifSort = false); //במימוש יש הסבר למה זה בירוק
        /// <summary>
        /// חלוקת התלמידים ע"פ בית ספר לנהיגה
        /// </summary>
        /// <param name="ifSort">האם למיין את הקבוצות המחולקות</param>
        /// <returns>קבוצות התלמידים מחולקים</returns>
        IEnumerable<IGrouping<string, Trainee>> traineesBySchool(bool ifSort = false);
        /// <summary>
        /// מחלק את התלמידים לפי המורה נהיגה
        /// </summary>
        /// <param name="ifSort">האם למיין את הקבוצות המחולקות</param>
        /// <returns>קבוצות התלמידים המחולקות</returns>
        IEnumerable<IGrouping<string, Trainee>> traineesByTeacher(bool ifSort = false);
        /// <summary>
        /// מחלק את התלמידים לפי מספר הטסטים
        /// </summary>
        /// <param name="ifSort">האם למיין את הקבוצות המחולקות</param>
        /// <returns>קבוצות התלמידים המחולקות</returns>
        IEnumerable<IGrouping<int, Trainee>> traineesByTestAmount(bool ifSort = false);
        
        /// <summary>
        /// מחשב את הדירוג של הטסטר
        /// </summary>
        /// <param name="tester">הטסטר המבוקש</param>
        /// <returns>הדירוג של הטסטר</returns>
        float getTesterRating(Tester tester);
        /// <summary>
        /// עדכון הדירוג
        /// </summary>
        /// <param name="test">המבחן שבו בחן הטסטר</param>
        /// <param name="traineeRating">הדירוג של התלמיד</param>
        void RateTester(Test test, int traineeRating);
    }
}
