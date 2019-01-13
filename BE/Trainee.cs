using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Trainee //תלמיד נהיגה
    {
        public Trainee() //בנאי ברירת מחדל
        {
            traineeTests = new List<Test>();
            numOfTests = 0;
            birthDate = new DateTime(2000, 1, 1);
        }
        public Trainee(string myID, string myLastName, string myFirstName
            , DateTime myBirthDate, Gender myGender, string myPhoneNum, Address myAddress,
            VehicleType myVehicleType, GearBox myGearBox, string mySchoolName,
            string myTeacherName, int myNumOfLessons)
        {
            _ID = myID;
            lastName = myLastName;
            firstName = myFirstName;
            birthDate = myBirthDate;
            gender = myGender;
            phoneNum = myPhoneNum;
            address = myAddress;
            vehicleType = myVehicleType;
            gearBox = myGearBox;
            schoolName = mySchoolName;
            teacherName = myTeacherName;
            numOfLessons = myNumOfLessons;
            traineeTests = new List<Test>();
            numOfTests = 0;
        }

        private string ID; 
        public string _ID //פרופרטי של התז 
        {
            get => ID;
            set
            {
                if (value.Length == 9)
                    ID = value;
                else throw new Exception ("invalid ID"); 
            }
        }

        public string lastName { get; set; }
        public string firstName { get; set; }

        //private DateTime birthDate; //תאריך יומולדת של הנבחן
        public DateTime birthDate { get; set; }
        //{
        //    get => birthDate;
        //    set
        //    {
        //        if (DateTime.Now.Year - value.Year >= Configuration.minTrainieeAge)
        //            birthDate = value;
        //        else throw new Exception ("Trainee is too young"); 
        //    }
        //} 
        public Gender gender { get; set; } //מין

        private string phoneNum;
        public string PhoneNum
        {
            get => phoneNum;
            set
            {
                if (value.Length == 9 || value.Length == 10)
                    phoneNum = value;
                else throw new Exception("invalid phone number");
            }
        }

        public Address address { get; set; }

        public VehicleType vehicleType { get; set; }
        public GearBox gearBox { get; set; }
        public string schoolName { get; set; }
        public string teacherName { get; set; }

        // private int numOfLessons;
        public int numOfLessons { get; set; }
        //{
        //    get => numOfLessons;
        //    set
        //    {
        //        if (value >= Configuration.minLessonNum)
        //            numOfLessons = value;
        //        else throw new Exception("not enough lessons taken");
        //    }
        //}

        private List<Test> traineeTests;
        public List<Test> TraineeTests
        {
            get => traineeTests;
            set
            {
                traineeTests = new List<Test>(value);
            }
        } 

        public int numOfTests { get; set; }

        public override string ToString()
        {
            string traineeInfo = firstName + " " + lastName + "\n";
            traineeInfo += "ID: " + ID + "\n";
            traineeInfo += gender + " " + birthDate + "\n";
            traineeInfo += address.street + " " + address.buildingNum + ", " + address.city + " " + phoneNum + "\n"; 
            traineeInfo += "Vehicle type: " + vehicleType + ", " + gearBox + "\n";
            traineeInfo += "Driving School: " + schoolName + ". Teacher Name: " + teacherName + "\n";
            traineeInfo += "Number of Lessons: " + numOfLessons + ". Number of tests: " + numOfTests + "\n";
            if (numOfTests != 0)   //מדפיס את הטסטים הקודמים של הנבחן
            {
                traineeInfo += "Trainee's previous tests:\n";
                foreach (Test t in traineeTests)
                    traineeInfo += t.ToString();
            }
            return traineeInfo;
        }
    }
}
