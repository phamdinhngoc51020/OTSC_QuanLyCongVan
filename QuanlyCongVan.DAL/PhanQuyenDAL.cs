using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanlyCongvan.Entity;
using System.Data;
using System.Data.SqlClient;

namespace QuanlyCongVan.DAL
{
    public class PhanQuyenDAL
    {
        private DB_Connect connect = new DB_Connect();
        public List<PhanQuyen> gltsPhanQuyen()
        {
            using(SqlConnection cnnPhanquyen = new SqlConnection(connect.Chuoiketnoi()))
            {
                List<PhanQuyen> gltsPhanQuyen = new List<PhanQuyen>();
                using (SqlCommand cmdPhanquen = new SqlCommand("spSelectPhanQuyen", cnnPhanquyen))
                {
                    cmdPhanquen.CommandType = CommandType.StoredProcedure;
                    cnnPhanquyen.Open();
                    SqlDataReader dar = cmdPhanquen.ExecuteReader();
                    if (dar.HasRows)
                    {
                        while (dar.Read())
                        {
                            PhanQuyen phanQuyen = new PhanQuyen();
                            phanQuyen.PK_iPhanQuyenID = Convert.ToInt32(dar["PK_iPhanquyenID"]);
                            phanQuyen.FK_iQuyenID = Convert.ToInt32(dar["FK_iQuyenID"]);
                            phanQuyen.FK_iCanBoID = Convert.ToInt32(dar["FK_iCanboID"]);
                            phanQuyen.DThoigianbatdau = Convert.ToDateTime(dar["tThoigianbatdau"]);
                            phanQuyen.DThoigianketthuc = Convert.ToDateTime(dar["tThoigianketthuc"]);
                            gltsPhanQuyen.Add(phanQuyen);
                        }
                    }
                    return gltsPhanQuyen;
                }
            }
        }
    }
}
