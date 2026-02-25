using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_BusinessLayer
{
    public class clsCountries
    {
        private int _CountryID { get; set; }
        private string _CountryName { get; set; }


        public clsCountries()
        {
            _CountryID = 0;
            _CountryName = string.Empty;
        }
        public static DataTable GetAllCountries()
        {
            return CS_Data_Access_Layer.clsCountryData.GetAllCountries();
        }

        public static string GetCountryNameByID(int countryID)
        {
            return CS_Data_Access_Layer.clsCountryData.GetCountryNameByID(countryID);
        }
        public static int Find(string countryName)
        {
            return CS_Data_Access_Layer.clsCountryData.GetCountryIDByName(countryName);
        }

    }
}
