using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanlyCongvan.Entity;
using QuanlyCongvan.BRL;

namespace QuanLyCongVan
{
    public partial class Canbo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                xemDanhsachCanbo();
            }
        }

        private void xemDanhsachCanbo()
        {
            List<CanboEntity> gltsCanbo = (new CanboBRL().GetCanboByPK(0));
            rptCanbo.DataSource = gltsCanbo;
            rptCanbo.DataBind();
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            bool gt = true;
            if (rdbNam.Checked)
                gt = true;
            if (rdbNu.Checked)
                gt = false;
            long iMacanbo = (new CanboBRL().themCanbo(txtTenCanbo.Text, txtSodienthoai.Text, txtEmail.Text, DateTime.Parse(txtNgaysinh.Text), gt, txtCmnd.Text, txtTaikhoan.Text, txtMatkhau.Text, txtDiachi.Text));
            Response.Write("<script>alert('Đã thêm cán bộ " + iMacanbo + ". Xin cảm ơn')</script>");
            xemDanhsachCanbo();
            btnHuy_Click(sender, e);
        }
        private static long iCanbo;

        protected void rptCanbo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Sua")
            {
                btnHuy.Visible = true;
                if (Convert.ToInt64(e.CommandArgument) > 0)
                {
                    iCanbo = Convert.ToInt64(e.CommandArgument);
                    List<CanboEntity> gltsCanbo = (new CanboBRL().GetCanboByPK(iCanbo));
                    txtTenCanbo.Text = gltsCanbo[0].STenCanbo;
                    txtTaikhoan.Text = gltsCanbo[0].STenTaikhoan;
                    txtEmail.Text = gltsCanbo[0].SEmail;
                    txtDiachi.Text = gltsCanbo[0].SDiaChi;
                    txtCmnd.Text = gltsCanbo[0].SCMND;
                    txtMatkhau.Text = gltsCanbo[0].SMatkhau;
                    txtSodienthoai.Text = gltsCanbo[0].SSodienthoai;
                    txtNgaysinh.Text = string.Format("{0 :yyyy-MM-dd}", gltsCanbo[0].TNgaySinh);
                    bool gt = gltsCanbo[0].BGioiTinh;
                    if (gt)
                        rdbNam.Checked = true;
                    if (!gt)
                        rdbNu.Checked = true;
                    btnLuu.Visible = true;
                    btnThem.Visible = false;
                }
            }
            if (e.CommandName == "xemLichsuCongtac")
            {
                Response.Redirect("LichsuCongtac.aspx?Canbo=" + e.CommandArgument); ;
            }
        }

        protected void btnLuu_Click(object sender, EventArgs e)
        {
            bool gt = true;
            if (rdbNam.Checked)
                gt = true;
            if (rdbNu.Checked)
                gt = false;
            if ((new CanboBRL().suaCanbo(iCanbo,txtTenCanbo.Text,txtSodienthoai.Text, txtEmail.Text, DateTime.Parse(txtNgaysinh.Text), gt, txtCmnd.Text,txtTaikhoan.Text, txtMatkhau.Text, txtMatkhau.Text)))
            {
                Response.Write("<script>alert('Đã sửa cán bộ " + iCanbo + ". Xin cảm ơn')</script>");
                xemDanhsachCanbo();
                btnHuy_Click(sender, e);
            }
        }

        protected void btnHuy_Click(object sender, EventArgs e)
        {
            txtCmnd.Text = "";
            txtDiachi.Text = "";
            txtEmail.Text = "";
            txtMatkhau.Text = "";
            txtTaikhoan.Text = "";
            txtNgaysinh.Text = "";
            txtTenCanbo.Text = "";
            txtSodienthoai.Text = "";
            btnThem.Visible = true;
            btnLuu.Visible = false;
        }
    }
}