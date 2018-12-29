using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class FactoryBL  //יצירת מופע של בי_ל עבור שכבת היו_אי בשיטת הסינגלטון
    {
       static IBL bl = null;
       public static IBL GetBL()
       {
        if (bl == null)
        bl = new IBL_imp();
        return bl;
       }
    }
    
}
