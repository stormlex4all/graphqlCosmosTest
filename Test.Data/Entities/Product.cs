using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Test.Data.Entities
{
    public class Product
    {
        [Key]
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        //internal string id { get { return Id.ToString(); } }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
