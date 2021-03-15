using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanlyCongvan.Entity
{
    public class PhanloaiCongvanEntity
    {
        private long m_PK_iPhanloaiCongvanID;
        private long m_FK_iLoaicongvanID;
        private long m_FK_iCongvanID;

        public long PK_iPhanloaiCongvanID { get => m_PK_iPhanloaiCongvanID; set => m_PK_iPhanloaiCongvanID = value; }
        public long FK_iLoaicongvanID { get => m_FK_iLoaicongvanID; set => m_FK_iLoaicongvanID = value; }
        public long FK_iCongvanID { get => m_FK_iCongvanID; set => m_FK_iCongvanID = value; }
    }
}
