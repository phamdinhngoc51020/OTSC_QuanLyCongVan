using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanlyCongVan.DAL;
using QuanlyCongvan.Entity;
namespace QuanlyCongvan.BRL
{
    public class CanboBRL
    {
        public List<CanboEntity> GetCanboByPK(long canboID)
        {
            return (new CanboDAL()).CanboGetByPK(canboID);
        }
        public List<CanboEntity> GetCanboByPKChucvu(long chucvuID)
        {
            return (new CanboDAL()).GetCanbo(chucvuID);
        }

        public long themCanbo(string tenCanbo,string sodienthoai, string email,DateTime Ngaysinh,bool gioitinh,string CMND,string taikhoan,string matkhau,string diachi)
        {
            CanboEntity canbo = new CanboEntity();
            canbo.STenCanbo = tenCanbo;
            canbo.SSodienthoai = sodienthoai;
            canbo.SEmail = email;
            canbo.TNgaySinh = Ngaysinh;
            canbo.BGioiTinh = gioitinh;
            canbo.SCMND = CMND;
            canbo.SDiaChi = diachi;
            canbo.SMatkhau = matkhau;
            canbo.STenTaikhoan = taikhoan;
            return (new CanboDAL().Insert(canbo));
        }

        public bool suaCanbo(long maCanbo,string tenCanbo, string sodienthoai, string email, DateTime Ngaysinh, bool gioitinh, string CMND, string taikhoan, string matkhau, string diachi)
        {
            CanboEntity canbo = new CanboEntity();
            canbo.PK_iCanboID = maCanbo;
            canbo.STenCanbo = tenCanbo;
            canbo.SSodienthoai = sodienthoai;
            canbo.SEmail = email;
            canbo.TNgaySinh = Ngaysinh;
            canbo.BGioiTinh = gioitinh;
            canbo.SCMND = CMND;
            canbo.SDiaChi = diachi;
            canbo.SMatkhau = matkhau;
            canbo.STenTaikhoan = taikhoan;
            return (new CanboDAL().suaCanbo(canbo));
        }
    }
}
