using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Models
{
    public partial class StatusInfo
    {
        [JsonProperty("Global")]
        public globalData Global { get; set; }

        [JsonProperty("Countries")]
        public List<Country> Countries { get; set; }

        [JsonProperty("Date")]
        public DateTimeOffset Date { get; set; }
    }
}
