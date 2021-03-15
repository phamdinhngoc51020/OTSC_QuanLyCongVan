using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanlyCongVan.DAL;
using QuanlyCongvan.Entity;

namespace QuanlyCongvan.BRL
{
    public class LichsucongtacBRL
    {
        public List<LichsucongtacEntity> gltsLichsucongtac(long lichsucongtacID)
        {
            return (new LichsucongtacDAL().LichsucongtacGetByPK(lichsucongtacID));
        }

        public List<LichsucongtacEntity> gltsLichsuCongtacCanbo(long iLichsuCongtacCanbo)
        {
            List<LichsucongtacEntity> gltsLichsuCongtacCanbo = new List<LichsucongtacEntity>();
            gltsLichsuCongtacCanbo = gltsLichsucongtac(0).FindAll(lichsu => lichsu.FK_iCanboID == iLichsuCongtacCanbo);
            return gltsLichsuCongtacCanbo;
        }
        public List<LichsucongtacEntity> gltsTest(long iLichsuCongtacCanbo)
        {
            List<LichsucongtacEntity> gltsLichsuCongtacCanbo = new List<LichsucongtacEntity>();
            gltsLichsuCongtacCanbo = gltsLichsucongtac(0).FindAll(lichsu => lichsu.FK_iCanboID == iLichsuCongtacCanbo);
            return gltsLichsuCongtacCanbo;
        }
    }
}
