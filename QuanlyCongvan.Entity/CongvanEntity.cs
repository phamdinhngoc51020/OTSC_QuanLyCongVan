using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanlyCongvan.Entity
{
    public class CongvanEntity
    {
        private long m_PK_iMaCongvan;
        private string m_sSohieu;
        private string m_sCoquanbanhanh;
        private DateTime m_tNgaybanhanh;
        private string m_sNguoiky;
        private string m_sTrichyeu;
        private string m_sFile;
        private DateTime m_tNgayhethieuluc;
        private DateTime m_tThoigiantao;

        public long PK_iMaCongvan { get => m_PK_iMaCongvan; set => m_PK_iMaCongvan = value; }
        public string SSohieu { get => m_sSohieu; set => m_sSohieu = value; }
        public string SCoquanbanhanh { get => m_sCoquanbanhanh; set => m_sCoquanbanhanh = value; }
        public DateTime TNgaybanhanh { get => m_tNgaybanhanh; set => m_tNgaybanhanh = value; }
        public string SNguoiky { get => m_sNguoiky; set => m_sNguoiky = value; }
        public string STrichyeu { get => m_sTrichyeu; set => m_sTrichyeu = value; }
        public string SFile { get => m_sFile; set => m_sFile = value; }
        public DateTime TNgayhethieuluc { get => m_tNgayhethieuluc; set => m_tNgayhethieuluc = value; }
        public DateTime TThoigiantao { get => m_tThoigiantao; set => m_tThoigiantao = value; }
    }
}
