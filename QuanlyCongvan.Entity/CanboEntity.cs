using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace QuanlyCongvan.Entity
{
    public class CanboEntity
    {
        private long m_PK_iCanboID;
        private string m_sTenCanbo;
        private string m_sTenTaikhoan;
        private string m_sMatkhau;
        private string m_sSodienthoai;
        private string m_sEmail;
        private DateTime m_tNgaySinh;
        private bool m_bGioiTinh;
        private string m_sCMND;
        private string m_sDiaChi;

        public long PK_iCanboID { get => m_PK_iCanboID; set => m_PK_iCanboID = value; }
        public string STenCanbo { get => m_sTenCanbo; set => m_sTenCanbo = value; }
        public string STenTaikhoan { get => m_sTenTaikhoan; set => m_sTenTaikhoan = value; }
        public string SMatkhau { get => m_sMatkhau; set => m_sMatkhau = value; }
        public string SSodienthoai { get => m_sSodienthoai; set => m_sSodienthoai = value; }
        public string SEmail { get => m_sEmail; set => m_sEmail = value; }
        public DateTime TNgaySinh { get => m_tNgaySinh; set => m_tNgaySinh = value; }
        public bool BGioiTinh { get => m_bGioiTinh; set => m_bGioiTinh = value; }
        public string SCMND { get => m_sCMND; set => m_sCMND = value; }
        public string SDiaChi { get => m_sDiaChi; set => m_sDiaChi = value; }
    }
}
