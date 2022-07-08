using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAxiaMarket.ModelView
{
    public class PersonneModelView
    {
        public int IdP { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Adresse { get; set; }
        public string Email { get; set; }

        public string MotPassP { get; set; }

        public int? TelephoneP { get; set; }
        public string Role { get; set; }


    }
}
