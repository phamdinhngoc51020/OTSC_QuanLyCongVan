using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanlyCongvan.Entity
{
    public class LoaiCongvanEntity
    {
        private long m_PK_iLoaicongvanID;
        private string m_sTenloaicongvan;

        public long PK_iLoaicongvanID { get => m_PK_iLoaicongvanID; set => m_PK_iLoaicongvanID = value; }
        public string STenloaicongvan { get => m_sTenloaicongvan; set => m_sTenloaicongvan = value; }
    }
}
