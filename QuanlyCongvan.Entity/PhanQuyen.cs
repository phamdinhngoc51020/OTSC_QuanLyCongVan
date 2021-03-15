using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanlyCongvan.Entity
{
    public class PhanQuyen
    {
        private int m_PK_iPhanQuyenID;
        private int m_FK_iQuyenID;
        private int m_FK_iCanBoID;
        private DateTime m_dThoigianbatdau;
        private DateTime m_dThoigianketthuc;

        public int PK_iPhanQuyenID { get => m_PK_iPhanQuyenID; set => m_PK_iPhanQuyenID = value; }
        public int FK_iQuyenID { get => m_FK_iQuyenID; set => m_FK_iQuyenID = value; }
        public int FK_iCanBoID { get => m_FK_iCanBoID; set => m_FK_iCanBoID = value; }
        public DateTime DThoigianbatdau { get => m_dThoigianbatdau; set => m_dThoigianbatdau = value; }
        public DateTime DThoigianketthuc { get => m_dThoigianketthuc; set => m_dThoigianketthuc = value; }
    }
}
