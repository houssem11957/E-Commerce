using MyAxiaMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAxiaMarket1.AccountDTOs
{
    public class PersonNroleDTO
    {
        public PersonNroleDTO(Personne Rperson, string Rrole)
        {
            person = Rperson;
            role = Rrole;

        }
        public Personne person { get; set; }
        public string role { get; set; }
    }
}
