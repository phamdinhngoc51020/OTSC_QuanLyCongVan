using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanlyCongvan.Entity;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace QuanlyCongVan.DAL
{
    public class LichsucongtacDAL
    {
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["db_QuanlyCongan"].ConnectionString);
        public List<LichsucongtacEntity> LichsucongtacGetByPK(long lichsucongtacID)
        {
            List<LichsucongtacEntity> glstLichsucongtac = new List<LichsucongtacEntity>();
            cnn.Open();
            using (SqlCommand cmd = new SqlCommand("spXemdanhsachLichsucongtac", cnn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PK_iLichsucongtacID", lichsucongtacID);
                SqlDataReader dar = cmd.ExecuteReader();
                if (dar.HasRows)
                {
                    while (dar.Read())
                    {
                        LichsucongtacEntity lichsucongtac = new LichsucongtacEntity();
                        lichsucongtac.PK_iLichsucongtacID = Convert.ToInt64(dar["PK_iLichsucongtacID"]);
                        lichsucongtac.FK_iChucvuID = Convert.ToInt64(dar["FK_iChucvuID"]);
                        lichsucongtac.FK_iBophanID = Convert.ToInt64(dar["FK_iBophanID"]);
                        lichsucongtac.FK_iCanboID = Convert.ToInt64(dar["FK_iCanboID"]);
                        if (dar["tThoigianketthuc"].ToString() != "")
                            lichsucongtac.TThoigianketthuc = Convert.ToDateTime(dar["tThoigianketthuc"]);
                        else
                            lichsucongtac.TThoigianketthuc
                                =DateTime.Parse("01/10/2000");
                        glstLichsucongtac.Add(lichsucongtac);
                    }
                }
                cnn.Close();
                return glstLichsucongtac;
            }
        }
    }
}
