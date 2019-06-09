using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TSS_Support_Sytem.Utils
{
    public class PathUtils
    {
        public static String CURRENT_LOCATION
        {
            get
            {
                return System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            }
        }

        public static String ToCurrentLocation(String semi)
        {
            return String.Concat(CURRENT_LOCATION, @"\", semi);
        }

        public static string Join(string base_url, string url)
        {
            return String.Concat(base_url, @"\", url);
        }

        internal static string Join(string endpoint_url, object gET_USERS_URL)
        {
            throw new NotImplementedException();
        }
    }
}
