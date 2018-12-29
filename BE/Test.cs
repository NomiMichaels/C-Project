using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Test
    {
        public Test()
        {

        }
        /// <summary>
        /// בנאי לטסט
        /// </summary>
        public Test(string myTraineeID, VehicleType myVehicleType, GearBox myGearBox, DateTime myTestTime, Address myDepartureAddress)
        {
            traineeID = myTraineeID;
            vehicleType = myVehicleType;
            gearBox = myGearBox;
            testTime = myTestTime;
            departureAddress = myDepartureAddress;
            destinationAddress = myDepartureAddress;
            keepingDistance = false;
            reverseParking = false;
            lookingAtMirrors = false;
            signaling = false;
            stopingForPedestrians = false;
            intersection = false;
            rightOfWay = false;
            appropriateSpeed = false;
            controlOfGearBox = false;
            result = false;

        }

        public int testID { get; set; } 
        public string testerID { get; set; }
        public string traineeID { get; set; }
        public VehicleType vehicleType { get; set; } //סוג רכב
        public GearBox gearBox { get; set; }
        public DateTime testTime { get; set; }
        public Address departureAddress { get; set; }
        public Address destinationAddress { get; set; }

        //קריטריונים הנבדקים במבחן
        public bool keepingDistance { get; set; }
        public bool reverseParking { get; set; }
        public bool lookingAtMirrors { get; set; }
        public bool signaling { get; set; }
        public bool stopingForPedestrians { get; set; }
        public bool intersection { get; set; }
        public bool rightOfWay { get; set; }
        public bool appropriateSpeed { get; set; }
        public bool controlOfGearBox { get; set; }


        public bool result { get; set; }
        public string testerNote { get; set; }

        public override string ToString()
        {
            string testInfo = "Test number: " + testID + " Date:" + testTime + "\n";
            testInfo += "Vehicle type: " + vehicleType + ", " + gearBox + "\n";
            testInfo += "Depature Adress: " + departureAddress.street + " " + departureAddress.buildingNum + ", " + departureAddress.city + "\n";
            if(destinationAddress.street!=departureAddress.street)
                testInfo += "Destination Adress: " + destinationAddress.street + " " + destinationAddress.buildingNum + ", " + destinationAddress.city + "\n";
            testInfo += "Tester's ID: " + testerID + " Trainee ID: " + traineeID + "\n";
            if (DateTime.Now > testTime)
            {
                testInfo += "Criteria Checked\n";
                testInfo += "Keeping Distance: " + keepingDistance;
                testInfo += "\nReverse Parking: " + reverseParking;
                testInfo += "\nLooking at Mirror: " + lookingAtMirrors;
                testInfo += "\nSignalling: " + signaling;
                testInfo += "\nStopping for Pedestrians: " + stopingForPedestrians;
                testInfo += "\nIntersections: " + intersection;
                testInfo += "\nGiving right of way: " + rightOfWay;
                testInfo += "\nAppropriate speed: " + appropriateSpeed;
                testInfo += "\nControl of the geer box: " + controlOfGearBox;
                testInfo += "\nFinall result: " + result;
                testInfo += "\nTesters note: " + testerNote + "\n";
            }
            return testInfo;
        }
    }
}
