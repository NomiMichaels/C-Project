// Maayan Siesel 315443499 
//Nomi Michaels 208025882

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace PL
{
    class Program
    {
        BL.IBL bl = BL.FactoryBL.GetBL();

        public static void addTester(string myID, string myLastName, string myFirstName,
            DateTime myBirthDate, Gender myGender, string myPhoneNum, Address myAddress,
            DateTime myValidCertification, int myExperienceYears, int myMaxTestPerWeek,
            List<VehicleType> myVehicleType, List<GearBox> myGearBox, bool[,] myScedule,
            float myMaxDistenceToTest)
        {
            BL.IBL bl = BL.FactoryBL.GetBL(); //singlton למרות שהגדרנו פעמיים זה יהיה אותו אחד בגלל ה
            Tester addingTester = new Tester();
            try
            {
                addingTester = new Tester
                {
                    _ID = myID,
                    lastName = myLastName,
                    firstName = myFirstName,
                    birthDate = myBirthDate,
                    gender = myGender,
                    PhoneNum = myPhoneNum,
                    address = myAddress,
                    validCertification = myValidCertification,
                    ExperienceYears = myExperienceYears,
                    MaxTestPerWeek = myMaxTestPerWeek,
                    vehicleType = myVehicleType,
                    gearBox = myGearBox,
                    scedule = myScedule,
                    MaxDistenceToTest = myMaxDistenceToTest,
                };
                bl.addTester(addingTester);
            }
            catch (Exception e)
            {
                if (e.Message == "invalid ID")
                {
                    Console.WriteLine("invalid ID, please enter your valid ID ");
                    myID = System.Console.ReadLine();
                    addTester(myID, myLastName, myFirstName,
                                myBirthDate, myGender, myPhoneNum, myAddress,
                                myValidCertification, myExperienceYears, myMaxTestPerWeek,
                                myVehicleType, myGearBox, myScedule,
                                myMaxDistenceToTest);
                    return;
                }
                if (e.Message == "Tester age is out of range" || e.Message == "Certification is not valid")
                {
                    Console.WriteLine(e.Message);
                    return;
                }
                if (e.Message == "invalid phone number")
                {
                    Console.WriteLine("invalid phone number, please enter your valid phone number ");
                    myPhoneNum = System.Console.ReadLine();
                    addTester(myID, myLastName, myFirstName,
                                myBirthDate, myGender, myPhoneNum, myAddress,
                                myValidCertification, myExperienceYears, myMaxTestPerWeek,
                                myVehicleType, myGearBox, myScedule,
                                myMaxDistenceToTest);
                    return;
                }
                if (e.Message == ("This tester ID already exists"))
                    bl.updateTester(addingTester);
            }
        }

        public static void startTesterData()
        {
            //הגדרת טסטרים והוספתם למאגר מידע

            addTester("123456789", "Orna", "Levi", new DateTime(1967, 12, 1), Gender.נקבה, "026543212", new Address("Rakefet", 7, "Beit Shemesh"), new DateTime(2020, 1, 1), 10, 20,
                new List<VehicleType> { VehicleType.משאית_בינונית, VehicleType.אופנוע, VehicleType.רכב_פרטי }, new List<GearBox> { GearBox.אוטומטי, GearBox.ידני },
                new bool[6, 5] {{ true, true, true, true, true } ,
                { true, true, true, true, true },
                { true, true, true, true, true },
                { true, true, true, true, true },
                { true, true, true, true, true },
                { true, true, true, true, true } }, (float)100);

            addTester("456456456", "Yoav", "Gefen", new DateTime(1972, 12, 5), Gender.זכר, "0545531001", new Address("Ein Gedi", 15, "Eilat"), new DateTime(2019, 12, 5), 10, 6,
                new List<VehicleType> { VehicleType.רכב_פרטי, VehicleType.אופנוע, VehicleType.משאית_בינונית, VehicleType.משאית_כבדה, VehicleType.אוטובוס }, new List<GearBox> { GearBox.אוטומטי, GearBox.ידני },
                new bool[6, 5]{ { false, true, true, true, true },
                { true, false, true, true, true },
                { true, true, false, true, true },
                { true, true, true, false, true },
                { true, true, true, true, false },
                { true, true, true, false, true }}, (float)80);

            addTester("789789789", "Eran", "Shalom", new DateTime(1965, 12, 5), Gender.נקבה, "0573321456", new Address("Bar Ilan", 74, "Jerusalem"), new DateTime(2019, 1, 1), 13, 20,
                    new List<VehicleType> { VehicleType.רכב_פרטי }, new List<GearBox> { GearBox.אוטומטי},
                    new bool[6, 5] {{ false, false, false, false, false },
                    { true, true, true, true, true },
                    { true, true, true, true, true },
                    { true, true, true, true, true },
                    { true, true, true, true, true },
                    { true, true, true, true, true }}, (float)100);

            addTester("789789789", "eran", "Shalom", new DateTime(1954, 12, 5), Gender.נקבה, "0573321456", new Address("Bar Ilan", 74, "Jerusalem"), new DateTime(2019, 1, 1), 13, 20,
                    new List<VehicleType> { VehicleType.רכב_פרטי }, new List<GearBox> { GearBox.אוטומטי },
                    new bool[6, 5] {{ false, false, false, false, false },
                    { true, true, true, true, true },
                    { true, true, true, true, true },
                    { true, true, true, true, true },
                    { true, true, true, true, true },
                    { false, false, false, false, false }}, (float)100);

        }

        public static void addTest(string myTraineeID, VehicleType myVehicleType, GearBox myGearBox, DateTime myTestTime, Address myDepartureAddress)
        {
            BL.IBL bl = BL.FactoryBL.GetBL(); //singlton למרות שהגדרנו פעמיים זה יהיה אותו אחד בגלל ה
            Test addingTest = new Test();

            try
            {
                addingTest = new Test
                {
                    traineeID = myTraineeID,
                    vehicleType = myVehicleType,
                    gearBox = myGearBox,
                    testTime = myTestTime,
                    departureAddress = myDepartureAddress,
                };
                bl.addTest(addingTest);

            }

            catch (Exception e)
            {
                if (e.Message == "No testers in range, change test departor address")
                {
                    Console.WriteLine(e.Message + ", street, number and city on seperate lines");
                    Address myAdress = new Address();
                    myAdress.street = System.Console.ReadLine();
                    myAdress.buildingNum = int.Parse(Console.ReadLine());
                    myAdress.city = System.Console.ReadLine();
                    addTest(myTraineeID, myVehicleType, myGearBox, myTestTime, myDepartureAddress);
                    return;
                }
                if (e.Message == "Trainee can not get tested yet" || e.Message == "Trainee can not book a test" || e.Message == "No suitable tester")
                {
                    Console.WriteLine(e.Message);
                    return;
                }

                if (e.Message == "Not a work day" || e.Message == "Not in work hours")
                {
                    Console.WriteLine(e.Message + ", enter another time");
                    //string date = System.Console.ReadLine();
                    //myTestTime = DateTime.Parse(date, System.Globalization.CultureInfo.InvariantCulture);
                    string date = System.Console.ReadLine();
                   // DateTime myTestTime;
                    while (!DateTime.TryParse(date, out myTestTime))
                    {
                        Console.WriteLine("Invalid date, enter format d/m/yyyy h:min");
                        date = System.Console.ReadLine();
                    }
                    addTest(myTraineeID, myVehicleType, myGearBox, myTestTime, myDepartureAddress);
                    return;
                }
                else
                {
                    Console.WriteLine("No tester available at your optimal time. Time available: " + e.Message + "\nAre you available?");
                    string answer = System.Console.ReadLine();
                    if (answer == "yes")
                    {
                        if (DateTime.TryParse(e.Message, out myTestTime))
                        {
                            addTest(myTraineeID, myVehicleType, myGearBox, myTestTime, myDepartureAddress);
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Enter new time for test");
                        string date = System.Console.ReadLine();
                        while (!DateTime.TryParse(date, out myTestTime))
                        {
                            Console.WriteLine("Invalid date, enter format d/m/yyyy h:min");
                            date = System.Console.ReadLine();
                        }
                        addTest(myTraineeID, myVehicleType, myGearBox, myTestTime, myDepartureAddress);
                        return;
                    }

                }

            }

        }

        public static void addTrainee(string myID, string myLastName, string myFirstName,
            DateTime myBirthDate, Gender myGender, string myPhoneNum, Address myAddress,
            VehicleType myVehicleType, GearBox myGearBox, string mySchoolName,
            string myTeacherName, int myNumOfLessons)
        {
            BL.IBL bl = BL.FactoryBL.GetBL(); //singlton למרות שהגדרנו פעמיים זה יהיה אותו אחד בגלל ה

            Trainee addingTrainee = new Trainee();
            try
            {
                addingTrainee = new Trainee
                {
                    _ID = myID,
                    lastName = myLastName,
                    firstName = myFirstName,
                    birthDate = myBirthDate,
                    gender = myGender,
                    PhoneNum = myPhoneNum,
                    address = myAddress,
                    vehicleType = myVehicleType,
                    gearBox = myGearBox,
                    schoolName = mySchoolName,
                    teacherName = myTeacherName,
                    numOfLessons = myNumOfLessons,
                };
                bl.addTrainee(addingTrainee);

            }
            catch (Exception e)
            {
                if (e.Message == "invalid ID")
                {
                    Console.WriteLine("invalid ID, please enter your valid ID ");
                    myID = System.Console.ReadLine();
                    addTrainee(myID, myLastName, myFirstName,
                                myBirthDate, myGender, myPhoneNum, myAddress,
                                myVehicleType, myGearBox, mySchoolName,
                                myTeacherName, myNumOfLessons);
                    return;
                }
                if (e.Message == "Trainee is too young" || e.Message == "not enough lessons taken")
                {
                    Console.WriteLine(e.Message);
                    return;
                }
                if (e.Message == "invalid phone number")
                {
                    Console.WriteLine("invalid phone number, please enter your valid phone number ");
                    myPhoneNum = System.Console.ReadLine();
                    addTrainee(myID, myLastName, myFirstName,
                                myBirthDate, myGender, myPhoneNum, myAddress,
                                myVehicleType, myGearBox, mySchoolName,
                                myTeacherName, myNumOfLessons);
                    return;
                }
                if (e.Message == ("This trainee ID already exists"))
                    bl.updateTrainee(addingTrainee);
            }

            //רישום התלמיד לטסט

            Console.WriteLine(addingTrainee.firstName + " " + addingTrainee.lastName + " Enter a date for your test "); //%%לא חייבים את הא"מ פ"מ
            string date = System.Console.ReadLine();
            DateTime myTestTime;
            while (!DateTime.TryParse(date, out myTestTime))
            {
                Console.WriteLine("Invalid date, enter format d/m/yyyy h:min");
                date = System.Console.ReadLine();
            }
            addTest(addingTrainee._ID, addingTrainee.vehicleType, addingTrainee.gearBox, myTestTime, addingTrainee.address); //בעתיד נשאל אותו על כתובת וזמן

        }

        public static void startTraineeData()
        {
            //הגדרת תלמידים והוספתם למאגר מידע
            addTrainee("313133499", "Maayan", "Seizel", new DateTime(1997, 5, 28), Gender.נקבה, "0526155661", new Address("Rabbi Tarfon", 6, "Jerusalem"), VehicleType.רכב_פרטי, GearBox.אוטומטי, "Eli", "Lamed", 20);
            addTrainee("293030303", "Yossi", "Cohen", new DateTime(2000, 12, 5), Gender.זכר, "0503458653", new Address("Radak", 3, "Heifa"), VehicleType.אופנוע, GearBox.אוטומטי, "Drachim", "Avraham", 30);
            addTrainee("208025882", "Nomi", "Michaels", new DateTime(1999, 4, 15), Gender.נקבה, "0585558855", new Address("Nachal Dolev", 38, "Beit Shemesh"), VehicleType.רכב_פרטי, GearBox.אוטומטי, "Shabtai", "Orna", 28);
            addTrainee("208025882", "Nomi", "Michaels", new DateTime(1999, 4, 15), Gender.נקבה, "05855588", new Address("Nachal Dolev", 38, "Beit Shemesh"), VehicleType.משאית_בינונית, GearBox.אוטומטי, "Shabtai", "Orna", 28);
        }

        public static void updateTestFunc(TestFeedback testFeedback, int testID)
        {
            BL.IBL bl = BL.FactoryBL.GetBL();

            try
            {
                Test test = bl.searchTest(testID);
                if (DateTime.Now > test.testTime)
                    bl.updateTest(testFeedback, test);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public static void updateTest()
        {
            Address address = new Address("Hertzel", 5, "Jerusalem");
            TestFeedback testFeedback1 = new TestFeedback(true, true, true, true, true, true, true, true, true, "She was exelent", address);
            updateTestFunc(testFeedback1, 10000000);
            TestFeedback testFeedback2 = new TestFeedback(true, false, true, true, true, false, true, true, true, "She still needs to practice", address);
            updateTestFunc(testFeedback2, 10000001);
            TestFeedback testFeedback3 = new TestFeedback(true, true, true, true, true, true, true, true, true, "She was exelent", address);
            updateTestFunc(testFeedback3, 10000002);
            TestFeedback testFeedback4 = new TestFeedback(true, true, true, true, true, true, true, false, true, "She still needs to practice", address);
            updateTestFunc(testFeedback4, 10000003);

        }

        public static void updateRating(Test test)   //מכניס את הדרוג לטסטר
        {
            BL.IBL bl = BL.FactoryBL.GetBL();
            int myRating = int.Parse(Console.ReadLine());
            try
            {
                bl.RateTester(test, myRating);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + ", enter rating between 1-5");
                updateRating(test);
            }
        }

        public static void rateYourTester()//עוברת על כול המבחנים שנעשו אך לא נבדקו ומבקשת דרוג
        {
            BL.IBL bl = BL.FactoryBL.GetBL();
            foreach (Tester tester in bl.getTesterList())
            {
                foreach (Test test in tester.futureTests)
                {
                    if (test.testTime < DateTime.Now)
                    {
                        Trainee trainee = bl.findTrainee(test.traineeID);
                        Console.WriteLine(trainee.firstName + " " + trainee.lastName + " please rate your tester");
                        updateRating(test);
                    }
                }
            }
        }


        static void Main()
        {
            BL.IBL bl = BL.FactoryBL.GetBL();

            startTesterData(); //הכנסת טסטרים למאגר המידע
            startTraineeData(); //הכנסת תלמידים למאגר המידע וקביעת טסט בשבילם
            rateYourTester(); //התלמיד מדרג את הטסטר שלו
            updateTest(); //הטסטר מעדכן את תוצאות הטסט

            //מדפיס את מספר התלמידים שלומדים על אופנוע
            int studentsOnTwoWeels = bl.numberOfStudentsOnTwoWeels();
            Console.WriteLine("\nThe number of students on two weelers is " + studentsOnTwoWeels);

            try
            {
                bl = BL.FactoryBL.GetBL();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //בדיקה האם היחידאות עובדת בשכבת הבי_ל
            BL.IBL blCopy = BL.FactoryBL.GetBL();
            if (bl == blCopy)
                Console.WriteLine("\nSinglton works in BL level");

            //הדפסת רשימת הטסטים
            Console.WriteLine("\nTest List:");
            foreach (Test t in bl.getTestList())
                Console.WriteLine(t.ToString());

            //הדפסת רשימת הטסטרים           
            Console.WriteLine("\nTester List:");
            foreach (Tester t in bl.getTesterList())
                Console.WriteLine(t.ToString());

            //הדפסת רשימת התלמידים
            Console.WriteLine("\nTrainee List:");
            foreach (Trainee t in bl.getTraineeList())
                Console.WriteLine(t.ToString());

        }

    }
}