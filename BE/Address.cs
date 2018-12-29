using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public struct Address
    {
        public string street;
        public int buildingNum;
        public string city;

        public Address(string myStreet="", int myBuildingNum=0, string myCity="")
        {
            street = myStreet;
            buildingNum = myBuildingNum;
            city = myCity;
        }
    }
    
}
