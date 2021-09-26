using Entites.Models.Base;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Models
{
    public class Country : BaseObject
    {


        public List<Country> GetCountries()
        {
            //Creating list
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

