using System;
using System.Configuration;

namespace CS_Data_Access_Layer
{
    static class clsDataAccessSettings
    {
        public static string ConnectionString =ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString ;


    }
}
