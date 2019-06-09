using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSS_Support_Sytem.Utils
{
    public class StringUtils
    {
        public static String TreatJson(String Json)
        {
            return Json.Replace(@"\", "");
        }
    }
}
