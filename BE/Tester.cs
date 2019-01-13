using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Tester
    {
        public Tester()
        {
            futureTests = new List<Test>(); //טסטר חדש ולכן אין לו טסטים שנקבעו
            scedule = new bool[6,5];
            rating = new TesterRating();
            birthDate = new DateTime(1970,1,1);
            validCertification = DateTime.Now;
            experienceYears = 0;
            
        }

        /// <summary>
        /// בנאי של הטסטר
        /// </summary>
        public Tester(string myID, string myLastName, string myFirstName, 
            DateTime myBirthDate, Gender myGender, string myPhoneNum, Address myAddress,
            DateTime myValidCertification, int myExperienceYears, int myMaxTestPerWeek,
            List<VehicleType> myVehicleType, List<GearBox> myGearBox, bool[,] myScedule,
            float myMaxDistenceToTest)
        {
            _ID= myID;
            lastName = myLastName;
            firstName = myFirstName;
            birthDate = myBirthDate;
            gender = myGender;
            phoneNum = myPhoneNum;
            address = myAddress;
            validCertification = myValidCertification;
            experienceYears = myExperienceYears;
            maxTestPerWeek = myMaxTestPerWeek;
            vehicleType = myVehicleType;
            gearBox = myGearBox;
            scedule = new bool[6,5];
            scedule = myScedule;
            futureTests = new List<Test>(); //טסטר חדש ולכן אין לו טסטים שנקבעו
            maxDistenceToTest = myMaxDistenceToTest;
            rating = new TesterRating();
        }

        private string ID;
        public string _ID //פרופרטי של התז
        {
            get => ID;
            set
            {
                if (value.Length == 9)
                    ID = value;
                else throw new Exception("invalid ID");
            }
        }

        public string lastName { get; set; }
        public string firstName { get; set; }

        public DateTime birthDate { get; set; } //תאריך יומולדת של הבוחן
        //public DateTime BirthDate
        //{
        //    get => birthDate;
        //    set
        //    {
        //        if (DateTime.Now.Year - value.Year <= Configuration.maxTesterAge &&
        //            DateTime.Now.Year - birthDate.Year >= Configuration.minTesterAge)
        //            birthDate = value;
        //        else throw new Exception ("Tester age is out of range"); 
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

        public DateTime validCertification { get; set; } //תוקף התעודה שלו לטסטריות
        //public DateTime ValidCertification
        //{
        //    get => validCertification;
        //    set
        //    {
        //        if (value > DateTime.Now)
        //            validCertification = value;
        //        else throw new Exception ("Certification is not valid"); 
        //    }
        //}

        private int experienceYears;
        public int ExperienceYears
        {
            get => experienceYears;
            set
            {
                if (value >= 0)
                    experienceYears = value;
                else experienceYears = -value;
            }
        }

        private int maxTestPerWeek;
        public int MaxTestPerWeek
        {
            get => maxTestPerWeek;
            set
            {
                if (value >= 0)
                    maxTestPerWeek = value;
                else maxTestPerWeek = -value;
            }
        }

        public List<VehicleType> vehicleType { get; set; } //סוג רכב
        public List<GearBox> gearBox { get; set; }

        public bool[,] scedule { get; set; }// לוז של הבוחן

        public List<Test> futureTests { get; set; } //טסטרים עתידיים של הבוחן

        private float maxDistenceToTest;
        public float MaxDistenceToTest
        {
            get => maxDistenceToTest;
            set
            {
                if (value >= 0)
                    maxDistenceToTest = value;
                else maxDistenceToTest = -value; //אם המרחק שלילי מכניסים אותו בערך מוחלט
            }
        }

        public TesterRating rating; //ממוצע של דירוג הטסטר

        public override string ToString()
        {
            string testerInfo = firstName + " " + lastName + "\n";
            testerInfo += "ID: " + ID + "\n";
            testerInfo += gender + " " + birthDate + "\n";
            testerInfo += address.street + " " + address.buildingNum + ", " + address.city + " " + phoneNum + "\n"; //הפרדה של הכתובת בשביל שידפיס טוב%
            if (vehicleType!= null)
            {
                testerInfo += "Vehicle type: ";
                foreach (VehicleType v in vehicleType)
                    testerInfo += v + ", ";
            }
            if (gearBox != null)
            {
                testerInfo += "Gear box: ";
                foreach (GearBox g in gearBox)
                    testerInfo += g + ", ";
            }
            testerInfo += "\nCertificate validity: " +validCertification + "\n";
            float myRating = rating.sumOfRatings / rating.numOfRaters;
            testerInfo += "Years of experience: " + experienceYears;
            if(rating.numOfRaters!=0)
                testerInfo+=". Rating: " + myRating + "\n";
            testerInfo += "Maximum testes per week: " + maxTestPerWeek + ". Maximum distence to test: " + maxDistenceToTest + "\n";
            testerInfo += "      Sun Mon Tue Wed Thu\n ";
            for (int i = 0; i < 6; i++) 
            {
                int j = 0;
                testerInfo += (i + 9) + ":00";
                for (; j < 5; j++)
                    if (scedule[i,j])
                        testerInfo += "  V ";
                    else testerInfo += "  X ";
                testerInfo += "\n";
            }
            if (futureTests.Count != 0)
            {
                testerInfo += "Future tests:\n";
                foreach (Test t in futureTests)
                {
                    testerInfo += t.ToString() + "\n";
                }
            }
            return testerInfo;
        }
    }
}


