using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanlyCongvan.Entity;
using System.Data;
using System.Data.SqlClient;

namespace QuanlyCongVan.DAL
{
    public class QuyenDAL
    {
        private DB_Connect db_connect = new DB_Connect();
        public List<QuyenEntity> gltsQuyen()
        {
            List<QuyenEntity> gltsQuyen = new List<QuyenEntity>();
            using(SqlConnection cnnQuyen = new SqlConnection(db_connect.Chuoiketnoi()))
            {
                using(SqlCommand cmdQuyen = new SqlCommand("spSelectQuyen", cnnQuyen))
                {
                    cmdQuyen.CommandType = CommandType.StoredProcedure;
                    cnnQuyen.Open();
                    SqlDataReader dar = cmdQuyen.ExecuteReader();
                    if (dar.HasRows)
                    {
                        while (dar.Read())
                        {
                            QuyenEntity quyen = new QuyenEntity();
                            quyen.PK_iQuyenID = Convert.ToInt32(dar["PK_iQuyenID"]);
                            quyen.STenQuyen = dar["sTenQuyen"].ToString();
                            gltsQuyen.Add(quyen);
                        }
                    }
                }
            }
            return gltsQuyen;
        }
    }
}
