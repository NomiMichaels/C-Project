using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BL
{
    internal class IBL_imp : IBL
    {
        DAL.Idal dal; //אובייקט מסוג מאגר נתונים

        public IBL_imp() //ctor
        {
            dal = DAL.SingeltonDAL.getInstance(); //יצירת מופע של דאל עבור שכבת בי_ל בשיטת הסינגלטון
        }

        public void addTester(Tester addingTester) //בדיקה האם הטסטר נמצא בגיל המתאים והוספתו לרשימה
        {
            foreach (Tester tester in getTesterList())
                if (tester._ID == addingTester._ID)
                    throw new Exception("This tester ID already exists"); 
            if (DateTime.Now.Year - addingTester.birthDate.Year > Configuration.maxTesterAge
               || DateTime.Now.Year - addingTester.birthDate.Year < Configuration.minTesterAge)
                throw new Exception("Tester age is out of range");
            if (DateTime.Now.Year - addingTester.validCertification.Year == 0 && (addingTester.validCertification.DayOfYear - DateTime.Now.DayOfYear  < 0)) 
                throw new Exception("Certification is not valid");
            dal.addTester(addingTester);
        }

        public void updateTester(Tester updated)
        {
            bool found = false;
            foreach (Tester tester in getTesterList())
                if (tester._ID == updated._ID)
                {
                    found = true;
                    break;
                }
            if (!found)
                throw new Exception("This tester ID does not exist");
            dal.updateTester(updated); //משתמש בפונקציה משכבת הדאל
        }

        public void removeTester(Tester removed)
        {
            bool found = false;
            foreach (Tester tester in getTesterList())
                if (tester._ID == removed._ID)
                {
                    found = true;
                    break;
                }
            if (!found)
                throw new Exception("This tester ID does not exist");
            if (removed.futureTests.Count > 0) //במקרה שהטסטר כבר רשום לטסטים נמצא טסטר אחר
            {
                foreach (Test t in removed.futureTests)
                {
                    t.testerID = "";
                    addTest(t);
                }
            }
            dal.removeTester(removed); //משתמש בפונקציה משכבת הדאל
        }

        public List<Tester> getTesterList()
        {
            return dal.getTesterList();
        }


        public void addTrainee(Trainee addingTrainee) //בודק שהתלמיד עוד לא קיים במערכת ושהוא בגיל המתאים
        {
            if (addingTrainee.numOfLessons < Configuration.minLessonNum)
               throw new Exception("not enough lessons taken");
            if (DateTime.Now.Year - addingTrainee.birthDate.Year < Configuration.minTrainieeAge)
               throw new Exception("Trainee is too young");
            foreach (Trainee trainee in getTraineeList())
                if (trainee._ID == addingTrainee._ID)
                    throw new Exception("This trainee ID already exists");
            dal.addTrainee(addingTrainee);
        }

        public void updateTrainee(Trainee updated)
        {
            bool found = false;    //מוודא שהתלמיד לעדכון נמצא במערכת
            foreach (Trainee trainee in getTraineeList())
                if (trainee._ID == updated._ID)
                {
                    found = true;
                    break;
                }
            if (!found)
                throw new Exception("This trainee does ID not exists");  
            dal.updateTrainee(updated);   //משתמש בפונקציה משכבת הדאל
        }

        public void removeTrainee(Trainee removed)
        {
            bool found = false;    //מוודא שהתלמיד לעדכון נמצא במערכת
            foreach (Trainee trainee in getTraineeList())
                if (trainee._ID == removed._ID)
                {
                    removed = trainee;
                    found = true;
                    break;
                }
            if (!found)
                throw new Exception("This trainee does ID not exists");   
            foreach (Test t in removed.TraineeTests)   //מחיקת טסטים עתידיים
            {
                {
                    if (t.testTime > DateTime.Now)
                    {
                        Tester myTester = findTester(t.testerID);
                        foreach (Test test in myTester.futureTests)   //מחיקת טסט של התלמיד הנמחק מהטסטר
                            if (test == t)
                            {
                                myTester.futureTests.Remove(test);
                                break;
                            }
                        removeTest(t);
                    }
                    break;
                }

            }
            dal.removeTrainee(removed);
        }

        public Trainee findTrainee(string traineeID)
        {
            return dal.findTrainee(traineeID);
        }

        public Tester findTester(string testerID)
        {
            return dal.findTester(testerID);
        }

        public List<Trainee> getTraineeList()
        {
            return dal.getTraineeList();
        }

        public bool enoughTimeAndLessons(Test addingTest) //בודקת שעברו 7 ימים בין הטסטים ואם זה הטסט הראשון שלו בודקת שעשה 20 שיעורים
        {
            string traineeID = addingTest.traineeID;
            Trainee myTrainee = findTrainee(traineeID);
            Test lastTest;
            if (myTrainee.numOfTests > 0)
            {
                lastTest = myTrainee.TraineeTests[myTrainee.numOfTests-1];
                if ((addingTest.testTime - lastTest.testTime).Days < Configuration.DaysBetweenTests)
                    return false;
            }
            else
                if (myTrainee.numOfLessons < Configuration.minLessonNum)
                return false;
            return true;
        }

        public bool studentStillLearning(Test addingTest) //עוד לא עבר טסט על סוג רכב זה
        {
            string traineeID = addingTest.traineeID;
            Trainee myTrainee = findTrainee(traineeID);
            bool private_car = false, medium_truck = false;
            foreach (Test T in myTrainee.TraineeTests)
            {
                if (T.vehicleType == VehicleType.רכב_פרטי && T.result)   //בדיקה עם עבר כבר על רכב פרטי
                    private_car = true;
                if (T.vehicleType == VehicleType.משאית_בינונית && T.result)   //בדיקה עם עבר כבר על משאית בינונית
                    medium_truck = true;
                if (T.gearBox == addingTest.gearBox && T.vehicleType == addingTest.vehicleType) 
                    {
                        if (T.result) //כבר עבר טסט כזה
                            return false;
                        else if (DateTime.Now < T.testTime) //כבר נרשם לטסט
                            return false;
                    }
            }
            //בדיקת איררכיית רשיונות
            if (addingTest.vehicleType == VehicleType.משאית_בינונית && private_car)  //על מנת להבחן על משאית בינונית יש להחזיק רשיון רכב פרטי
                return true;
            if (addingTest.vehicleType == VehicleType.משאית_כבדה && medium_truck) //על מנת להבחן על משאית כבדה יש להחזיק רשיון משאית בינוית
                return true;
            if (addingTest.vehicleType == VehicleType.אוטובוס && private_car)   //על מנת להבחן על אוטובוס יש להחזיק רשיון רכב פרטי
                return true;
            if (addingTest.vehicleType == VehicleType.רכב_פרטי || addingTest.vehicleType == VehicleType.אופנוע)   //על מנת להבחן על רכב פרטי או אופנוע אין צורך ברשיון נוסף
                return true;
            return false;
        }

        public bool testerSuitable(Tester t, Test addingTest) //בודק האם הטסטר מתאים מבחינת הקריטריונים
        {
            bool foundGearBox = false, foundVehcleType = false;
            foreach (GearBox g in t.gearBox)
                if (g == addingTest.gearBox) //התאמת סוג תיבת ההילוכים
                {
                    foundGearBox = true;
                    break;
                }
            foreach (VehicleType v in t.vehicleType)
                if (v == addingTest.vehicleType) //התאמת סוג הרכב
                {
                    foundVehcleType = true;
                    break;
                }
            if (foundGearBox && foundVehcleType && t.validCertification >= addingTest.testTime && //בדיקה שהתעודה בתוקף
                DateTime.Now.Year - t.birthDate.Year <= Configuration.maxTesterAge //בדיקה שהוא בגיל המתאים
                    && DateTime.Now.Year - t.birthDate.Year >= Configuration.minTesterAge)
            {
                addingTest.testerID = t._ID;
                return true;
            }
            return false;
        }

        public IEnumerable<Tester> findTesters(Test addingTest) //החזרת הטסטרים שמתאימים מבחינת הקריטריונים והטווח
        {
            var testerList = testersInRange(addingTest.departureAddress).ToList<Tester>(); //רק את מי שבטווח המתאים
            if (testerList.Count == 0)
                throw new Exception ("No testers in range, change test departor address"); //לתפוס חריגה!!

            return (from t in testerList
                   where testerSuitable(t, addingTest) //מי שמתאים לקריטריונים
                   select t).ToList<Tester>();
        }

        public DateTime findNextTime(DateTime testTime)//מביא תאריך חדש לבדיקה
        {
            if (testTime.Hour < 14)
                return new DateTime(testTime.Year, testTime.Month, testTime.Day, testTime.Hour + 1, 0, 0);
            if (testTime.DayOfWeek != DayOfWeek.Thursday)
                return new DateTime(testTime.Year, testTime.Month, testTime.Day+1, 9, 0, 0);
            else return new DateTime(testTime.Year, testTime.Month, testTime.Day + 3, 9, 0, 0);
        }

        public Test findTest(Test addingTest)
        {
            /// בדיקה שהנבחן מתאים לטסט
            if (!enoughTimeAndLessons(addingTest)) 
                throw new Exception("Trainee can not get tested yet"); 
            if (!studentStillLearning(addingTest))
                throw new Exception("Trainee can not book a test"); 

            /// מציאת טסטר מתאים
            var testerSuitableList = findTesters(addingTest);
            int count = 0; 
            foreach (Tester t in testerSuitableList) //סופר כמה טסטרים ברשימה
                count++;
            if (count == 0) //בדיקה שקיימים טסטרים מתאימית
                throw new Exception("No suitable tester"); 
            bool foundTester = false;
            while (!foundTester) //חיפוש בוחן לתאריך, אם לא מצאו מציאים תאריך חדש
            {
                foreach (Tester t in testerSuitableList) 
                {
                    if (checkTesterBusy(t, addingTest.testTime) &&
                        checkAvailableTestersList(t, addingTest.testTime))
                    {
                        addingTest.testerID = t._ID;
                        foundTester = true;
                        return addingTest;
                    }
                }
                addingTest.testTime = findNextTime(addingTest.testTime);
            }
            return addingTest;
        }

        public void addTest(Test addingTest)
        {

            DateTime original = new DateTime();
            original = addingTest.testTime;
            Test myTest = findTest(addingTest);
            if (myTest.testTime != original) //במקרה שנקבע תאריך אחר לטסט
                throw new Exception("" + myTest.testTime);
            addingTest.testID = Configuration.testIDcounter++;
            Tester tester = findTester(addingTest.testerID);
            tester.futureTests.Add(myTest); //מוסיף לרשימת הטסטים של הטסטר את הטסט הנוכחי
            Trainee trainee = findTrainee(addingTest.traineeID);
            trainee.TraineeTests.Add(myTest); //מוסיף לרשימת הטסטים של התלמיד את הטסט הנוכחי
            trainee.numOfTests++; //מעדכן שעשה עוד טסט
            dal.addTest(myTest); //מוסיף את הטסט הנוכחי לרשימת הטסטים הכללית
        }
        
        public void updateTest(TestFeedback testFeedback, Test test)  //עדכון תוצאות הטסט
        {
            test.keepingDistance = testFeedback.keepingDistance;
            test.reverseParking = testFeedback.reverseParking;
            test.lookingAtMirrors = testFeedback.lookingAtMirrors;
            test.signaling = testFeedback.signaling;
            test.stopingForPedestrians = testFeedback.stopingForPedestrians;
            test.intersection = testFeedback.intersection;
            test.rightOfWay = testFeedback.rightOfWay;
            test.appropriateSpeed = testFeedback.appropriateSpeed;
            test.controlOfGearBox = testFeedback.controlOfGearBox;

            if (test.keepingDistance && test.reverseParking && test.lookingAtMirrors && test.signaling && test.stopingForPedestrians && test.intersection
                && test.rightOfWay && test.appropriateSpeed && test.controlOfGearBox) //אם עבר בהצלחה הכל אז עבר את הטסט
                test.result = true;
            test.testerNote = testFeedback.testerNote;
            dal.updateTest(test); 

            Tester tester = findTester(test.testerID);   //הורדת טסט שכבר ציון מרשימת טסטים עתידיים&&
            foreach (Test t in tester.futureTests)
                if (t.testID == test.testID)
                {
                    tester.futureTests.Remove(t);
                    break;
                }
          }

        public void removeTest(Test removed)
        {
            dal.removeTest(removed);
        }

        public Test searchTest(int testID)
        {
            return dal.findTest(testID);
        }

        public List<Test> getTestList()
        {
            return dal.getTestList();
        }


        public bool checkTesterInRange(Tester T) //פונקציית עזר אם בולייני לבדיקת מרחק הטסטר ממוצא הטסט
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            //if(t.address - departureAddress<=t.MaxDistenceToTest) לעתיד כשנשתש בגוגל מפות
            int distence = rand.Next(0, 70);
            if (distence <= T.MaxDistenceToTest) //בודק שהמרחק עומד בתנאי הטסטר
                return true;
            else return false;

        }

        public IEnumerable<Tester> testersInRange(Address departureAddress) //מחזירה רשימה של כל הטסטרים שנמצאים במרחק המתאים
        {
            Func<Tester, bool> predicate = checkTesterInRange; //predicate and FUNC שימוש ב
            return getTesterList().Where<Tester>(predicate);
        }

        public bool checkTesterBusy(Tester T, DateTime dateTime) //בודק אם הטסטר פנוי באותו הזמן ולא עבר את מכסת הטסטים השבועית
        {
            int sundayDate = dateTime.Day - (int)dateTime.DayOfWeek; //התאריך פחות היום בשבוע נותן את התאריך של יום ראשון באותו שבוע
            int thursdayDate = sundayDate + 5;
            int testCounter = 0;
            if (T.futureTests.Count != 0) //אם יש לטסטר עוד טסטים
            {
                foreach (Test test in T.futureTests)
                {
                    if (test.testTime == dateTime) //אם יש לטסטר כבר מבחן אחר בשעה זו
                        return false;
                    else if (test.testTime.Day >= sundayDate && test.testTime.Day <= thursdayDate)
                        testCounter++; //סופר כמה טסטים יש לטסטר בשבוע של המועד הרצוי
                }
            }
             if (T.MaxTestPerWeek > testCounter) //בודק שלא חורגים ממכסת הטסטים
                return true;
            return false;
        }

        public bool checkAvailableTestersList(Tester t, DateTime d) //בודק האם זמין בשעה הזאת והאם זה נמצא בשעות עבודה
        {
            int day = (int)d.DayOfWeek; //הימים מחולקים מ0 עד 6
            int hour = d.Hour - 9;
            if (day < 0 || day > 4) //בדיקה האם המועד הרצוי הוא בימי עבודה
                throw new Exception ("Not a work day"); 
            if (hour < 0 || hour > 5) //בדיקה האם המועד הרצוי הוא בשעות עבודה
                throw new Exception ("Not in work hours"); 
            if (t.scedule[hour,day])
                return true;
            return false;
        }

        public IEnumerable<Tester> availableTesters(DateTime dateTime) //מחזירה את הבוחנים הפנויים במועד הרצוי
        {
            checkTesterBusyDel myDelegate1 = new checkTesterBusyDel(checkTesterBusy); //רישום הפונקציה שלנו לדיליגייט
            checkTesterBusyDel myDelegate2 = new checkTesterBusyDel (checkAvailableTestersList);
            return (from t in getTesterList()
                   where myDelegate1(t, dateTime) && myDelegate2(t, dateTime)  //כל מי שלא עובר את המכסה השבועית ועובד בזמן הזה
                   select t).ToList<Tester>();
        }

        public IEnumerable<Test> specificTests(conditionTest condition) //מחזירה את כל המבחנים העומדים בתנאי שנשלח
        {
            return (from t in getTestList()
                   where condition(t)
                   select t).ToList<Test>();
        }

        public int numOfTest(Trainee trainee) //מחזירה את מספר הטסטים שעשה
        {
            return trainee.numOfTests;
        }

        public bool entitleToLicense(Trainee trainee) //בודק האם זכאי לרישיון
        {
            foreach (Test t in trainee.TraineeTests) //עובר על כל הטסטים של התלמיד ובודק אם עבר בסוג הרכב הרצוי
                if (t.gearBox == trainee.gearBox && t.result)
                    return true;
            return false;
        }

        public int numberOfStudentsOnTwoWeels()
        {
            var s = from item in getTraineeList()
                    let fullName = item.firstName + item.lastName
                    where (item.vehicleType == VehicleType.אופנוע)
                    select new { name = fullName };
            int counter = 0;
            foreach (var item in s) 
            {
                counter++;
            }
            return counter;
        }

        public IEnumerable<object> testerDayScedule(DateTime date)
        {
            var s = from tester in getTesterList()
                    from test in tester.futureTests
                    where (date.DayOfYear == test.testTime.DayOfYear && date.Year == test.testTime.Year) //בוחר את הטסטים שיהיו היום
                    select new { tester = tester.firstName+" "+tester.lastName, testTime = test.testTime.Hour, address = test.departureAddress };
            return s;                 
        }

        public List<Tester> withinMonthExpiredTesterCertification()
        {
            return getTesterList().FindAll
                (T => (T.validCertification - DateTime.Today).TotalDays <= 30); //ביטוי למבדה המחזיר אם רישיון הטסטר פג תוקף ב30 יום הקרובים
            
        }

       public List<Tester> testersThatRetireThisYear()
        {
            return getTesterList().FindAll
                 (T => (DateTime.Today.Year- T.birthDate.Year) >= Configuration.maxTesterAge);   // ביטוילמבדה שבודק אם הטסטר מגיע לגיל הפרישה השנה
        }

        public IEnumerable<Test> futureTest() //מחזיר את רשימת הטסטים העתידיים בסדר ממוין יום/חודש
        {
            return (from test in getTestList()
                   where test.testTime > DateTime.Now //שהתאריך גדול מהתאריך של היום
                   orderby test.testTime.Month, test.testTime.Day //ממיין לפי חודש ואז יום
                   select test).ToList<Test>();
        }

        /*אנחנו הגדרנו את סוג תיבת ההילוכים של הטסטר כרשימה (כי 
         *  הגיוני שהוא יתמחה בכמה סוגים) ולכן פונקציה זו אינה רלונטית לנו*/
        //public IEnumerable<IGrouping<GearBox, Tester>> testersByExpertise(bool ifSort = false) //מחלקת את רשימת הבוחנים לפי ההתמחות שלהם
        //{
        //    if (!ifSort)
        //    {
        //       return from item in getTesterList()
        //               orderby item.gearBox //ממיין לפי הא"ב את סוג ההתמחות
        //               group item by item.gearBox; //מחלק לקבוצות לפי ההתמחות
        //    }
        //    else return from item in getTesterList()
        //                orderby item.gearBox, item.lastName //ממיין לפי השם משפחה וסוג ההתמחות
        //                group item by item.gearBox; // מחלק לקבוצות לפי ההתמחות
        //}

        public IEnumerable<IGrouping<string, Trainee>> traineesBySchool(bool ifSort = false) //מיון התלמידים ע"פ בית ספר לנהיגה
        {
            if (!ifSort)
            {
                return from item in getTraineeList()
                       orderby item.schoolName
                       group item by item.schoolName;
            }
            else return from item in getTraineeList()
                        orderby item.schoolName, item.lastName 
                        group item by item.schoolName;
        }

        public IEnumerable<IGrouping<string, Trainee>> traineesByTeacher(bool ifSort = false) //ממין את התלמידים לפי המורה נהיגה
        {
            if (!ifSort)
            {
                return from item in getTraineeList()
                       orderby item.teacherName
                       group item by item.teacherName;
            }
            else return from item in getTraineeList()
                        orderby item.teacherName, item.lastName
                        group item by item.teacherName;
        }

        public IEnumerable<IGrouping<int, Trainee>> traineesByTestAmount(bool ifSort = false) //ממין את התלמידים לפי מספר הטסטים
        {
            if (!ifSort)
            {
                return from item in getTraineeList()
                       orderby item.numOfTests
                       group item by item.numOfTests;
            }
            else return from item in getTraineeList()
                        orderby item.numOfTests, item.lastName
                        group item by item.numOfTests;
        }

        public float getTesterRating(Tester tester)
        {
            return tester.rating.sumOfRatings / tester.rating.numOfRaters; //מחזיר את סכום הדירוגים חלקי מספר המדרגים
        }

        public void RateTester(Test test, int traineeRating)
        {
            if (traineeRating > 5 || traineeRating < 0)
                throw new Exception("Rating is out of range");
            Tester tester = findTester(test.testerID);
            tester.rating.sumOfRatings += traineeRating;
            tester.rating.numOfRaters++;

        }

    }
}
