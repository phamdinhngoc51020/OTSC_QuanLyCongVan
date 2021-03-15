using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using QuanlyCongvan.Entity;
namespace QuanlyCongVan.DAL
{
    public class ChucvuDAL
    {
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["db_QuanlyCongan"].ConnectionString);
        public List<ChucvuEntity> ChucvuGetByPK(long chucvuID)
        {
            List<ChucvuEntity> glstChucvu = new List<ChucvuEntity>();
            cnn.Open();
            using (SqlCommand cmd = new SqlCommand("spGetChucvuByPK_iChucvuID", cnn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@chucvuID", chucvuID);
                SqlDataReader dar = cmd.ExecuteReader();
                if (dar.HasRows)
                {
                    while (dar.Read())
                    {
                        ChucvuEntity chucvu = new ChucvuEntity();
                        chucvu.PK_iChucvuID = Convert.ToInt64(dar["PK_iChucvuID"]);
                        chucvu.STenChucvu = dar["sTenChucvu"].ToString();
                        chucvu.ISoluong = Convert.ToInt64(dar["iSoluong"]);
                        glstChucvu.Add(chucvu);
                    }
                }
                cnn.Close();
                return glstChucvu;
            }
        }
        public long Insert(ChucvuEntity chucvu)
        {
            cnn.Open();

            using (SqlCommand cmd = new SqlCommand("spInsertChucvu", cnn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@sTenChucvu", chucvu.STenChucvu);
                cmd.Parameters.AddWithValue("@iSoluong", chucvu.ISoluong);
                object i = cmd.ExecuteScalar();
                cnn.Close();
                return Convert.ToInt64(i);
            }
        }

        public bool Delete(ChucvuEntity chucvu)
        {
            cnn.Open();
            using (SqlCommand cmd = new SqlCommand("spDeleteChucvu", cnn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PK_iChucvuID", chucvu.PK_iChucvuID);
                int i = cmd.ExecuteNonQuery();
                cnn.Close();
                if (i > 0)
                    return true;
                else
                    return false;
            }

        }
        public bool Update(ChucvuEntity chucvu)
        {
            cnn.Open();
            using (SqlCommand cmd = new SqlCommand("spUpdateChucvu", cnn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PK_iChucvuID", chucvu.PK_iChucvuID);
                cmd.Parameters.AddWithValue("@sTenChucvu", chucvu.STenChucvu);
                cmd.Parameters.AddWithValue("@iSoluong", chucvu.ISoluong);
                int i = cmd.ExecuteNonQuery();
                cnn.Close();
                if (i > 0)
                    return true;
                else
                    return false;
            }
        }
        //spSuaBophan
    }
}

