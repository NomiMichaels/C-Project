using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    /// <summary>
    /// מבנה שמכיל את כל השדות שצריך לעדכן בסיום הטסט
    /// </summary>
    public struct TestFeedback
    {
        public bool keepingDistance;
        public bool reverseParking;
        public bool lookingAtMirrors;
        public bool signaling;
        public bool stopingForPedestrians;
        public bool intersection;
        public bool rightOfWay;
        public bool appropriateSpeed;
        public bool controlOfGearBox;
        public string testerNote;
        public Address destinationAddress;

        public TestFeedback(bool kd, bool rp, bool lam, bool s, bool sfp, bool i, bool row, bool aps, bool cogb, string tn, Address destination)
        {
            keepingDistance = kd;
            reverseParking = rp;
            lookingAtMirrors = lam;
            signaling = s;
            stopingForPedestrians = sfp;
            intersection = i;
            rightOfWay = row;
            appropriateSpeed = aps;
            controlOfGearBox = cogb;
            testerNote = tn;
            destinationAddress = destination;
        }
    };
}
