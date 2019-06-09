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

        public static Login DoLogin(String username, String password, String base_url)
        {
            try
            {
                String postData = WebConnection.GeneratePostData(
                   new Argument() { name = "email", value = username },
                   new Argument() { name = "password", value = password },
                   new Argument() { name = "device", value = "WindowsPC" },
                   new Argument() { name = "os", value = "Windows" },
                   new Argument() { name = "latitude", value = "" },
                   new Argument() { name = "longitude", value = "" }
                );

                WebConnection doRequests = WebConnection.GetRequestsAsPost(PathUtils.Join(base_url, Login.URL_LOGIN), postData);
                String content = doRequests.content;
                Login login = Login.FromJson(content);
                //login.name = name;
                login.Container = doRequests.cookieContainer;
                return login;
            }
            catch (Exception ex)
            {

            }

            return new Login()
            {
                auth = false
            };
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
