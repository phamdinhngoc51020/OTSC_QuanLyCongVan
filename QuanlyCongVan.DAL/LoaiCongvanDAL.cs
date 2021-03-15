using QuanlyCongvan.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QuanlyCongVan.DAL
{
    public class LoaiCongvanDAL
    {
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["db_QuanlyCongan"].ConnectionString);
        public List<LoaiCongvanEntity> GetAllLoaiCongvan()
        {
            List<LoaiCongvanEntity> glstLoaiCongvan = new List<LoaiCongvanEntity>();
            cnn.Open();
            using (SqlCommand cmd = new SqlCommand("spGetAllLoaiCongvan", cnn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dar = cmd.ExecuteReader();
                if (dar.HasRows)
                {
                    while (dar.Read())
                    {
                        LoaiCongvanEntity loaiCongvan = new LoaiCongvanEntity();
                        loaiCongvan.PK_iLoaicongvanID = Convert.ToInt64(dar["PK_iLoaicongvanID"]);
                        loaiCongvan.STenloaicongvan = dar["sTenLoaicongvan"].ToString();
                        glstLoaiCongvan.Add(loaiCongvan);
                    }
                }
                cnn.Close();
                return glstLoaiCongvan;
            }
        }
        public bool InsertLoaiCongvan(LoaiCongvanEntity loaiCongvan)
        {
            cnn.Open();

            using (SqlCommand cmd = new SqlCommand("spThemloaicongvan", cnn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@sTenLoaicongvan", loaiCongvan.STenloaicongvan);
                int i = cmd.ExecuteNonQuery();
                cnn.Close();
                if (i > 0)
                    return true;
                else
                    return false;
            }
        }
        public bool UpdateLoaiCongvan(LoaiCongvanEntity loaiCongvan)
        {
            cnn.Open();
            using (SqlCommand cmd = new SqlCommand("spSualoaicongvan", cnn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PK_iLoaicongvanID", loaiCongvan.PK_iLoaicongvanID);
                cmd.Parameters.AddWithValue("@sTenLoaicongvan", loaiCongvan.STenloaicongvan);
                int i = cmd.ExecuteNonQuery();
                cnn.Close();
                if (i > 0)
                    return true;
                else
                    return false;
            }
        }
    }
}
