using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanlyCongvan.Entity
{
    public class BophanEntity
    {
        private long m_PK_iBophanID;
        private string m_sTenBophan;
        public long PK_iBophanID { get => m_PK_iBophanID; set => m_PK_iBophanID = value; }
        public string STenBophan { get => m_sTenBophan; set => m_sTenBophan = value; }
    }
}
