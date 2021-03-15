using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanlyCongVan.DAL;
using QuanlyCongvan.Entity;
namespace QuanlyCongvan.BRL
{
    public class ChucvuBRL
    {
        public List<ChucvuEntity> GetChucvuByPK(long chucvuID)
        {
            return (new ChucvuDAL()).ChucvuGetByPK(chucvuID);
        }
        public long ThemChucvu(string ten,long soluong)
        {
            ChucvuEntity chucvu = new ChucvuEntity();
            chucvu.STenChucvu = ten;
            chucvu.ISoluong = soluong;
            return (new ChucvuDAL()).Insert(chucvu);
        }
        public bool XoaChucvu(long maChucvu)
        {
            List<LichsucongtacEntity> gltsLichsu = (new LichsucongtacBRL().gltsLichsucongtac(0));
            ChucvuEntity chucvu = new ChucvuEntity();
            chucvu.PK_iChucvuID = maChucvu;
            gltsLichsu = gltsLichsu.FindAll(lichsu => lichsu.PK_iLichsucongtacID == maChucvu);
            if (gltsLichsu.Count == 0)
                return (new ChucvuDAL().Delete(chucvu));
            else
                return false;
        }
        public bool SuaChucvu(long maChucvu, string tenChucvu, long soluong)
        {
            ChucvuEntity chucvu = new ChucvuEntity();
            chucvu.PK_iChucvuID = maChucvu;
            chucvu.STenChucvu = tenChucvu;
            chucvu.ISoluong = soluong;
            return (new ChucvuDAL()).Update(chucvu);
        }
    }
}
