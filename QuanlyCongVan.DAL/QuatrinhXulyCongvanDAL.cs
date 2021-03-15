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
    public class QuatrinhXulyCongvanDAL
    {
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["db_QuanlyCongan"].ConnectionString);
        public List<QuatrinhXulyCongvanEntity> QuatrinhxulyCongvanPK(long iMaCongvan)
        {
            List<QuatrinhXulyCongvanEntity> gltsQuatrinhxulycongvan = new List<QuatrinhXulyCongvanEntity>();
            using (SqlCommand cmd = new SqlCommand("spXemquatrinhxulycongvan", cnn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CongvanID", iMaCongvan);
                cnn.Open();
                SqlDataReader darQuatrinhXulyCongvan = cmd.ExecuteReader();
                if (darQuatrinhXulyCongvan.HasRows)
                {
                    while (darQuatrinhXulyCongvan.Read())
                    {
                        QuatrinhXulyCongvanEntity quatrinhXulyCongvan = new QuatrinhXulyCongvanEntity();
                        quatrinhXulyCongvan.PK_iQuatrinhxulyCongvanID = Convert.ToInt64(darQuatrinhXulyCongvan["PK_iQuatrinhxulyCongvanID"]);
                        quatrinhXulyCongvan.FK_iCanboID = Convert.ToInt64(darQuatrinhXulyCongvan["PK_iCanboID"]);
                        quatrinhXulyCongvan.FK_iCongvanID = Convert.ToInt64(darQuatrinhXulyCongvan["PK_iCongvanID"]);
                        quatrinhXulyCongvan.STenNhiemvu = darQuatrinhXulyCongvan["sTenNhiemvu"].ToString();
                        quatrinhXulyCongvan.THanxuly = DateTime.Parse(darQuatrinhXulyCongvan["tHanxuly"].ToString());
                        quatrinhXulyCongvan.DNgaybatdauxuly = DateTime.Parse(darQuatrinhXulyCongvan["tNgaybatdauxuly"].ToString());
                        gltsQuatrinhxulycongvan.Add(quatrinhXulyCongvan);
                    }
                }
                cnn.Close();
            }
            return gltsQuatrinhxulycongvan;
        }

        public List<QuatrinhXulyCongvanEntity> getQuatrinhxulyCongvaanbyPK(long iQuatrinhID)
        {
            List<QuatrinhXulyCongvanEntity> gltsQuatrinhxulycongvan = new List<QuatrinhXulyCongvanEntity>();
            using (SqlCommand cmd = new SqlCommand("spGetByPKQuatrinhxuly", cnn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@iQuatrinhID", iQuatrinhID);
                cnn.Open();
                SqlDataReader darQuatrinhXulyCongvan = cmd.ExecuteReader();
                if (darQuatrinhXulyCongvan.HasRows)
                {
                    while (darQuatrinhXulyCongvan.Read())
                    {
                        QuatrinhXulyCongvanEntity quatrinhXulyCongvan = new QuatrinhXulyCongvanEntity();
                        quatrinhXulyCongvan.PK_iQuatrinhxulyCongvanID = Convert.ToInt64(darQuatrinhXulyCongvan["PK_iQuatrinhxulyCongvanID"]);
                        quatrinhXulyCongvan.FK_iCanboID = Convert.ToInt64(darQuatrinhXulyCongvan["FK_iCanboID"]);
                        quatrinhXulyCongvan.FK_iCongvanID = Convert.ToInt64(darQuatrinhXulyCongvan["FK_iCongvanID"]);
                        quatrinhXulyCongvan.STenNhiemvu = darQuatrinhXulyCongvan["sTenNhiemvu"].ToString();
                        quatrinhXulyCongvan.THanxuly = DateTime.Parse(darQuatrinhXulyCongvan["tHanxuly"].ToString());
                        quatrinhXulyCongvan.DNgaybatdauxuly = DateTime.Parse(darQuatrinhXulyCongvan["tNgaybatdauxuly"].ToString());
                        gltsQuatrinhxulycongvan.Add(quatrinhXulyCongvan);
                    }
                }
                cnn.Close();
            }
            return gltsQuatrinhxulycongvan;
        }

        public long themQuatrinh(QuatrinhXulyCongvanEntity quatrinhXulyCongvanEntity)
        {
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();
            using (SqlCommand cmd = new SqlCommand("spThemquatrinhxulyCongvan", cnn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@sTenNhiemvu", quatrinhXulyCongvanEntity.STenNhiemvu);
                cmd.Parameters.AddWithValue("@tHanxuly", quatrinhXulyCongvanEntity.THanxuly);
                cmd.Parameters.AddWithValue("@tNgaybatdauxuly", quatrinhXulyCongvanEntity.DNgaybatdauxuly);
                cmd.Parameters.AddWithValue("@FK_iCongvanID", quatrinhXulyCongvanEntity.FK_iCongvanID);
                cmd.Parameters.AddWithValue("@FK_iCanboID", quatrinhXulyCongvanEntity.FK_iCanboID);
                Object iMaquatrinh = cmd.ExecuteScalar();
                return Convert.ToInt64(iMaquatrinh);
            }
        }

        public bool suaQuatrinh(QuatrinhXulyCongvanEntity quatrinhXulyCongvanEntity)
        {
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();
            using (SqlCommand cmd = new SqlCommand("spSuaquatrinhxulyCongvan", cnn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PK_iQuatrinhxulyCongvanID", quatrinhXulyCongvanEntity.PK_iQuatrinhxulyCongvanID);
                cmd.Parameters.AddWithValue("@tNgaybatdauxuly", quatrinhXulyCongvanEntity.DNgaybatdauxuly);
                cmd.Parameters.AddWithValue("@tHanxuly", quatrinhXulyCongvanEntity.THanxuly);
                cmd.Parameters.AddWithValue("@sTenNhiemvu", quatrinhXulyCongvanEntity.STenNhiemvu);
                cmd.Parameters.AddWithValue("@FK_iCanboID", quatrinhXulyCongvanEntity.FK_iCanboID);
                cmd.Parameters.AddWithValue("@FK_iCongvanID", quatrinhXulyCongvanEntity.FK_iCongvanID);
                long i = cmd.ExecuteNonQuery();
                if (i > 0)
                    return true;
                else
                    return false;
            }
        }


        public bool xoaQuatrinh(long QuatrinhID)
        {
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();
            using (SqlCommand cmd = new SqlCommand("spXoaquatrinhxulyCongvan", cnn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PK_iQuatrinhxulyCongvanID", QuatrinhID);
                long i = cmd.ExecuteNonQuery();
                if (i > 0)
                    return true;
                else
                    return false;
            }
        }
    }
}

