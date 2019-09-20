using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MyHomeSensors.Services.Interfaces;

namespace MyHomeSensors.Services
{
    public class ApiService : IApiService
    {
        private string BASE_URL = "https://dilpomaapiangpysha.azurewebsites.net/web/api/v1/sensors";
        private IHttpService _httpService;
        public ApiService(IHttpService httpService)
        {
            _httpService = httpService;
        }
        public async Task<string> GetAll()
        {
            var url = $"{BASE_URL}/getall";
            return await _httpService.SendRequest(url);
        }

        public async Task<string> GetById(string id)
        {
            var url = $"{BASE_URL}/get/{id}";
            return await _httpService.SendRequest(url);
        }

        public async Task<string> AddItem(string json)
        {
            var url = $"{BASE_URL}/add";
            return await _httpService.SendRequest(url, HttpMethod.Post, json);
        }

        public async Task<string> Update(string json, string id)
        {
            var url = $"{BASE_URL}/update/{id}";
            return await _httpService.SendRequest(url, HttpMethod.Put, json);
        }

        public async Task<string> Delete(string id)
        {
            var url = $"{BASE_URL}/delete/{id}";
            return await _httpService.SendRequest(url, HttpMethod.Delete);
        }

        public async Task<string> Search(string json)
        {
            var url = $"{BASE_URL}/search";
            return await _httpService.SendRequest(url, HttpMethod.Post, json);
        }
    }
}
