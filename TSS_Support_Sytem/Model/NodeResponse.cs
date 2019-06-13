using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSS_Support_Sytem.Model
{
    public class NodeResponse
    {
        public Error error;
        public dynamic response;

        internal bool hasErrors { get; set; }
        internal Exception exception;

        public List<T> DeserializeList<T>()
        {
            return JsonConvert.DeserializeObject<List<T>>(ResponseToString());
        }

        public T DeserializeObject<T>()
        {
            return JsonConvert.DeserializeObject<T>(ResponseToString());
        }

        public String ResponseToString()
        {
            if (response != null)
            {
                String content = Convert.ToString(response);
                content = content.Replace("\r\n", String.Empty);
                return content;
            }
            else
            {
                throw new Exception("Response returned a null value");
            }
        }

        public DataTable ToDataTable()
        {
            return GetDataTableFromJsonString(ResponseToString());
        }

        public DataTable GetDataTableFromJsonString(string json)
        {
           return (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));
        }
    }

    public class Error
    {
        public string errno { get; set; }
        public string code { get; set; }
        public string syscall { get; set; }
        public string address { get; set; }
        public int port { get; set; }
        public bool fatal { get; set; }
    }
}
