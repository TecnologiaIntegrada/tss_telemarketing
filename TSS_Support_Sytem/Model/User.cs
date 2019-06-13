using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSS_Support_Sytem.Utils;

namespace TSS_Support_Sytem.Model
{
    public class User: SuperModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public object created_at { get; set; }
        public object updated_at { get; set; }
        public string email { get; set; }

        private static NodeResponse GetNodeResponse(String sql, AppSettings appSettings)
        {
            NodeResponse response = new NodeSQL(appSettings).GetData(sql);
            return response;
        }

        public static List<User> GetAllUsers(AppSettings appSettings, String sql = "")
        {
            NodeResponse response = GetNodeResponse(sql.Equals(String.Empty) ? "SELECT * FROM users" : sql, appSettings);

            if (response.error == null)
            {
                return response.DeserializeList<User>();
            }
            else
            {
                throw new Exception(response.error.syscall);
            }
        }

        public static DataTable GetAllUsersDataTable(AppSettings appSettings, String sql = "")
        {
            return GetNodeResponse(sql.Equals(String.Empty) ? "SELECT * FROM users" : sql, appSettings).ToDataTable();
        }

        public static List<User> ListFromJson(String Json)
        {
            return JsonConvert.DeserializeObject<List<User>>(Json);
        }
    }
}
