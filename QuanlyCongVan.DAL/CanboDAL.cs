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
    public class CanboDAL
    {
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["db_QuanlyCongan"].ConnectionString);
        public List<CanboEntity> CanboGetByPK(long canboID)
        {
            List<CanboEntity> glstCabo = new List<CanboEntity>();
            cnn.Open();
            using (SqlCommand cmd = new SqlCommand("spGetCanboByPK_iCanboID", cnn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@canbID", canboID);
                SqlDataReader dar = cmd.ExecuteReader();
                if (dar.HasRows)
                {
                    while (dar.Read())
                    {
                        CanboEntity canbo = new CanboEntity();
                        canbo.PK_iCanboID = Convert.ToInt64(dar["PK_iCanboID"]);
                        canbo.STenCanbo = dar["sTenCanbo"].ToString();
                        canbo.SSodienthoai = dar["sSodienthoai"].ToString();
                        canbo.SEmail = dar["sEmail"].ToString();
                        canbo.TNgaySinh = DateTime.Parse(dar["tNgaysinh"].ToString());
                        canbo.BGioiTinh = Boolean.Parse(dar["bGioitinh"].ToString());
                        canbo.STenTaikhoan = dar["sTenTaikhoan"].ToString();
                        canbo.SMatkhau = dar["sMatkhau"].ToString();
                        canbo.SCMND = dar["sCMND"].ToString();
                        canbo.SDiaChi = dar["sDiachi"].ToString();
                        glstCabo.Add(canbo);
                    }
                }
                cnn.Close();
                return glstCabo;
            }
        }

        public List<CanboEntity> GetCanbo(long chucvuID)
        {
            List<CanboEntity> glstCanboBophan = new List<CanboEntity>();
            cnn.Open();
            using (SqlCommand cmd = new SqlCommand("spGetCanboByFK_iChucvu", cnn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@chucvuID", chucvuID);
                SqlDataReader dar = cmd.ExecuteReader();
                if (dar.HasRows)
                {
                    while (dar.Read())
                    {
                        CanboEntity canbo = new CanboEntity();
                        canbo.PK_iCanboID = Convert.ToInt64(dar["PK_iCanboID"]);
                        canbo.STenCanbo = dar["sTenCanbo"].ToString();
                        glstCanboBophan.Add(canbo);
                    }
                }
                cnn.Close();
                return glstCanboBophan;
            }
        }
        public long Insert(CanboEntity canbo)
        {
            cnn.Open();

            using (SqlCommand cmd = new SqlCommand("spInsertCanbo", cnn))
            {
                //  @sTenCanbo , --sTenCanbo - nvarchar(100)
                // @sTenTaikhoan , --sTenTaikhoan - nvarchar(50)
                // @sMatkhau , --sMatkhau - varchar(50)
                // @sSodienthoai, --sSodienthoai - char(10)
                // @sEmail , --sEmail - varchar(150)
                //@tNgaysinh , --tNgaysinh - date
                // @bGioitinh, --bGioitinh - bit
                //@sCMND , --sCMND - char(12)
                // @sDiachi -
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@sTenCanbo", canbo.STenCanbo);
                cmd.Parameters.AddWithValue("@sSodienthoai", canbo.SSodienthoai);
                cmd.Parameters.AddWithValue("@sEmail", canbo.SEmail);
                cmd.Parameters.AddWithValue("@tNgaysinh", canbo.TNgaySinh);
                cmd.Parameters.AddWithValue("@bGioitinh", canbo.BGioiTinh);
                cmd.Parameters.AddWithValue("@sCMND", canbo.SCMND);
                cmd.Parameters.AddWithValue("@sDiachi", canbo.SDiaChi);
                cmd.Parameters.AddWithValue("@sTenTaikhoan", canbo.STenTaikhoan);
                cmd.Parameters.AddWithValue("@sMatkhau", canbo.SMatkhau);
                Object iMacabo = cmd.ExecuteScalar();
                return Convert.ToInt64(iMacabo);
            }
        }
        public bool suaCanbo(CanboEntity canbo)
        {
            cnn.Open();

            using (SqlCommand cmd = new SqlCommand("spUpdateCanbo", cnn))
            {
                //  @sTenCanbo , --sTenCanbo - nvarchar(100)
                // @sTenTaikhoan , --sTenTaikhoan - nvarchar(50)
                // @sMatkhau , --sMatkhau - varchar(50)
                // @sSodienthoai, --sSodienthoai - char(10)
                // @sEmail , --sEmail - varchar(150)
                //@tNgaysinh , --tNgaysinh - date
                // @bGioitinh, --bGioitinh - bit
                //@sCMND , --sCMND - char(12)
                // @sDiachi -
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PK_iCanboID", canbo.PK_iCanboID);
                cmd.Parameters.AddWithValue("@sTenCanbo", canbo.STenCanbo);
                cmd.Parameters.AddWithValue("@sSodienthoai", canbo.SSodienthoai);
                cmd.Parameters.AddWithValue("@sEmail", canbo.SEmail);
                cmd.Parameters.AddWithValue("@tNgaysinh", canbo.TNgaySinh);
                cmd.Parameters.AddWithValue("@bGioitinh", canbo.BGioiTinh);
                cmd.Parameters.AddWithValue("@sCMND", canbo.SCMND);
                cmd.Parameters.AddWithValue("@sDiachi", canbo.SDiaChi);
                cmd.Parameters.AddWithValue("@sTenTaikhoan", canbo.STenTaikhoan);
                cmd.Parameters.AddWithValue("@sMatkhau", canbo.SMatkhau);
                long i = cmd.ExecuteNonQuery();
                if (i > 0)
                    return true;
                else
                    return false;
            }
        }
    }
}
