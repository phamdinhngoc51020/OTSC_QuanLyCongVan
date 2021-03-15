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
    public partial class Ketquaxuly : System.Web.UI.Page
    {
        private static long ketquaXulyID;
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
            gltsPhanquen = gltsPhanquen.FindAll(phanquyen => phanquyen.FK_iQuyenID == 17 && phanquyen.DThoigianketthuc >= DateTime.Now);
            if (gltsPhanquen.Count > 0)
                btnThem.Enabled = true;
            long quatrinhxuly = Convert.ToInt64(Request.QueryString["ID"]);
            btnLuu.Visible = false;
            if (!Page.IsPostBack)
            {
                xemDanhsachKetquaxuly();
                xemDanhsachCanbo();
                xemDanhsachQuatrinhxuly();
               
            }
        }


        private void xemDanhsachKetquaxuly()
        {
            long quatrinhxuly = Convert.ToInt64(Request.QueryString["ID"]);
            List<KetquaxulyEntity> gltsKetqua = (new KetquaxulyBRL().gltsKetqua(quatrinhxuly));
            PagedDataSource page = new PagedDataSource();
            page.DataSource = gltsKetqua;
            page.AllowPaging = true;
            page.PageSize = 9;
            page.CurrentPageIndex = PageNumber;
            if (page.PageCount > 1)
            {
                rptPage.Visible = true;
                System.Collections.ArrayList arrayage = new System.Collections.ArrayList();
                for (int i = 0; i < page.PageCount; i++)
                {
                    arrayage.Add((i + 1).ToString());
                }
                rptPage.DataSource = arrayage;
                rptPage.DataBind();
            }
            else
            {
                rptPage.Visible = false;
            }
            rptKetquaQuatrinh.DataSource = page;
            rptKetquaQuatrinh.DataBind();
        }

        private void xemDanhsachCanbo()
        {
            List<CanboEntity> gltsCanbo = (new CanboBRL()).GetCanboByPK(0);
            cboNguoighinhan.DataSource = gltsCanbo;
            cboNguoighinhan.DataTextField = "TenCanbo";
            cboNguoighinhan.DataValueField = "MaCabo";
            cboNguoighinhan.DataBind();
            cboNguoighinhan.Items.Insert(0, new ListItem("Tất cả", "0"));
        }

        private void xemDanhsachQuatrinhxuly()
        {
            List<QuatrinhXulyCongvanEntity> gltsQuatrinhxulyCOngvan = (new QuatrinhXulyCongvanBRL().gltsQuatrinhxuly(0));
            cboNhiemvu.DataSource = gltsQuatrinhxulyCOngvan;
            cboNhiemvu.DataTextField = "STenNhiemvu";
            cboNhiemvu.DataValueField = "PK_iMaQuatrinhXulyCongvan";
            cboNhiemvu.DataBind();
            cboNhiemvu.Items.Insert(0, new ListItem("Tất cả", "0"));
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            bool trangthai;
            if (rdbhoanthanh.Checked)
                trangthai = true;
            else
                trangthai = false;
            long iKetquaXulyCongvan = (new KetquaxulyBRL().themKetqua(trangthai, DateTime.Parse(txtThoigianghinhan.Text), Convert.ToInt64(cboNhiemvu.SelectedItem.Value), Convert.ToInt64(cboNguoighinhan.SelectedItem.Value), txtMota.Text));
            Response.Write("<script>alert('Đã thêm kết quả quá trình " + iKetquaXulyCongvan + ". Xin cảm ơn')</script>");
            xemDanhsachQuatrinhxuly();
        }

        protected void rptKetquaQuatrinh_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                KetquaxulyEntity ketqua = e.Item.DataItem as KetquaxulyEntity;
                if (ketqua != null)
                {
                    Literal ltrNhiemvu = e.Item.FindControl("ltrNhiemvu") as Literal;
                    if (ltrNhiemvu != null)
                    {
                        List<QuatrinhXulyCongvanEntity> gltsQuatrinh = (new QuatrinhXulyCongvanBRL()).gltsQuatrinhxuly(ketqua.FK_iQuatrinhxulyID);
                        if (gltsQuatrinh.Count > 0)
                            ltrNhiemvu.Text = gltsQuatrinh[0].STenNhiemvu;
                    }

                    Literal ltrCanbo = e.Item.FindControl("ltrCanbo") as Literal;
                    if (ltrCanbo != null)
                    {
                        List<CanboEntity> gltsCanbo = (new CanboBRL().GetCanboByPK(ketqua.FK_iNguoighinhanID));
                        if (gltsCanbo.Count > 0)
                            ltrCanbo.Text = gltsCanbo[0].STenCanbo;
                    }
                }
            }
        }

        protected void rptKetquaQuatrinh_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            List<CanboEntity> canbodangnhap = (List<CanboEntity>)Session["Canbo"];
            long n = canbodangnhap[0].PK_iCanboID;

            List<PhanQuyen> gltsPhanquen = (new PhanQuyenBRL().layDanhsachPhanquyen(n));
            List<QuyenEntity> gltsquyen = (new QuyenBRL().layDanhsachQuyen(0));
            gltsPhanquen = gltsPhanquen.FindAll(phanquyen => phanquyen.FK_iQuyenID == 18 && phanquyen.DThoigianketthuc >= DateTime.Now);
            if (gltsPhanquen.Count > 0)
            {
                if (e.CommandName == "Sua")
                {
                    btnLuu.Visible = true;
                    btnThem.Visible = false;
                    ketquaXulyID = Convert.ToInt64(e.CommandArgument);
                    if (ketquaXulyID > 0)
                    {
                        List<KetquaxulyEntity> gltsKetquaXuly = (new KetquaxulyBRL().gltsKetqua(ketquaXulyID));
                        txtMota.Text = gltsKetquaXuly[0].SMota;
                        txtThoigianghinhan.Text = string.Format("{0 :yyyy-MM-dd}", gltsKetquaXuly[0].TThoigianghinhan);
                        bool trangthai = gltsKetquaXuly[0].BTrangthaixuly;
                        if (trangthai)
                            rdbhoanthanh.Checked = true;
                        else
                            rdbChuahoanthanh.Checked = true;
                        List<CanboEntity> gltsCanbo = (new CanboBRL().GetCanboByPK(Convert.ToInt64(gltsKetquaXuly[0].FK_iNguoighinhanID)));
                        cboNguoighinhan.SelectedItem.Text = gltsCanbo[0].STenCanbo;
                        cboNguoighinhan.SelectedItem.Value = gltsCanbo[0].PK_iCanboID.ToString();
                        List<QuatrinhXulyCongvanEntity> gltsQuatrinhXuly = (new QuatrinhXulyCongvanBRL().gltsQuatrinhxuly(gltsKetquaXuly[0].FK_iQuatrinhxulyID));
                        cboNhiemvu.SelectedItem.Text = gltsQuatrinhXuly[0].STenNhiemvu;
                        cboNhiemvu.SelectedItem.Value = gltsQuatrinhXuly[0].PK_iQuatrinhxulyCongvanID.ToString();
                    }
                }
            }
            if (e.CommandName == "Xoa")
            {
                ketquaXulyID = Convert.ToInt64(e.CommandArgument);
                if (ketquaXulyID > 0)
                {
                    if(new KetquaxulyBRL().xoaKetquaQuatrinhxuly(ketquaXulyID))
                    {
                        Response.Write("<script>alert('Xóa thành công kết quả sử lý có mã là : " + ketquaXulyID + "')</script>");
                        xemDanhsachKetquaxuly();
                    }    
                }    
            }
        }

        protected void btnLuu_Click(object sender, EventArgs e)
        {
            bool trangthai = true;
            if (rdbhoanthanh.Checked)
                trangthai = true;
            else
                trangthai = false;
            if (new KetquaxulyBRL().suaKetqua(ketquaXulyID, trangthai, DateTime.Parse(txtThoigianghinhan.Text), Convert.ToInt64(cboNhiemvu.SelectedItem.Value), Convert.ToInt64(cboNguoighinhan.SelectedItem.Value), txtMota.Text)){
                Response.Write("<script>alert('Sửa thành công kết quả sử lý có mã là : " + ketquaXulyID + "')</script>");
                xemDanhsachKetquaxuly();
            }
        }

        protected void cboNhiemvu_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<KetquaxulyEntity> glstKetqua = (new KetquaxulyBRL().gltsKetquaXulyGetBYFK_iQuatrinhxulyID(Convert.ToInt64(cboNhiemvu.SelectedItem.Value)));
            PagedDataSource page = new PagedDataSource();
            page.DataSource = glstKetqua;
            page.AllowPaging = true;
            page.PageSize = 9;
            page.CurrentPageIndex = PageNumber;
            if (page.PageCount > 1)
            {
                rptPage.Visible = true;
                System.Collections.ArrayList arrayage = new System.Collections.ArrayList();
                for (int i = 0; i < page.PageCount; i++)
                {
                    arrayage.Add((i + 1).ToString());
                }
                rptPage.DataSource = arrayage;
                rptPage.DataBind();
            }
            else
            {
                rptPage.Visible = false;
            }
            rptKetquaQuatrinh.DataSource = page;
            rptKetquaQuatrinh.DataBind();
        }

        protected void cboNguoighinhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<KetquaxulyEntity> glstKetqua = (new KetquaxulyBRL().gltsKetquaXulyGetBYFK_iNguoighinhanID(Convert.ToInt64(cboNguoighinhan.SelectedItem.Value)));
            PagedDataSource page = new PagedDataSource();
            page.DataSource = glstKetqua;
            page.AllowPaging = true;
            page.PageSize = 9;
            page.CurrentPageIndex = PageNumber;
            if (page.PageCount > 1)
            {
                rptPage.Visible = true;
                System.Collections.ArrayList arrayage = new System.Collections.ArrayList();
                for (int i = 0; i < page.PageCount; i++)
                {
                    arrayage.Add((i + 1).ToString());
                }
                rptPage.DataSource = arrayage;
                rptPage.DataBind();
            }
            else
            {
                rptPage.Visible = false;
            }
            rptKetquaQuatrinh.DataSource = page;
            rptKetquaQuatrinh.DataBind();
        }
    }
}