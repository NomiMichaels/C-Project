using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    internal class Dal_imp : Idal //מימוש הפונקציות ברשימות
    {
        public Dal_imp()
        {
            DataSource.testerList = new List<Tester> ();
            DataSource.traineeList = new List<Trainee> ();
            DataSource.testList = new List<Test> ();
        }

        public void addTester(Tester addingTester)
        {
           
            int index = DataSource.testerList.FindIndex(T => T._ID == addingTester._ID);
            if (index == -1)
                DataSource.testerList.Add(addingTester);
            else throw new Exception ("This tester ID already exists");    
        }


        public void removeTester(Tester removingTester)
        {
            if (!DataSource.testerList.Remove(removingTester)) //פונקציה בוליאנית שמחזירה 0 כשלא נמצא
                throw new Exception ("This tester ID does not exists");   
        }

        public void updateTester(Tester UpdatingTester)
        {
            int index = DataSource.testerList.FindIndex(T => T._ID == UpdatingTester._ID); //עושה חיפוש ברשימה ע"י ביטוי למבדה שבודק איפה הטסטר נמצא
            if (index == -1) //במקרה שלא מצא אותו בכל הרשימה
                throw new Exception  ("This tester does not exists");   
            UpdatingTester.futureTests = DataSource.testerList[index].futureTests;   
            DataSource.testerList[index] = UpdatingTester; 
        }

        public Tester findTester(string testerID)
        {
            int index = DataSource.testerList.FindIndex(T => T._ID == testerID); //עושה חיפוש ברשימה ע"י ביטוי למבדה שבודק איפה הטסטר נמצא
            if (index == -1) //במקרה שלא מצא אותו בכל הרשימה
                throw new Exception ("This trainee does not exists");   
            else return DataSource.testerList[index];
        }


        public void addTrainee(Trainee addingTrainee)
        {
            int index = DataSource.traineeList.FindIndex(T => T._ID == addingTrainee._ID);
            if (index == -1)
                DataSource.traineeList.Add(addingTrainee);
            else throw new Exception  ("This trainee already exists");  
        }

        public void removeTrainee(Trainee removingTrainee)
        {
            if (!DataSource.traineeList.Remove(removingTrainee)) 
                throw new Exception("Traine does not excist"); 
        }

        public void updateTrainee(Trainee UpdatingTrainee)
        {
            int index = DataSource.traineeList.FindIndex(T => T._ID == UpdatingTrainee._ID); //עושה חיפוש ברשימה ע"י ביטוי למבדה שבודק איפה התלמיד נמצא
            if (index == -1) //במקרה שלא מצא אותו בכל הרשימה
                throw new Exception  ("This trainee ID does not exists");   
            DataSource.traineeList[index]._ID = UpdatingTrainee._ID;
            DataSource.traineeList[index].lastName = UpdatingTrainee.lastName;
            DataSource.traineeList[index].firstName = UpdatingTrainee.firstName;
            DataSource.traineeList[index].BirthDate = UpdatingTrainee.BirthDate;
            DataSource.traineeList[index].gender = UpdatingTrainee.gender;
            DataSource.traineeList[index].PhoneNum = UpdatingTrainee.PhoneNum;
            DataSource.traineeList[index].address = UpdatingTrainee.address;
            DataSource.traineeList[index].vehicleType = UpdatingTrainee.vehicleType;
            DataSource.traineeList[index].gearBox = UpdatingTrainee.gearBox;
            DataSource.traineeList[index].schoolName = UpdatingTrainee.schoolName;
            DataSource.traineeList[index].teacherName = UpdatingTrainee.teacherName;
            DataSource.traineeList[index].NumOfLessons = UpdatingTrainee.NumOfLessons;
        }

        public Trainee findTrainee(string traineeID)   //פונקציה שמחזירה את הנבחן על פי מספר הזהות שלו
        {
            int index = DataSource.traineeList.FindIndex(T => T._ID == traineeID); //עושה חיפוש ברשימה ע"י ביטוי למבדה שבודק איפה התלמיד נמצא
            if (index == -1) //במקרה שלא מצא אותו בכל הרשימה
                throw new Exception  ("This trainee does not exists");  
            else return DataSource.traineeList[index];
        }
    
        public void addTest(Test addingTest)
        {
            int index = DataSource.testList.FindIndex(T => T.testID == addingTest.testID);
            if (index == -1)
            {
                DataSource.testList.Add(addingTest);
            }
            else throw new Exception("This test already exists");   
        }

        public void updateTest(Test UpdatingTest)
        {
            int index = DataSource.testList.FindIndex(T => T.testID== UpdatingTest.testID); //עושה חיפוש ברשימה ע"י ביטוי למבדה שבודק איפה הטסט נמצא
            if (index == -1) //במקרה שלא מצא אותו בכל הרשימה
                throw new Exception("This test does not exists");   
            DataSource.testList[index] = UpdatingTest;
        }
        public void removeTest(Test removedTest)
        {
            if (!DataSource.testList.Remove(removedTest)) //פונקציה בוליאנית שמחזירה 0 כשלא נמצא
                throw new Exception("This test does not exists");   
        }

        public Test findTest(int testID)
        {
            int index = DataSource.testList.FindIndex(T => T.testID == testID); //עושה חיפוש ברשימה ע"י ביטוי למבדה שבודק איפה התלמיד נמצא
            if (index == -1) //במקרה שלא מצא אותו בכל הרשימה
                throw new Exception("This test does not exists");   
            else return DataSource.testList[index];
        }

        public List<Tester> getTesterList()
        {
            List<Tester> copyTesterList = new List<Tester> (DataSource.testerList);
            return copyTesterList;
        }


        public List<Trainee> getTraineeList()
        {
            List<Trainee> copyTraineeList = new List<Trainee> (DataSource.traineeList);
            return copyTraineeList;
        }

        public List<Test> getTestList()
        {
            List<Test> copytestList = new List<Test>(DataSource.testList);
            return copytestList;
        }
    }
}
