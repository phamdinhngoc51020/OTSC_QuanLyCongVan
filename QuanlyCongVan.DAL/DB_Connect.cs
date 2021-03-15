using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace QuanlyCongVan.DAL
{
    public class DB_Connect
    {
     public string Chuoiketnoi()
        {
            if (ConfigurationManager.ConnectionStrings["db_QuanlyCongan"] == null)
                throw new Exception("vui lòng đặt ConnectionString db_Tranning vào webconfig");
            return ConfigurationManager.ConnectionStrings["db_QuanlyCongan"].ConnectionString;
        }
    }
}
