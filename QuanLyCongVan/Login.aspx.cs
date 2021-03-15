using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanlyCongvan.BRL;
using QuanlyCongvan.Entity;

namespace QuanLyCongVan
{
    public partial class Login : System.Web.UI.Page
    {
        private const string QUERYSTRINGKETQUA = "sucs";
        protected void Page_Load(object sender, EventArgs e)
        {
            string request = Request.QueryString[QUERYSTRINGKETQUA];
            if (request == "true")
            {

            }
            else if (request == "false")
            {
                lblTb.Text = "Bạn sai tên tài khoản hoặc mật khẩu";
            }
        }

        protected void btnDangnhap_Click(object sender, EventArgs e)
        {
            
        }
    }
}