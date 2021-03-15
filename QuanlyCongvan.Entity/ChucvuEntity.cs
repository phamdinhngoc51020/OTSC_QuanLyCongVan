using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanlyCongvan.Entity
{
    public class ChucvuEntity
    {
        private long m_PK_iChucvuID;
        private string m_sTenChucvu;
        private long m_iSoluong;

        public long PK_iChucvuID { get => m_PK_iChucvuID; set => m_PK_iChucvuID = value; }
        public string STenChucvu { get => m_sTenChucvu; set => m_sTenChucvu = value; }
        public long ISoluong { get => m_iSoluong; set => m_iSoluong = value; }
    }
}
