using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanlyCongvan.Entity;
using System.Data;
using System.Data.SqlClient;
namespace QuanlyCongVan.DAL
{
    public class KetquaxulyDAL
    {
        private DB_Connect connect = new DB_Connect();

        public List<KetquaxulyEntity> gltsKetquaXulyGetByiFK_iQuatrinhxulyID(long FK_iQuatrinhxulyID)
        {
            List<KetquaxulyEntity> gltsKetquaxuly = new List<KetquaxulyEntity>();
            using (SqlConnection cnn = new SqlConnection(connect.Chuoiketnoi()))
            {
                using(SqlCommand cmd = new SqlCommand("spKetquaXulyGetBYPK_iFK_iQuatrinhxulyID", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FK_iQuatrinhxulyID", FK_iQuatrinhxulyID);
                    cnn.Open();
                    SqlDataReader darKetquaxuly = cmd.ExecuteReader();
                    if (darKetquaxuly.HasRows)
                    {
                        while (darKetquaxuly.Read())
                        {
                            KetquaxulyEntity ketqua = new KetquaxulyEntity();
                            ketqua.FK_iQuatrinhxulyID = Convert.ToInt64(darKetquaxuly["FK_iQuatrinhxulyID"]);
                            ketqua.BTrangthaixuly = Convert.ToBoolean(darKetquaxuly["bTrangthaixuly"]);
                            ketqua.TThoigianghinhan = DateTime.Parse(darKetquaxuly["tThoigianghinhan"].ToString());
                            ketqua.FK_iNguoighinhanID = Convert.ToInt64(darKetquaxuly["FK_iNguoighinhanID"]);
                            ketqua.PK_iKetquaxulyID = Convert.ToInt64(darKetquaxuly["PK_iKetquaxulyID"]);
                            ketqua.SMota = darKetquaxuly["sMota"].ToString();
                            gltsKetquaxuly.Add(ketqua);
                        }
                    }
                    return gltsKetquaxuly;
                }
            }
        }

        public List<KetquaxulyEntity> gltsKetquaXulyGetBYFK_iNguoighinhanID(long FK_MaCanbo)
        {
            List<KetquaxulyEntity> gltsKetquaxuly = new List<KetquaxulyEntity>();
            using (SqlConnection cnn = new SqlConnection(connect.Chuoiketnoi()))
            {
                using (SqlCommand cmd = new SqlCommand("spKetquaXulyGetBYFK_iNguoighinhanID", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FK_iNguoighinhanID", FK_MaCanbo);
                    cnn.Open();
                    SqlDataReader darKetquaxuly = cmd.ExecuteReader();
                    if (darKetquaxuly.HasRows)
                    {
                        while (darKetquaxuly.Read())
                        {
                            KetquaxulyEntity ketqua = new KetquaxulyEntity();
                            ketqua.FK_iQuatrinhxulyID = Convert.ToInt64(darKetquaxuly["FK_iQuatrinhxulyID"]);
                            ketqua.BTrangthaixuly = Convert.ToBoolean(darKetquaxuly["bTrangthaixuly"]);
                            ketqua.TThoigianghinhan = DateTime.Parse(darKetquaxuly["tThoigianghinhan"].ToString());
                            ketqua.FK_iNguoighinhanID = Convert.ToInt64(darKetquaxuly["FK_iNguoighinhanID"]);
                            ketqua.PK_iKetquaxulyID = Convert.ToInt64(darKetquaxuly["PK_iKetquaxulyID"]);
                            ketqua.SMota = darKetquaxuly["sMota"].ToString();
                            gltsKetquaxuly.Add(ketqua);
                        }
                    }
                    return gltsKetquaxuly;
                }
            }
        }

        public List<KetquaxulyEntity> ketquaxuly (long iMaketquaxuly)
        {
            List<KetquaxulyEntity> gltsKequaxuly = new List<KetquaxulyEntity>();
            using (SqlConnection cnn = new SqlConnection(connect.Chuoiketnoi()))
            {

                using (SqlCommand cmd = new SqlCommand("spGetby_PKketquaxuly", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PK_iKetquaxuly", iMaketquaxuly);
                    cnn.Open();
                    SqlDataReader darKetquaxuly = cmd.ExecuteReader();
                    if (darKetquaxuly.HasRows)
                    {
                        while (darKetquaxuly.Read())
                        {
                            KetquaxulyEntity ketqua = new KetquaxulyEntity();
                            ketqua.FK_iQuatrinhxulyID = Convert.ToInt64(darKetquaxuly["FK_iQuatrinhxulyID"]);
                            ketqua.BTrangthaixuly = Convert.ToBoolean(darKetquaxuly["bTrangthaixuly"]);
                            ketqua.TThoigianghinhan = DateTime.Parse(darKetquaxuly["tThoigianghinhan"].ToString());
                            ketqua.FK_iNguoighinhanID = Convert.ToInt64(darKetquaxuly["FK_iNguoighinhanID"]);
                            ketqua.PK_iKetquaxulyID = Convert.ToInt64(darKetquaxuly["PK_iKetquaxulyID"]);
                            ketqua.SMota = darKetquaxuly["sMota"].ToString();
                            gltsKequaxuly.Add(ketqua);
                        }
                    }
                    return gltsKequaxuly;
                }

            }
        }

        public long themKetquaxuly(KetquaxulyEntity ketqua)
        {
            using (SqlConnection cnn = new SqlConnection(connect.Chuoiketnoi()))
            {
                if (cnn.State == ConnectionState.Closed)
                    cnn.Open();
                using (SqlCommand cmd = new SqlCommand("spThemKetquaXulyCongvan", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@bTrangthai", ketqua.BTrangthaixuly);
                    cmd.Parameters.AddWithValue("@tThoigian", ketqua.TThoigianghinhan);
                    cmd.Parameters.AddWithValue("@sMota", ketqua.SMota);
                    cmd.Parameters.AddWithValue("@FK_iQuatrinhxulyID", ketqua.FK_iQuatrinhxulyID);
                    cmd.Parameters.AddWithValue("@FK_iNguoighinhanID", ketqua.FK_iNguoighinhanID);
                    Object iMaketqua = cmd.ExecuteScalar();
                    return Convert.ToInt64(iMaketqua);
                }
            }
        }

        public bool suaKetquaxuly(KetquaxulyEntity ketqua)
        {
            using (SqlConnection cnn = new SqlConnection(connect.Chuoiketnoi()))
            {
                if (cnn.State == ConnectionState.Closed)
                    cnn.Open();
                using (SqlCommand cmd = new SqlCommand("spUpdateKetquaxuly", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PK_iKetquaxuly", ketqua.PK_iKetquaxulyID);
                    cmd.Parameters.AddWithValue("@bTrangthaixuly", ketqua.BTrangthaixuly);
                    cmd.Parameters.AddWithValue("@tThoigianghinhan", ketqua.TThoigianghinhan);
                    cmd.Parameters.AddWithValue("@sMota", ketqua.SMota);
                    cmd.Parameters.AddWithValue("@FK_iQuatrinhxulyID", ketqua.FK_iQuatrinhxulyID);
                    cmd.Parameters.AddWithValue("@FK_iNguoighinhanID", ketqua.FK_iNguoighinhanID);
                    long i = cmd.ExecuteNonQuery();
                    if (i > 0)
                        return true;
                    else
                        return false;
                }
            }
        }

        public bool xoaQuatrinh(long QuatrinhID)
        {
            using (SqlConnection cnn = new SqlConnection(connect.Chuoiketnoi()))
            {
                if (cnn.State == ConnectionState.Closed)
                    cnn.Open();
                using (SqlCommand cmd = new SqlCommand("spXoaKetquaxuly", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ketquaxuly", QuatrinhID);
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
