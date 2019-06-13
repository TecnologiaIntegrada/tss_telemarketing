using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TSS_Support_Sytem.Model;

namespace TSS_Support_Sytem.Utils
{
    public class NodeSQL
    {
        public string command { get; set; }
        public string auth_hash { get; set; }

        public string endpoint_url { get; set; }

        private String URL
        {
            get
            {
                return "/api/v1/sql/run";
            }
        }

        public NodeSQL(String auth_hash)
        {
            this.auth_hash = auth_hash;
        }

        public NodeSQL(AppSettings appSettings)
        {
            this.auth_hash = appSettings.auth_hash;
            this.endpoint_url = appSettings.base_url;
        }

        public NodeSQL SetEndpointUrl(String endpoint_url)
        {
            this.endpoint_url = endpoint_url;
            return this;
        }

        public Boolean SetData(String Sql)
        {

            NodeResponse nodeResponse = new NodeResponse();
            try
            {
                String postData = WebConnection.GeneratePostData(
                      new Argument() { name = "command", value = Sql },
                      new Argument() { name = "auth_hash", value = this.auth_hash }
                   );

                String postDataCipher =  Security.TripleDES.Encrypt(postData, this.auth_hash);

                WebConnection doRequests = WebConnection.GetRequestsAsPost(String.Concat(endpoint_url, this.URL), postDataCipher);
                String content = doRequests.content;

                dynamic data = JsonConvert.DeserializeObject(content);
                dynamic result = data.result;
                dynamic error = data.error;

                nodeResponse.error = error;
                nodeResponse.response = result;
            }
            catch (Exception ex)
            {

            }

            return nodeResponse.hasErrors;
        }

        public NodeResponse GetData(String Sql)
        {
            NodeResponse nodeResponse = new NodeResponse();
            try
            {
                String command = Security.NodeCrypto.Encrypt(Sql, this.auth_hash, false);

                String postData = WebConnection.GeneratePostData(
                      new Argument() { name = "command", value = command },
                      new Argument() { name = "pubkey", value = String.Empty }
                   );

                WebConnection doRequests = WebConnection.GetRequestsAsPost(String.Concat(endpoint_url, this.URL), postData);
                String content = doRequests.content;

                dynamic data = JsonConvert.DeserializeObject(content);
                dynamic result = data.result;
                nodeResponse.error = data.error.ToObject<Model.Error>();
                nodeResponse.response = result;
                return nodeResponse;
            }catch(Exception ex)
            {
                nodeResponse.hasErrors = true;
                nodeResponse.exception = ex;
            }

            return nodeResponse;
        }

    }
}
