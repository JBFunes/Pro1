using Domain.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Product
    {
        [JsonProperty]
        public int Id { get; set; }
        [JsonProperty]
        public string Name { get; set; }
        [JsonProperty]
        public string Description { get; set; }
        [JsonProperty]
        public int Quantity { get; set; }
        [JsonProperty]
        public decimal Price { get; set; }
        [JsonProperty]
        public DateTime CaducityDate { get; set; }
        [JsonProperty]
        public UnidadDeMedida UnidadDeMedida { get; set; }

    }
}
