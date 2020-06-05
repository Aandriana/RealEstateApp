using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.ViewModels
{
    public class LoginResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
