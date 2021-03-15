using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanlyCongVan.DAL;
using QuanlyCongvan.Entity;


namespace QuanlyCongvan.BRL
{
    public class CongvanBRL
    {
        public List<CongvanEntity> GetCongvanGetByPK(long iMaCongvan)
        {
            return (new CongvanDAL().CongvanGetByPK(iMaCongvan));
        }

        public long themCongVan(string sohieu, string coquanbanhanh, DateTime ngaybanhanh, string nguoiki, string trichyeu, string file, DateTime ngayhethieuluc, DateTime ngaytao)
        {
            CongvanEntity congvanEntity = new CongvanEntity();
            congvanEntity.SSohieu = sohieu;
            congvanEntity.SCoquanbanhanh = coquanbanhanh;
            congvanEntity.TNgaybanhanh = ngaybanhanh;
            congvanEntity.SNguoiky = nguoiki;
            congvanEntity.STrichyeu = trichyeu;
            congvanEntity.SFile = file;
            congvanEntity.TNgayhethieuluc = ngayhethieuluc;
            congvanEntity.TThoigiantao = ngaytao;
            return (new CongvanDAL().themCongVan(congvanEntity));
        }

        public bool suaCongVan(long congvanID, string sohieu, string coquanbanhanh, DateTime ngaybanhanh, string nguoiki, string trichyeu, string file, DateTime ngayhethieuluc, DateTime ngaytao)
        {
            CongvanEntity congvanEntity = new CongvanEntity();
            congvanEntity.PK_iMaCongvan = congvanID;
            congvanEntity.SSohieu = sohieu;
            congvanEntity.SCoquanbanhanh = coquanbanhanh;
            congvanEntity.TNgaybanhanh = ngaybanhanh;
            congvanEntity.SNguoiky = nguoiki;
            congvanEntity.STrichyeu = trichyeu;
            congvanEntity.SFile = file;
            congvanEntity.TNgayhethieuluc = ngayhethieuluc;
            congvanEntity.TThoigiantao = ngaytao;

            return (new CongvanDAL().suaCongVan(congvanEntity));
        }
    }
}
