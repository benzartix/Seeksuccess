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
    [Table("Account")]
    public class Account : BaseModel
    {

        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Dob is required")]
        public DateTime Dob { get; set; }
        [Required(ErrorMessage = "Sexe is required")]
        public char Sexe { get; set; }
        [Required(ErrorMessage = "Country is required")]
        [ForeignKey(nameof(Country))]
        public Guid CountryId { get; set; }
        [Required(ErrorMessage = "LinkCv is required")]
        public string LinkCv { get; set; }
        [Required(ErrorMessage = "Status is required")]
        public virtual int StatusId { get; set; }
        [Required(ErrorMessage = "Secteur is required")]
        public string Secteur { get; set; }
        [Required(ErrorMessage = "Secteur is required")]
        public string Role { get; set; }



        public string Password { get; set; }
        public string Adresse { get; set; }
        public string LinkPhoto { get; set; }





    }
}
