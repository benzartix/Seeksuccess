using Entites.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Models
{
    [Table("account")]
    public class Account : BaseModel
    {

        [Required(ErrorMessage = "Dob is required")]
        public DateTime Dob { get; set; }

        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }

        public string AccountType { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [ForeignKey(nameof(Country))]
        public Guid CountryId { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [ForeignKey(nameof(Secteur))]
        public Guid SecteurId { get; set; }



    }
}
