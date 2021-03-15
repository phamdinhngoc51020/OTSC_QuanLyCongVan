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
    public class BophanDAL
    {
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["db_QuanlyCongan"].ConnectionString);
        public List<BophanEntity> BophanGetByPK(long bophanID)
        {
            List<BophanEntity> glstBophan = new List<BophanEntity>();
            cnn.Open();
            using (SqlCommand cmd = new SqlCommand("spXemdanhsachBophan", cnn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mabophan", bophanID);
                SqlDataReader dar = cmd.ExecuteReader();
                if (dar.HasRows)
                {
                    while (dar.Read())
                    {
                        BophanEntity bophan = new BophanEntity();
                        bophan.PK_iBophanID = Convert.ToInt64(dar["PK_iBophanID"]);
                        bophan.STenBophan = dar["sTenBophan"].ToString();
                        glstBophan.Add(bophan);
                    }
                }
                cnn.Close();
                return glstBophan;
            }
        }
        private bool validate(BophanEntity bophan)
        {
            cnn.Open();
            String sql = "select* from tblBophan where sTenBophan = N'" + bophan.STenBophan + "'";
            SqlDataAdapter dap = new SqlDataAdapter(sql, cnn);
            DataTable dataTable = new DataTable();
            dap.Fill(dataTable);
            cnn.Close();
            if (dataTable.Rows.Count > 0)
            {
                return false;
            }
            return true;
        }
        public bool Insert(BophanEntity bophan)
        {
            if (validate(bophan))
            {
                cnn.Open();

                using (SqlCommand cmd = new SqlCommand("spThemBophan", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ten", bophan.STenBophan);
                    int i = cmd.ExecuteNonQuery();
                    cnn.Close();
                    if (i > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
        public bool Delete(BophanEntity bophan)
        {
            cnn.Open();
            using (SqlCommand cmd = new SqlCommand("spXoaBophan", cnn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ma", bophan.PK_iBophanID);
                int i = cmd.ExecuteNonQuery();
                cnn.Close();
                if (i > 0)
                    return true;
                else
                    return false;
            }

        }
        public bool Update(BophanEntity bophan)
        {
            cnn.Open();
            using (SqlCommand cmd = new SqlCommand("spSuaBophan", cnn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ma", bophan.PK_iBophanID);
                cmd.Parameters.AddWithValue("@ten", bophan.STenBophan);
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

