using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanlyCongvan.Entity
{
    public class QuatrinhXulyCongvanEntity
    {
        private long m_PK_iQuatrinhxulyCongvanID;
        private DateTime m_dNgaybatdauxuly;
        private DateTime m_tHanxuly;
        private string m_sTenNhiemvu;
        private long m_FK_iCanboID;
        private long m_FK_iCongvanID;

        public long PK_iQuatrinhxulyCongvanID { get => m_PK_iQuatrinhxulyCongvanID; set => m_PK_iQuatrinhxulyCongvanID = value; }
        public DateTime DNgaybatdauxuly { get => m_dNgaybatdauxuly; set => m_dNgaybatdauxuly = value; }
        public DateTime THanxuly { get => m_tHanxuly; set => m_tHanxuly = value; }
        public string STenNhiemvu { get => m_sTenNhiemvu; set => m_sTenNhiemvu = value; }
        public long FK_iCanboID { get => m_FK_iCanboID; set => m_FK_iCanboID = value; }
        public long FK_iCongvanID { get => m_FK_iCongvanID; set => m_FK_iCongvanID = value; }
    }
}
