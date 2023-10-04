using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace storeprocedurecmd
{
   // this file is the Global Connection
    public class Gcon_
    {
        public static string gcon;
        static Gcon_()
        {
            gcon = ConfigurationManager.ConnectionStrings["sales1"].ConnectionString;
        }
        //public static string Gconnection()
        //{
        //    return gcon;
        //}
    }
}