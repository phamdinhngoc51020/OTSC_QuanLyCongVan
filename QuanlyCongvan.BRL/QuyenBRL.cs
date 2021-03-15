using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanlyCongVan.DAL;
using QuanlyCongvan.Entity;
namespace QuanlyCongvan.BRL
{
    public class QuyenBRL
    {
        public List<QuyenEntity> layDanhsachQuyen(long QuyenID)
        {
            List<QuyenEntity> gltsQuyen = (new QuyenDAL().gltsQuyen());
            if (QuyenID != 0)
                gltsQuyen = gltsQuyen.FindAll(quyen => quyen.PK_iQuyenID == QuyenID);
            return gltsQuyen;
        }
    }
}
