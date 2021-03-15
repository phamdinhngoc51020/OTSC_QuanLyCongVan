using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanlyCongVan.DAL;
using QuanlyCongvan.Entity;

namespace QuanlyCongvan.BRL
{
    public class PhanQuyenBRL
    {
        public List<PhanQuyen> layDanhsachPhanquyen(long CanBOID)
        {
            List<PhanQuyen> gltsPhanquyen = (new PhanQuyenDAL().gltsPhanQuyen());
            
            gltsPhanquyen = gltsPhanquyen.FindAll(PhanQuyen => PhanQuyen.FK_iCanBoID == CanBOID);
            return gltsPhanquyen;
        }


    }
}
