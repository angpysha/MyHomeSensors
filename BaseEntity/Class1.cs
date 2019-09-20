using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BaseEntity
{
    public abstract class Entity
    {
        public abstract string Type { get; }

        [JsonProperty("_id")]
        public Id _Id { get; set; }

        public string Id => _Id.ID;

        public abstract Task<string> ToJson();
    }

    public class Id
    {
        [JsonProperty("$oid")]
        public string ID { get; set; }
    }
}
