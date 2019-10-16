using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ModernHttpClient;
using MyHomeSensors.Services.Interfaces;
using Newtonsoft.Json;

namespace MyHomeSensors.Services
{
    public class HttpService : IHttpService
    {
        private static HttpClient _httpClient = new HttpClient(new NativeMessageHandler());
        public async Task<string> SendRequest(string url, HttpMethod? httpMethod = default, string? json = null) 
        {
           var uri = new Uri(url);
           if (httpMethod == null)
               httpMethod = HttpMethod.Get;
           try
           {
               using (var request = new HttpRequestMessage())
               {
                   request.RequestUri = uri;
                   request.Method = httpMethod;

                   if (json != null && request.Method != HttpMethod.Get)
                   {
                     //  var json = JsonConvert.SerializeObject(data);
                       var content = new StringContent(json, Encoding.UTF8, "application/json");
                       request.Content = content;
                    }

                   using (var response = await _httpClient.SendAsync(request).ConfigureAwait(false))
                   {
                       if (response.IsSuccessStatusCode)
                       {
                           var responseString = await response.Content.ReadAsStringAsync();
                          // var result = JsonConvert.DeserializeObject<T>(responseString);
                           return responseString;
                       } 
                       
                       return string.Empty;
                   }
               }
           }
           catch (Exception ex)
           {
               return string.Empty;
            }
        }
    }
}
