using QuanlyCongvan.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanlyCongvan.BRL;

namespace QuanLyCongVan
{
    public partial class Trangchu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sTentaikhoan = Request.Form["txtTaikhoan"];
            string sMatkhau = Request.Form["txtMatkhau"];
            List<CanboEntity> gltsCanbo = (new CanboBRL().GetCanboByPK(0));
            gltsCanbo = gltsCanbo.FindAll(canbo => canbo.STenTaikhoan == sTentaikhoan && canbo.SMatkhau==sMatkhau);
            if (gltsCanbo.Count > 0)
            {
                Session["Canbo"]=gltsCanbo;
            }
            else {
                Response.Redirect("Login.aspx?sucs=false");
            }
        }
    }
}