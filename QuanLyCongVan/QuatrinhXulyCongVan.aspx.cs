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
    public partial class WebForm1 : System.Web.UI.Page
    {
        private long iQuatrinhCongvan;

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

        public long IQuatrinhCongvan { get => iQuatrinhCongvan; set => iQuatrinhCongvan = value; }

        protected void Page_Load(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            List<CanboEntity> gltsCanbo = (List<CanboEntity>)Session["Canbo"];
            long n = gltsCanbo[0].PK_iCanboID;

            List<PhanQuyen> gltsPhanquen = (new PhanQuyenBRL().layDanhsachPhanquyen(n));
            List<QuyenEntity> gltsquyen = (new QuyenBRL().layDanhsachQuyen(0));
            gltsPhanquen = gltsPhanquen.FindAll(phanquyen => phanquyen.FK_iQuyenID == 14 && phanquyen.DThoigianketthuc >= DateTime.Now);
            if (gltsPhanquen.Count > 0)
                btnThem.Enabled = true;
            if (!Page.IsPostBack)
            {
                xemDanhsachQuatrinhXuly();
                xemDanhsachCanbo();
                xemDanhsachCongvan();
            }
        }

        private void xemDanhsachCongvan()
        {
            List<CongvanEntity> gltsCongvan = (new CongvanBRL().GetCongvanGetByPK(0));
            cboSohieu.DataSource = gltsCongvan;
            cboSohieu.DataTextField = "SSohieuCongvan";
            cboCanboxuly.DataValueField = "PK_iMaCongvan";
            cboSohieu.DataBind();
        }
        private void xemDanhsachCanbo()
        {
            List<CanboEntity> gltsCanbo = (new CanboBRL().GetCanboByPK(0));
            cboCanboxuly.DataSource = gltsCanbo;
            cboCanboxuly.DataTextField = "TenCanbo";
            cboCanboxuly.DataValueField = "MaCabo";
            cboCanboxuly.DataBind();
            cboCanboxuly.Items.Insert(0, new ListItem("Tất cả", "0"));
        }

        private void phantranQuatrinh(List<QuatrinhXulyCongvanEntity> gltsQuatirnh)
        {
            PagedDataSource pgitems = new PagedDataSource();
            pgitems.DataSource = gltsQuatirnh;
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
            rptQuatrinhXulyCongvan.DataSource = pgitems;
            rptQuatrinhXulyCongvan.DataBind();
        }

        private void xemDanhsachQuatrinhXuly()
        {
            long CongvanID = Convert.ToInt64(Request.QueryString["CongvanID"]);
            List<QuatrinhXulyCongvanEntity> gltsQuatrinhxuly = (new QuatrinhXulyCongvanBRL().gltsQuatrinhXulyCongvan(CongvanID));
            phantranQuatrinh(gltsQuatrinhxuly);
        }

        protected void rptPage_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            PageNumber = Convert.ToInt32(e.CommandArgument) - 1;
            xemDanhsachQuatrinhXuly();
        }

        protected void btnHuy_Click(object sender, EventArgs e)
        {
            txthanxuly.Text = "";
            txtNgaybatdauxuly.Text = "";
            txtTennhiemvu.Text = "";
            btnThem.Visible = true;
            btnLuu.Visible = false;
        }

        private bool timQuatrinhCongvan(string ds, string chuoi)
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
        protected void rptQuatrinhXulyCongvan_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            List<CanboEntity> canbodangnhap = (List<CanboEntity>)Session["Canbo"];
            long n = canbodangnhap[0].PK_iCanboID;

            List<PhanQuyen> gltsPhanquen = (new PhanQuyenBRL().layDanhsachPhanquyen(n));
            List<QuyenEntity> gltsquyen = (new QuyenBRL().layDanhsachQuyen(0));
            gltsPhanquen = gltsPhanquen.FindAll(phanquyen => phanquyen.FK_iQuyenID == 15 && phanquyen.DThoigianketthuc >= DateTime.Now);
            if (gltsPhanquen.Count > 0)
            {
                if (e.CommandName == "Sua")
                {
                    if (Convert.ToInt64(e.CommandArgument) > 0)
                    {
                        IQuatrinhCongvan = Convert.ToInt64(e.CommandArgument);
                        List<QuatrinhXulyCongvanEntity> gltsQuatrinhxulyCongan = (new QuatrinhXulyCongvanBRL().gltsQuatrinhxuly(IQuatrinhCongvan));
                        txthanxuly.Text = string.Format("{0 :yyyy-MM-dd}", gltsQuatrinhxulyCongan[0].THanxuly);
                        txtNgaybatdauxuly.Text = string.Format("{0 :yyyy-MM-dd}", gltsQuatrinhxulyCongan[0].DNgaybatdauxuly);
                        txtTennhiemvu.Text = gltsQuatrinhxulyCongan[0].STenNhiemvu;
                        List<CanboEntity> gltsCanbo = (new CanboBRL().GetCanboByPK(Convert.ToInt64(gltsQuatrinhxulyCongan[0].FK_iCanboID)));
                        cboCanboxuly.SelectedItem.Text = gltsCanbo[0].STenCanbo;
                        List<CongvanEntity> gltsCongvan = (new CongvanBRL().GetCongvanGetByPK(gltsQuatrinhxulyCongan[0].FK_iCongvanID));
                        cboSohieu.SelectedItem.Text = gltsCongvan[0].SSohieu;
                        btnLuu.Visible = true;
                        btnThem.Visible = false;
                    }
                }
            }
            gltsPhanquen = ((new PhanQuyenBRL().layDanhsachPhanquyen(n))).FindAll(phanquyen => phanquyen.FK_iQuyenID == 15 && phanquyen.DThoigianketthuc >= DateTime.Now);
            if (gltsPhanquen.Count > 0)
            {
                if (e.CommandName == "Xoa")
                {
                    if (Convert.ToInt64(e.CommandArgument) > 0)
                    {
                        IQuatrinhCongvan = Convert.ToInt64(e.CommandArgument);
                        if ((new QuatrinhXulyCongvanBRL().xoaQuatrinhxulyCongvan(IQuatrinhCongvan)))
                        {
                            Response.Write("<script> alert('Xóa quá trình xử lý" + IQuatrinhCongvan + " thành công !');</script>");
                            xemDanhsachQuatrinhXuly();
                        }
                    }
                }
            }

            if (e.CommandName == "Xemquatrinh")
            {
                IQuatrinhCongvan = Convert.ToInt64(e.CommandArgument);
                Response.Redirect("Ketquaxuly.aspx?ID=" + IQuatrinhCongvan);
            }
        }

        protected void rptQuatrinhXulyCongvan_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                QuatrinhXulyCongvanEntity quatrinhXuly = e.Item.DataItem as QuatrinhXulyCongvanEntity;
                if (quatrinhXuly != null)
                {
                    Literal ltrCanbo = e.Item.FindControl("ltrCanbo") as Literal;
                    if (ltrCanbo != null)
                    {
                        List<CanboEntity> glstCanbo = (new CanboBRL()).GetCanboByPK(quatrinhXuly.FK_iCanboID);
                        if (glstCanbo.Count > 0)
                            ltrCanbo.Text = glstCanbo[0].STenCanbo;
                    }

                    Literal ltrCongvan = e.Item.FindControl("ltrCongvan") as Literal;
                    if (ltrCongvan != null)
                    {
                        List<CongvanEntity> gltsCongvan = (new CongvanBRL().GetCongvanGetByPK(quatrinhXuly.FK_iCongvanID));
                        if (gltsCongvan.Count > 0)
                            ltrCongvan.Text = gltsCongvan[0].SSohieu;
                    }
                }
            }
        }

        protected void btnTimkiem_Click(object sender, EventArgs e)
        {
            List<QuatrinhXulyCongvanEntity> gltsQuatrinhxuly = (new QuatrinhXulyCongvanBRL().gltsQuatrinhXulyCongvan(0));
            if (txtTennhiemvu.Text == "")
            {
                gltsQuatrinhxuly = gltsQuatrinhxuly.FindAll(
                    (quatrinh) =>
                    {
                        return timQuatrinhCongvan(quatrinh.STenNhiemvu, txtTennhiemvu.Text);
                    }
                    );
            }
            if (txthanxuly.Text == "")
            {
                gltsQuatrinhxuly = gltsQuatrinhxuly.FindAll(
               (quatrinh) =>
               {
                   return quatrinh.THanxuly <= DateTime.Parse(txthanxuly.Text);
               }
             );
            }

            if (txtNgaybatdauxuly.Text == "")
            {
                gltsQuatrinhxuly = gltsQuatrinhxuly.FindAll(
               (quatrinh) =>
               {
                   return quatrinh.DNgaybatdauxuly >= DateTime.Parse(txtNgaybatdauxuly.Text);
               }
             );
            }
            if (string.Compare(cboCanboxuly.Text, "tất cả", true) == 0)
            {
                gltsQuatrinhxuly = gltsQuatrinhxuly.FindAll(
                (quatrinh) =>
                {
                    return quatrinh.FK_iCanboID >= Convert.ToInt64(cboCanboxuly.SelectedItem.Value);
                }
              );
            }
            phantranQuatrinh(gltsQuatrinhxuly);
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            long iMaquatrinh = (new QuatrinhXulyCongvanBRL().themQuatrinhxulyCongvan(txtTennhiemvu.Text, Convert.ToInt64(cboCanboxuly.SelectedItem.Value), Convert.ToInt64(cboSohieu.SelectedItem.Value), DateTime.Parse(txtNgaybatdauxuly.Text), DateTime.Parse(txthanxuly.Text)));
            Response.Write("<script>alert('Đã thêm quá trình " + iMaquatrinh + ". Xin cảm ơn')</script>");
            xemDanhsachQuatrinhXuly();
        }

        protected void btnLuu_Click(object sender, EventArgs e)
        {
            if ((new QuatrinhXulyCongvanBRL().suaQuatrinhXulyCongvan(iQuatrinhCongvan, txtTennhiemvu.Text, Convert.ToInt64(cboSohieu.SelectedItem.Value), Convert.ToInt64(cboCanboxuly.SelectedItem.Value), DateTime.Parse(txtNgaybatdauxuly.Text), DateTime.Parse(txthanxuly.Text))))
            {
                Response.Write("<script>alert('Đã sửa mã quá trình " + iQuatrinhCongvan + ". Xin cảm ơn')</script>");
                xemDanhsachQuatrinhXuly();
            }
        }
    }
}