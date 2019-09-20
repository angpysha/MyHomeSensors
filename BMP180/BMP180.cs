using System;
using System.Threading.Tasks;
using BaseEntity;
using Newtonsoft.Json;

namespace BMP180
{
    public class BMP180 : Entity
    {
        public override string Type => "bmp180";

        public static string TypeString = "bmp180";
        
        public string Temperature { get; set; }
        public string Pressure { get; set; }
        public string Altitude { get; set; }

        public override async Task<string> ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
