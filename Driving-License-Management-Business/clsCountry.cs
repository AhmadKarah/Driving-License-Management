using Driving_License_Management_DataAccess;
using Driving_License_Management_DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driving_License_Management_Business
{
    public class clsCountry
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }

        public clsCountry()
        {
            this.CountryID = -1;
            this.CountryName = "";
        }

        private clsCountry(CountryDTO country)
        {
            CountryID = country.CountryID;
            CountryName = country.CountryName;
        }

        public static clsCountry Find(int CountryID)
        {
            CountryDTO country = clsCountryData.GetCountryByID(CountryID);
            return new clsCountry(country);
        }

        public static clsCountry Find(string CountryName)
        {
            CountryDTO country = clsCountryData.GetCountryByName(CountryName);
            return new clsCountry(country);
        }

        public static List<CountryDTO> GetAllCountries()
        {
            return clsCountryData.GetAllCountries();
        }
    }
}
