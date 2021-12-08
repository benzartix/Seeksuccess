using Entites.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.DataInitilizer
{
    public static class DbInitializer
    {
        public static void Initialize(RepositoryContext context)
        {
            context.Database.EnsureCreated();

            if (context.Country.Any())
                return;   // DB has been seeded


            var t = GetCountries();
            foreach (var c in t)
            {
                context.Country.Add(c);
            }


            

            if (context.Account.Any())
                return;   // DB has been seeded

            Account Admin = new Account();
            Admin.FirstName = "Ahmed";
            Admin.LastName = "Benzarti";
            Admin.Phone = "+21656583333";
            Admin.Email = "benzartix@gmail.com";
            Admin.Dob = new DateTime(1989, 07, 04);
            Admin.Sexe = 'M';
            Admin.CountryId = context.Country.Where(x => x.Name == "Tunisia").Select(x => x.Id).FirstOrDefault();
            Admin.LinkCv = "cv";
            Admin.StatusId = 1;
            Admin.Secteur = "";
            Admin.Role = "Admin";
            Admin.Password = "Ab19891989//";
            Admin.Adresse = "15 rue saad ibn abi wakas Rades";
            Admin.LinkPhoto = "";
            Admin.CreatedAt = DateTime.Now;
            Admin.UpdatedAt = DateTime.Now;

            context.Account.Add(Admin);



            context.SaveChanges();

        }

        private static List<Country> GetCountries()
        {
            
                List<Country> CultureList = new List<Country>();

                //getting  the specific  CultureInfo from CultureInfo class
                CultureInfo[] getCultureInfo = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

                foreach (CultureInfo getCulture in getCultureInfo)
                {
                    //creating the object of RegionInfo class
                    RegionInfo GetRegionInfo = new RegionInfo(getCulture.LCID);
                    //adding each county Name into the arraylist
                    if (!CultureList.Any(x => x.Name == GetRegionInfo.EnglishName))
                    {
                        Country c = new Country();
                        c.Name = GetRegionInfo.EnglishName;
                        c.Label = GetRegionInfo.TwoLetterISORegionName;
                        c.Description = GetRegionInfo.NativeName;
                        c.CreatedAt = DateTime.Now;
                        c.UpdatedAt = DateTime.Now;
                        CultureList.Add(c);
                    }
                }
                CultureList = CultureList.Distinct().OrderBy(x => x.Name).ToList();
                return CultureList;
            }
        
    }
}
