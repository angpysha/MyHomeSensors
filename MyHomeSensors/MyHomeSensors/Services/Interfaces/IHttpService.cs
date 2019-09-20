using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyHomeSensors.Services.Interfaces
{
    public interface IHttpService
    {
        Task<string> SendRequest(string url, HttpMethod httpMethod = null, string json = null);
    }
}
