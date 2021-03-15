using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanlyCongVan.DAL;
using QuanlyCongvan.Entity;

namespace QuanlyCongvan.BRL
{
    public class KetquaxulyBRL
    {
        public List<KetquaxulyEntity> gltsKetqua(long ketqua)
        {
            return (new KetquaxulyDAL().ketquaxuly(ketqua));
        }


        public List<KetquaxulyEntity> gltsKetquaXulyGetBYFK_iQuatrinhxulyID(long FK_iQuatrinh)
        {
            return (new KetquaxulyDAL().gltsKetquaXulyGetByiFK_iQuatrinhxulyID(FK_iQuatrinh));
        }

        public List<KetquaxulyEntity> gltsKetquaXulyGetBYFK_iNguoighinhanID(long FK_iMaCanbo)
        {
            return (new KetquaxulyDAL().gltsKetquaXulyGetBYFK_iNguoighinhanID(FK_iMaCanbo));
        }
        public long themKetqua(bool bTrangthai, DateTime dThoigianghinhan, long QuatrinhxulyID, long nguoighinhanId, string mota)
        {
            KetquaxulyEntity ketqua = new KetquaxulyEntity();
            ketqua.BTrangthaixuly = bTrangthai;
            ketqua.TThoigianghinhan = dThoigianghinhan;
            ketqua.FK_iQuatrinhxulyID = QuatrinhxulyID;
            ketqua.FK_iNguoighinhanID = nguoighinhanId;
            ketqua.SMota = mota;
            return (new KetquaxulyDAL()).themKetquaxuly(ketqua);
        }
        public bool suaKetqua(long PK_Ketquaxuly, bool bTrangthai, DateTime dThoigianghinhan, long QuatrinhxulyID, long nguoighinhanId, string mota)
        {
            KetquaxulyEntity ketqua = new KetquaxulyEntity();
            ketqua.PK_iKetquaxulyID = PK_Ketquaxuly;
            ketqua.BTrangthaixuly = bTrangthai;
            ketqua.TThoigianghinhan = dThoigianghinhan;
            ketqua.FK_iQuatrinhxulyID = QuatrinhxulyID;
            ketqua.FK_iNguoighinhanID = nguoighinhanId;
            ketqua.SMota = mota;
            return (new KetquaxulyDAL().suaKetquaxuly(ketqua));
        }

        public bool xoaKetquaQuatrinhxuly(long PK_iMaquatrinh)
        {
            return (new KetquaxulyDAL().xoaQuatrinh(PK_iMaquatrinh));
        }
    }
}
