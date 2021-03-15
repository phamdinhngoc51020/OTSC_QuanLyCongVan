using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanlyCongvan.Entity;
using System.Data;
using System.Data.SqlClient;
namespace QuanlyCongVan.DAL
{
    public class CongvanDAL
    {
        private DB_Connect db_connect = new DB_Connect();
        public List<CongvanEntity> CongvanGetByPK(long iMaCongvan)
        {
            List<CongvanEntity> glstCongvan = new List<CongvanEntity>();
            using (SqlConnection conn = new SqlConnection(db_connect.Chuoiketnoi()))
            {
                using (SqlCommand cmdCongvan = new SqlCommand("spCongvanGetBYPK", conn))
                {
                    cmdCongvan.CommandType = CommandType.StoredProcedure;
                    cmdCongvan.Parameters.AddWithValue("@PK_iCongvanID", iMaCongvan);
                    conn.Open();
                    SqlDataReader darCongvan = cmdCongvan.ExecuteReader();
                    if (darCongvan.HasRows)
                    {
                        while (darCongvan.Read())
                        {
                            CongvanEntity congvanEntity = new CongvanEntity();
                            congvanEntity.PK_iMaCongvan = Convert.ToInt64(darCongvan["PK_iCongvanID"]);
                            congvanEntity.SCoquanbanhanh = darCongvan["sCoquanbanhanh"].ToString();
                            congvanEntity.SSohieu = darCongvan["sSohieu"].ToString();
                            congvanEntity.SNguoiky = darCongvan["sNguoiky"].ToString();
                            congvanEntity.SFile = darCongvan["sFile"].ToString();
                            congvanEntity.STrichyeu = darCongvan["sTrichyeu"].ToString();
                            congvanEntity.TNgaybanhanh = DateTime.Parse(darCongvan["tNgaybanhanh"].ToString());
                            congvanEntity.TNgayhethieuluc = DateTime.Parse(darCongvan["tNgayhethieuluc"].ToString());
                            congvanEntity.TThoigiantao = DateTime.Parse(darCongvan["tThoigiantao"].ToString());
                            glstCongvan.Add(congvanEntity);
                        }
                    }
                }
            }
            return glstCongvan;
        }

        public long themCongVan(CongvanEntity congvanEntity)
        {
            using (SqlConnection cnn = new SqlConnection(db_connect.Chuoiketnoi()))
            {
                if (cnn.State == ConnectionState.Closed)
                    cnn.Open();
                using (SqlCommand cmd = new SqlCommand("spThemCongvan", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sSohieu", congvanEntity.SSohieu);
                    cmd.Parameters.AddWithValue("@sCoquanbanhanh", congvanEntity.SCoquanbanhanh);
                    cmd.Parameters.AddWithValue("@tNgaybanhanh", congvanEntity.TNgaybanhanh);
                    cmd.Parameters.AddWithValue("@tNgayhethieuluc", congvanEntity.TNgayhethieuluc);
                    cmd.Parameters.AddWithValue("@tThoigiantao", congvanEntity.TThoigiantao);
                    cmd.Parameters.AddWithValue("@sFile", congvanEntity.SFile);
                    cmd.Parameters.AddWithValue("@sNguoiky", congvanEntity.SNguoiky);
                    cmd.Parameters.AddWithValue("@sTrichyeu", congvanEntity.STrichyeu);
                    Object iMaCOngvan = cmd.ExecuteScalar();
                    return Convert.ToInt64(iMaCOngvan);
                }
            }
        }

        public bool suaCongVan(CongvanEntity congvanEntity)
        {
            using (SqlConnection cnn = new SqlConnection(db_connect.Chuoiketnoi()))
            {
                if (cnn.State == ConnectionState.Closed)
                    cnn.Open();
                using (SqlCommand cmd = new SqlCommand("spSuaCongvan", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PK_iCongvanID", congvanEntity.PK_iMaCongvan);
                    cmd.Parameters.AddWithValue("@sSohieu", congvanEntity.SSohieu);
                    cmd.Parameters.AddWithValue("@sCoquanbanhanh", congvanEntity.SCoquanbanhanh);
                    cmd.Parameters.AddWithValue("@tNgaybanhanh", congvanEntity.TNgaybanhanh);
                    cmd.Parameters.AddWithValue("@tNgayhethieuluc", congvanEntity.TNgayhethieuluc);
                    cmd.Parameters.AddWithValue("@sFile", congvanEntity.SFile);
                    cmd.Parameters.AddWithValue("@sNguoiky", congvanEntity.SNguoiky);
                    cmd.Parameters.AddWithValue("@sTrichyeu", congvanEntity.STrichyeu);
                    long i = cmd.ExecuteNonQuery();
                    if (i > 0)
                        return true;
                    else
                        return false;
                }
            }
        }
    }
}
