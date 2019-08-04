using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace sicoju.services
{
    public class HttpRequest
    {

        public static JObject GetResponse(string url)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {

                    httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");
                    var response = httpClient.GetStringAsync(new Uri(url)).Result;
                    var jsonInfo = JObject.Parse(response);
                    return jsonInfo;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}