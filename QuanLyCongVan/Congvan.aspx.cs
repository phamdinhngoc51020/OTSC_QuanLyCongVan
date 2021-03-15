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
    public partial class Congvan : System.Web.UI.Page
    {
        static long congVanID;
        private void phantrangCongvan(List<CongvanEntity> gltsCongvan)
        {
            PagedDataSource pgitems = new PagedDataSource();
            pgitems.DataSource = gltsCongvan;
            pgitems.AllowPaging = true;
            pgitems.PageSize = 3;
            pgitems.CurrentPageIndex = PageNumber;
            if (pgitems.PageCount > 1)
            {
                rptPages.Visible = true;
                System.Collections.ArrayList pages = new System.Collections.ArrayList();
                for (int i = 0; i < pgitems.PageCount; i++)
                    pages.Add((i + 1).ToString());
                rptPages.DataSource = pages;
                rptPages.DataBind();
            }
            else
            {
                rptPages.Visible = false;
            }
            rptQuanLycongVan.DataSource = pgitems;
            rptQuanLycongVan.DataBind();
        }
        private void hienDanhsachCongvan()
        {
            List<CongvanEntity> glstCongvan = (new CongvanBRL()).GetCongvanGetByPK(0);
            phantrangCongvan(glstCongvan);
        }
        public int PageNumber
        {
            get
            {
                if (ViewState["PageNumber"] != null)
                    return Convert.ToInt32(ViewState["PageNumber"]);
                else
                    return 0;
            }
            set
            {
                ViewState["PageNumber"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            List<CanboEntity> gltsCanbo = (List<CanboEntity>)Session["Canbo"];
            long n = gltsCanbo[0].PK_iCanboID;

            List<PhanQuyen> gltsPhanquen = (new PhanQuyenBRL().layDanhsachPhanquyen(n));
            List<QuyenEntity> gltsquyen = (new QuyenBRL().layDanhsachQuyen(0));
            gltsPhanquen = gltsPhanquen.FindAll(phanquyen => phanquyen.FK_iQuyenID == 2 && phanquyen.DThoigianketthuc>=DateTime.Now);
            if (gltsPhanquen.Count > 0)
                btnThem.Enabled = true;
                
            btnLuu.Visible = false;
            btnHuy.Visible = false;
            if (!IsPostBack)
                hienDanhsachCongvan();

        }

        protected void rptPages_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            PageNumber = Convert.ToInt32(e.CommandArgument) - 1;
            hienDanhsachCongvan();

        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                long CongVanID = (new CongvanBRL().themCongVan(txtSohieu.Text, txtCoquanbanhanh.Text, DateTime.Parse(txtNgaybanhanh.Text), txtNguoiki.Text, txtTrichyeu.Text, fCongvan.FileName, DateTime.Parse(txtNgayhethhieuluc.Text), DateTime.Parse(txtThoigiantao.Text)));
                string path = Server.MapPath("Data\\");
                fCongvan.SaveAs(path + DateTime.Now.ToString("dd_MM_yyyy_") + fCongvan.FileName);
                Response.Write("<script>alert('Đã công văn có mã " + CongVanID + ". Xin cảm ơn')</script>");
                hienDanhsachCongvan();
            }
        }

        protected void btnTimkiem_Click(object sender, EventArgs e)
        {
            List<CongvanEntity> glstCongvan = (new CongvanBRL().GetCongvanGetByPK(0));
            if (txtSohieu.Text!="")
            {
                glstCongvan = glstCongvan.FindAll(
                    (congvan) =>
                    {
                        return timCongvangandung(congvan.SSohieu, txtSohieu.Text);
                    }
                  );
            }
            if (txtCoquanbanhanh.Text != "")
            {
                glstCongvan = glstCongvan.FindAll(
                    (congvan) =>
                    {
                        return timCongvangandung(congvan.SCoquanbanhanh, txtCoquanbanhanh.Text);
                    }
                  );
            }
            if (txtNguoiki.Text != "")
            {
                glstCongvan = glstCongvan.FindAll(
                    (congvan) =>
                    {
                        return timCongvangandung(congvan.SNguoiky, txtNguoiki.Text);
                    }
                  );
            }
            if (txtTrichyeu.Text != "")
            {
                glstCongvan = glstCongvan.FindAll(
                 (congvan) =>
                 {
                     return timCongvangandung(congvan.STrichyeu, txtTrichyeu.Text);
                 }
               );
            }
            if (txtNgaybanhanh.Text != "")
            {
                glstCongvan = glstCongvan.FindAll(
                 (congvan) =>
                 {
                     return congvan.TNgaybanhanh <= DateTime.Parse(txtNgaybanhanh.Text);
                 }
               );
            }
            if (txtNgayhethhieuluc.Text != "")
            {
                glstCongvan = glstCongvan.FindAll(
                 (congvan) =>
                 {
                     return congvan.TNgayhethieuluc >= DateTime.Parse(txtNgayhethhieuluc.Text);
                 }
               );
            }
            if (txtThoigiantao.Text != "")
            {
                glstCongvan = glstCongvan.FindAll(
                 (congvan) =>
                 {
                     return congvan.TThoigiantao <= DateTime.Parse(txtThoigiantao.Text);
                 }
               );
            }
            if (fCongvan.FileName != "")
            {
                glstCongvan = glstCongvan.FindAll(
            (congvan) =>
            {
                return congvan.SFile == fCongvan.FileName;
            }
          );
            }
            phantrangCongvan(glstCongvan);
        }

        private bool timCongvangandung(string ds, string chuoi)
        {
                if (string.Compare(ds, chuoi, true) == 0)
                    return true;
                else
                {
                    string[] arrDS = ds.ToLower().Split(' ');
                    if (arrDS.Contains(chuoi.ToLower()))
                        return true;
                }

            return false;
        }
        protected void btnLuu_Click(object sender, EventArgs e)
        {
            if (fCongvan.HasFile)
                fCongvan.SaveAs(Server.MapPath("Data\\") + DateTime.Now.ToString("dd_MM_yyyy_") + fCongvan.FileName);
            if ((new CongvanBRL().suaCongVan(congVanID, txtSohieu.Text, txtCoquanbanhanh.Text, DateTime.Parse(txtNgaybanhanh.Text), txtNguoiki.Text, txtTrichyeu.Text, fCongvan.FileName, DateTime.Parse(txtNgayhethhieuluc.Text), DateTime.Parse(txtThoigiantao.Text))))
            {
                Response.Write("<script>alert('Đã sửa thành công văn có mã " + congVanID + ". Xin cảm ơn');</script>");
                hienDanhsachCongvan();
            }
        }

        protected void btnHuy_Click(object sender, EventArgs e)
        {
            txtSohieu.Text = "";
            txtCoquanbanhanh.Text = "";
            txtNgaybanhanh.Text = "";
            txtNguoiki.Text = "";
            txtThoigiantao.Text = "";
            txtNgayhethhieuluc.Text = "";
            txtTrichyeu.Text = "";
            fCongvan.Attributes.Clear();
            btnThem.Visible = true;
            btnLuu.Visible = false;
        }

        protected void rptQuanLycongVan_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            List<CanboEntity> gltsCanbo = (List<CanboEntity>)Session["Canbo"];
            long n = gltsCanbo[0].PK_iCanboID;
            List<PhanQuyen> gltsPhanquen = (new PhanQuyenBRL().layDanhsachPhanquyen(n));
            List<QuyenEntity> gltsquyen = (new QuyenBRL().layDanhsachQuyen(0));
            gltsPhanquen = gltsPhanquen.FindAll(phanquyen => phanquyen.FK_iQuyenID == 4 && phanquyen.DThoigianketthuc >= DateTime.Now);
            if (gltsPhanquen.Count > 0)
            {
                if (e.CommandName == "Sua")
                {

                    if (Convert.ToInt64(e.CommandArgument) > 0)
                    {
                        congVanID = Convert.ToInt64(e.CommandArgument);
                        List<CongvanEntity> gltsCongvan = (new CongvanBRL().GetCongvanGetByPK(congVanID));
                        txtSohieu.Text = gltsCongvan[0].SSohieu;
                        txtCoquanbanhanh.Text = gltsCongvan[0].SCoquanbanhanh;
                        txtNgaybanhanh.Text = string.Format("{0 :yyyy-MM-dd}", gltsCongvan[0].TNgaybanhanh);
                        txtNgayhethhieuluc.Text = string.Format("{0 :yyyy-MM-dd}", gltsCongvan[0].TNgayhethieuluc);
                        txtNguoiki.Text = string.Format("{0 :yyyy-MM-dd}", gltsCongvan[0].SNguoiky);
                        txtTrichyeu.Text = gltsCongvan[0].STrichyeu;
                        txtThoigiantao.Text = string.Format("{0 :yyyy-MM-dd}", gltsCongvan[0].TThoigiantao);
                        btnLuu.Visible = true;
                        btnThem.Visible = false;
                    }
                }
            }

            if (e.CommandName == "Xemquatrinhxuly")
            {
                Response.Redirect("QuatrinhXulyCongvan.aspx?CongvanID=" + e.CommandArgument);
            }
        }
    }
}