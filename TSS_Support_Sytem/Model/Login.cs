using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TSS_Support_Sytem.Utils;

namespace TSS_Support_Sytem.Model
{
    public class Login
    {
        public int id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public object created_at { get; set; }
        public object updated_at { get; set; }
        public string email { get; set; }
        public bool auth { get; set; }
        public bool saved { get; set; }

        public CookieCollection Container;

        public static String URL_LOGIN { get { return "api/v1/users/login"; } }

        public static User DoLogin(String username, String password, AppSettings appSettings)
        {
            try
            {
                String postData = WebConnection.GeneratePostData(
                   new Argument() { name = "email", value = username },
                   new Argument() { name = "password", value = password }
                );

                List<User> users = User.GetAllUsers(appSettings,
                    String.Format("SELECT * FROM users u WHERE u.email='{0}' AND u.password='{1}'", username, password));
                               
                return users != null ? users.First() : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public Login Save()
        {
            this.saved = true;
            return this;
        }

        public static Login FromJson(String Json)
        {
            String treated = StringUtils.TreatJson(Json);
            return JsonConvert.DeserializeObject<Login>(treated);
        }
    }
}
