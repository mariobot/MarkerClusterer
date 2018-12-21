using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace MarkerClusterer.Services
{
    public class PIWebAPIClient
    {
        private HttpClient client;

        public PIWebAPIClient(string username, string password)
        {
            client = new HttpClient();
            string authInfo = Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", username, password)));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authInfo);
            client.Timeout = new TimeSpan(0, 0, 10);
        }

        public async Task<JObject> GetAsync(string url)
        {
            HttpResponseMessage response = await client.GetAsync(url);
            string content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                var responseMessage = " Response is not succefully: " + (int)response.StatusCode;
                throw new HttpRequestException(responseMessage + Environment.NewLine + content);
            }
            JObject result = JObject.Parse(content);
            return JObject.Parse(content);
        }

        public static string RequestDirectory(string type) {

            Dictionary<string, string> RequestURL = new Dictionary<string, string>();

        

            RequestURL.Add("Bloque", "https://maboterow/piwebapi/streamsets/F1EmwoJtf9-ekUGM_8UYLFM6tAckdC0jAC6RGajuyoay9mEATUFCT1RFUk9XN1xGUk9OVEVSQVRFU1RcQkxPUVVF/value");
            RequestURL.Add("Campo", "https://maboterow/piwebapi/streamsets/F1EmwoJtf9-ekUGM_8UYLFM6tAQVZ_3DMC6RGajuyoay9mEATUFCT1RFUk9XN1xGUk9OVEVSQVRFU1RcQ0FNUE8/value");
            RequestURL.Add("Cluster", "https://maboterow/piwebapi/streamsets/F1EmwoJtf9-ekUGM_8UYLFM6tAZdTSZTQC6RGajuyoay9mEATUFCT1RFUk9XN1xGUk9OVEVSQVRFU1RcQ0xVU1RFUg/value");
            RequestURL.Add("Compañia", "https://maboterow/piwebapi/streamsets/F1EmwoJtf9-ekUGM_8UYLFM6tAr684JzIC6RGajuyoay9mEATUFCT1RFUk9XN1xGUk9OVEVSQVRFU1RcQ09NUEHDkUlB/value");
            RequestURL.Add("Pozos", "https://maboterow/piwebapi/streamsets/F1EmwoJtf9-ekUGM_8UYLFM6tA3TbQ1zQC6RGajuyoay9mEATUFCT1RFUk9XN1xGUk9OVEVSQVRFU1RcUE9aTw/value");

            string url = RequestURL.Where(x => x.Key == type).Select(x => x.Value).FirstOrDefault();

            return url;
        }

        public void Dispose()
        {
            client.Dispose();
        }
    }
}