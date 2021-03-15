using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanlyCongvan.Entity
{
    public class QuyenEntity
    {
        private long m_PK_iQuyenID;
        private string m_sTenQuyen;

        public long PK_iQuyenID { get => m_PK_iQuyenID; set => m_PK_iQuyenID = value; }
        public string STenQuyen { get => m_sTenQuyen; set => m_sTenQuyen = value; }
    }
}
