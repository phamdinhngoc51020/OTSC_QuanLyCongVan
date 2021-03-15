using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanlyCongVan.DAL;
using QuanlyCongvan.Entity;
namespace QuanlyCongvan.BRL
{
    public class QuatrinhXulyCongvanBRL
    {
        public List<QuatrinhXulyCongvanEntity> gltsQuatrinhXulyCongvan(long iMaCongVan)
        {
            return (new QuatrinhXulyCongvanDAL().QuatrinhxulyCongvanPK(iMaCongVan));
        }

        public long themQuatrinhxulyCongvan(string tennhiemvu, long FK_iCanbo, long FK_Congvan, DateTime Ngaybatdau, DateTime Ngayhethan)
        {
            QuatrinhXulyCongvanEntity quatrinhXulyCongvan = new QuatrinhXulyCongvanEntity();
            quatrinhXulyCongvan.STenNhiemvu = tennhiemvu;
            quatrinhXulyCongvan.FK_iCanboID = FK_iCanbo;
            quatrinhXulyCongvan.FK_iCongvanID = FK_Congvan;
            quatrinhXulyCongvan.DNgaybatdauxuly = Ngaybatdau;
            quatrinhXulyCongvan.THanxuly = Ngayhethan;
            return (new QuatrinhXulyCongvanDAL().themQuatrinh(quatrinhXulyCongvan));
        }

        public List<QuatrinhXulyCongvanEntity> gltsQuatrinhxuly(long iMaquatrinhID)
        {
            return (new QuatrinhXulyCongvanDAL().getQuatrinhxulyCongvaanbyPK(iMaquatrinhID));
        }

        public bool suaQuatrinhXulyCongvan(long PK_iMaquatrinh, string tennhiemvu, long FK_CongvanID, long FK_canboID, DateTime Ngaybatdau, DateTime Ngayhethan)
        {
            QuatrinhXulyCongvanEntity quatrinhXulyCongvan = new QuatrinhXulyCongvanEntity();
            quatrinhXulyCongvan.STenNhiemvu = tennhiemvu;
            quatrinhXulyCongvan.FK_iCanboID = FK_canboID;
            quatrinhXulyCongvan.FK_iCongvanID = FK_CongvanID;
            quatrinhXulyCongvan.DNgaybatdauxuly = Ngaybatdau;
            quatrinhXulyCongvan.THanxuly = Ngayhethan;
            quatrinhXulyCongvan.PK_iQuatrinhxulyCongvanID = PK_iMaquatrinh;
            return (new QuatrinhXulyCongvanDAL().suaQuatrinh(quatrinhXulyCongvan));
        }

        public bool xoaQuatrinhxulyCongvan(long PK_iMaquatrinh)
        {
            return (new QuatrinhXulyCongvanDAL().xoaQuatrinh(PK_iMaquatrinh));
        }
    }
}
