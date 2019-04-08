using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PCL.Util
{
    public class WebAPIHelper
    {
        private HttpClient client { get; set; }
        private string route { get; set; }

        public WebAPIHelper(string uri, string route)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(uri);
            this.route = route;
        }

        public System.Net.Http.HttpResponseMessage GetResponse(string parameter = "")
        {
            return client.GetAsync(route + "/" + parameter).Result;
        }

        public System.Net.Http.HttpResponseMessage GetActionResponse(string action, string parameter = "")
        {
            return client.GetAsync(route + "/" + action + "/" + parameter).Result;
        }

        public System.Net.Http.HttpResponseMessage GetTwoParameterResponse(string action, string parameter1 = "", string parameter2 = "")
        {
            return client.GetAsync(route + "/" + action + "/" + parameter1 + "/" + parameter2).Result;
            //return client.DeleteAsync(route + "/" + action + "/" + parameter1 + "/" + parameter2).Result;
        }

        public System.Net.Http.HttpResponseMessage PostResponse(Object newObject)
        {
            var jsonObject = new StringContent(JsonConvert.SerializeObject(newObject), Encoding.UTF8, "application/json");
            return client.PostAsync(route, jsonObject).Result;
        }

        
        public System.Net.Http.HttpResponseMessage GetMultipleParameterResponse(string action, string par1 = "", string par2="", string par3="", string par4="") {
            return client.GetAsync(route + "/" + action + "/" + par1 + "/" + par2 + "/" + par3 + "/" + par4).Result;
        }


        public System.Net.Http.HttpResponseMessage GetMultipleParameterResponse2(string action, string par1 = "", string par2 = "", string par3 = "", string par4 = "", string par5="", string par6="", string par7="", string par8 = "")
        {
            return client.GetAsync(route + "/" + action + "/" + par1 + "/" + par2 + "/" + par3 + "/" + par4 + "/" + par5 + "/" + par6 + "/" + par7 + "/" + par8).Result;
        }

    }
}
