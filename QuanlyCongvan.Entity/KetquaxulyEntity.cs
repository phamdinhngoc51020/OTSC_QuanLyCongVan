using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanlyCongvan.Entity
{
    public class KetquaxulyEntity
    {
        private long m_PK_iKetquaxulyID;
        private bool m_bTrangthaixuly;
        private DateTime m_tThoigianghinhan;
        private long m_FK_iQuatrinhxulyID;
        private string m_sMota;
        private long m_FK_iNguoighinhanID;

        public long PK_iKetquaxulyID { get => m_PK_iKetquaxulyID; set => m_PK_iKetquaxulyID = value; }
        public bool BTrangthaixuly { get => m_bTrangthaixuly; set => m_bTrangthaixuly = value; }
        public DateTime TThoigianghinhan { get => m_tThoigianghinhan; set => m_tThoigianghinhan = value; }
        public long FK_iQuatrinhxulyID { get => m_FK_iQuatrinhxulyID; set => m_FK_iQuatrinhxulyID = value; }
        public string SMota { get => m_sMota; set => m_sMota = value; }
        public long FK_iNguoighinhanID { get => m_FK_iNguoighinhanID; set => m_FK_iNguoighinhanID = value; }
    }
}
