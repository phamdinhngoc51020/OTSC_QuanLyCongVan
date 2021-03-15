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
    }
}
