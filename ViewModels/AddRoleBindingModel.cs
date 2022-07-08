using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace MyAxiaMarket1.ViewModels
{
    public class AddRoleBindingModel
    {
        [Required(ErrorMessage = "Le Role ne peut pas être vide")]
        public string Role { get; set; }
    }
}
