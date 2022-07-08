using MyAxiaMarket.Models;
using MyAxiaMarket.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace MyAxiaMarket.ViewModels
{
    public class PersonneViewModel
    {


        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Adresse { get; set; }
        public string Email { get; set; }
       


    }

    public class PersonneViewModelForRead
    {
        public int IdP { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Adresse { get; set; }
        public string Email { get; set; }

        public string FullName { get; set; }

        public string MotPassP { get; set; }
       
        public int? TelephoneP { get; set; }
        public string Role { get; set; }

    }


    public class UpdatePersonneViewMode
    {
        public int IdP { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Adresse { get; set; }
        public string Email { get; set; }

        public string FullName { get; set; }

        public string MotPassP { get; set; }

        public int? TelephoneP { get; set; }
        public string Role { get; set; }

    }

}
