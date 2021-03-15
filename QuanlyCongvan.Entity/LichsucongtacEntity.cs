using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanlyCongvan.Entity;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace QuanlyCongvan.Entity
{
    public class LichsucongtacEntity
    {
        private long m_PK_iLichsucongtacID;
        private long m_FK_iBophanID;
        private long m_FK_iChucvuID;
        private long m_FK_iCanboID;
        private DateTime m_tThoigianbatdau;
        private DateTime m_tThoigianketthuc;

        public long PK_iLichsucongtacID { get => m_PK_iLichsucongtacID; set => m_PK_iLichsucongtacID = value; }
        public long FK_iBophanID { get => m_FK_iBophanID; set => m_FK_iBophanID = value; }
        public long FK_iChucvuID { get => m_FK_iChucvuID; set => m_FK_iChucvuID = value; }
        public long FK_iCanboID { get => m_FK_iCanboID; set => m_FK_iCanboID = value; }
        public DateTime TThoigianbatdau { get => m_tThoigianbatdau; set => m_tThoigianbatdau = value; }
        public DateTime TThoigianketthuc { get => m_tThoigianketthuc; set => m_tThoigianketthuc = value; }
    }
}
