using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanlyCongVan.DAL;
using QuanlyCongvan.Entity;

namespace QuanlyCongvan.BRL
{
    public class BophanBRL
    {
        public List<BophanEntity> GetBophanByPK(long nhanvienID)
        {
            return (new BophanDAL()).BophanGetByPK(nhanvienID);
        }
        public bool ThemBophan(string ten)
        {
            BophanEntity bophan = new BophanEntity();
            bophan.STenBophan = ten;
            return (new BophanDAL()).Insert(bophan);
        }

        public bool kiemtraBophan(string ten)
        {
            BophanEntity bophan = new BophanEntity();
            bophan.STenBophan = ten;
            List<BophanEntity> gltsBophan = GetBophanByPK(0);
            int i = gltsBophan.FindIndex(bophandb=>bophandb.STenBophan==ten);
            if (i == -1)
                return true;
            else
                return false;
        }
        public bool XoaBophan(long maBophan)
        {
            BophanEntity bophan = new BophanEntity();
            bophan.PK_iBophanID = maBophan;
            List<LichsucongtacEntity> gltsLichsu = (new LichsucongtacBRL().gltsLichsucongtac(0));
            gltsLichsu = gltsLichsu.FindAll(lichsu => lichsu.PK_iLichsucongtacID == maBophan);
            if (gltsLichsu.Count == 0)
                return (new BophanDAL().Delete(bophan));
            else
                return false;
        }
        public bool SuaBophan(long maBophan, string ten)
        {
            BophanEntity bophan = new BophanEntity();
            bophan.PK_iBophanID = maBophan;
            bophan.STenBophan = ten;
            return (new BophanDAL()).Update(bophan);
        }
    }
}
