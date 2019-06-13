using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSS_Support_Sytem.Model
{
    public class SuperModel
    {
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static SuperModel FromJson(String json)
        {
            return JsonConvert.DeserializeObject<SuperModel>(json);
        }
    }
}
