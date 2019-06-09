using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TSS_Support_Sytem.Model;

namespace TSS_Support_Sytem.Utils
{
    public enum Method
    {
        POST = 0,
        GET = 1,
        DELETE = 2,
        PUT = 3
    }

    public class WebConnection
    {
        public HttpWebRequest webRequest { get; set; }
        public CookieCollection cookieContainer { get; set; }
        public String content;

        public static String[] METHODS
        {
            get
            {
                return new String[] { "POST", "GET", "DELETE", "PUT" };
            }
        }

        public Method method { get; set; }

        public String GetValueFromName(String name)
        {
            Regex regex = new Regex(String.Concat("name=\"", name, "\" value=\"(.*)\""));
            String value = regex.Match(this.content).Groups[1].Value;
            return value;
        }

        public static string GeneratePostData(params Argument[] arguments)
        {
            String content = String.Empty;
            Boolean first = true;
            foreach (Argument argument in arguments)
            {
                content = String.Concat(content, first ? String.Empty : "&", argument.name, "=", argument.value);
                first = false;
            }

            return content;
        }

        internal static WebConnection GetRequestsAsPost(object p, string postData)
        {
            throw new NotImplementedException();
        }

        public Boolean DivExists(String name)
        {
            return content.Contains(name);
        }

        public String GetValueFromId(String name)
        {
            Regex regex = new Regex(String.Concat("id=\"", name, "\" value=\"(.*)\""));
            String value = regex.Match(this.content).Groups[1].Value;
            return value;
        }

        public WebConnection(HttpWebRequest webRequest, CookieCollection cookieContainer, string content, Method method = Method.GET)
        {
            this.webRequest = webRequest;
            this.cookieContainer = cookieContainer;
            this.content = content;
            this.method = method;
        }

        public WebConnection(HttpWebRequest webRequest, string content, Method method = Method.GET)
        {
            this.webRequest = webRequest;
            //this.cookieContainer = webRequest.CookieContainer.GetCookies;
            this.content = content;
            this.method = method;
        }

        public static String MethodToString(Method method)
        {
            return method.ToString();
        }


        public static WebConnection GetRequestsAsPost(String url, String postData, Method method = Method.POST, System.Net.CookieCollection cookies = null)
        {

            string url_treated = url.Replace(@"\", "/");
            var request = (HttpWebRequest)WebRequest.Create(url_treated);
            var data = System.Text.Encoding.ASCII.GetBytes(postData);
            request.CookieContainer = new CookieContainer();

            request.Method = MethodToString(method);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            if (cookies != null)
            {
                foreach (Cookie cookie in cookies)
                {
                    request.CookieContainer.Add(cookie);
                }
            }

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            String content = String.Empty;
            CookieCollection cookieContainer = new CookieCollection();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            content = new StreamReader(response.GetResponseStream()).ReadToEnd();
            cookieContainer = response.Cookies;

            return new WebConnection(request, cookieContainer, content, Method.POST);
        }

        public static WebConnection GetRequest(String url, CookieCollection cookies = null)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.CookieContainer = new CookieContainer();

            webRequest.Method = "GET";

            if (cookies != null)
            {
                foreach (Cookie cookie in cookies)
                {
                    webRequest.CookieContainer.Add(cookie);
                }
            }

            String content = String.Empty;
            CookieCollection cookieContainer = new CookieCollection();

            using (var answer = (HttpWebResponse)webRequest.GetResponse())
            {
                var streamDados = answer.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();

                cookieContainer = answer.Cookies;
                content = objResponse.ToString();

                streamDados.Close();
                answer.Close();
            }

            return new WebConnection(webRequest, cookieContainer, content, Method.GET);
        }



        public static Boolean TryAddCookie(HttpWebRequest httpRequest, Cookie cookie)
        {
            if (httpRequest == null)
            {
                return false;
            }

            if (httpRequest.CookieContainer == null)
            {
                httpRequest.CookieContainer = new CookieContainer();
            }


            return true;
        }
    }
}
