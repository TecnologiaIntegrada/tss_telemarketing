using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSS_Support_Sytem.Model
{
    public class AppSettings:SuperModel
    {
        public string base_url { get; set; }
        public string sql_endpoint { get; set; }
        public string auth_hash { get; set; }

        public new string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public new static AppSettings FromJson(String json)
        {
            return JsonConvert.DeserializeObject<AppSettings>(json);
        }
    }
}
