using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyHomeSensors.Services.Interfaces
{
    public interface IApiService
    {
        Task<string> GetAll();
        Task<string> GetById(string id);
        Task<string> AddItem(string json);
        Task<string> Update(string json, string id);
        Task<string> Delete(string id);
        Task<string> Search(string json);
    }
}
