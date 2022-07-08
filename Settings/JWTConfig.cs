using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAxiaMarket1.Settings
{
    public class JWTConfig
    {
        public string key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
