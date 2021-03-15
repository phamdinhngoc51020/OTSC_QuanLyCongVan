using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanlyCongvan.BRL;
using QuanlyCongvan.Entity;
using System.IO;


namespace QuanLyCongVan
{
    public partial class Bophan : System.Web.UI.Page, ICallbackEventHandler
    {
        static long suaBophanID;
        private string m_Ketqua;
        private string m_CallbackRefernce;
        private void hienDanhsachBophan()
        {
            List<BophanEntity> glstBophan = (new BophanBRL()).GetBophanByPK(0);
            //Repeater1.DataSource = glstBophan;
            PagedDataSource pgitems = new PagedDataSource();
            pgitems.DataSource = glstBophan;
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
            Repeater1.DataSource = pgitems;
            Repeater1.DataBind();
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

        public string Ketqua { get => m_Ketqua; set => m_Ketqua = value; }
        public string CallbackRefernce { get => m_CallbackRefernce; set => m_CallbackRefernce = value; }

        protected void Page_Load(object sender, EventArgs e)
        {
           

            
            CallbackRefernce = Page.ClientScript.GetCallbackEventReference(this, "eventArg", "xemDanhsachBophan", "context", null, true);
            //btnLuu.Visible = false;
            btnHuy.Visible = false;
            if (!IsPostBack)
                hienDanhsachBophan();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Sua")

            {
                btnThem.Visible = false;
                btnTimkiem.Visible = false;
                //btnLuu.Visible = true;
                btnHuy.Visible = true;
                long maBophan = Convert.ToInt64(e.CommandArgument);
                suaBophanID = maBophan;
                if (maBophan > 0)
                {
                    List<BophanEntity> glstBophan = (new BophanBRL()).GetBophanByPK(maBophan);
                    //e.Item.FindControl("txtTen").Text= glstBophan[0].TenBophan;
                    txtTen.Text = glstBophan[0].STenBophan;
                }


            }
            //if (e.CommandName == "Xoa")
            //{
            //    long nvID = Convert.ToInt64(e.CommandArgument);
            //    //Response.Write("<script> alert(nvID);</script>");
            //    bool nhanvienBUS = (new BophanBRL()).XoaBophan(nvID);
            //    if (nhanvienBUS)
            //    {
            //        Response.Write("<script> alert('Xóa thành công!');</script>");
            //        hienDanhsachBophan();
            //        reset();
            //    }
            //    else
            //        Response.Write("<script> alert('Xóa không thành công!');</script>");
            //}
        }
        private void reset()
        {
            txtTen.Text = null;
            btnHuy.Visible = false;
            //btnLuu.Visible = false;
            btnThem.Visible = true;
            btnTimkiem.Visible = true;
        }

        protected void btnLuu_Click(object sender, EventArgs e)
        {
            string ten = txtTen.Text;
            bool nhanvien_BUS = (new BophanBRL()).SuaBophan(suaBophanID, ten);
            if (nhanvien_BUS == true)
            {
                Response.Write("<script> alert('Sửa thành công.');</script>");
                hienDanhsachBophan();
                reset();

            }
            else
                Response.Write("<script> alert('Sửa Không thành công.');</script>");
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            string ten = txtTen.Text;
            BophanBRL bophan = new BophanBRL();
            if (bophan.ThemBophan(ten))
            {
                Response.Write("<script> alert('Thêm thành công.');</script>");
            }
            else
                Response.Write("<script> alert('Tên bộ phận đã sử dụng.');</script>");
            hienDanhsachBophan();
            reset();
        }

        protected void btnHuy_Click(object sender, EventArgs e)
        {
            reset();
        }

        protected void rptPages_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            PageNumber = Convert.ToInt32(e.CommandArgument) - 1;
            hienDanhsachBophan();
            reset();
        }

        public void RaiseCallbackEvent(string eventArgument)
        {
            string[] eventcallback = eventArgument.Split('#');
           
            switch (eventcallback[0].Trim().ToLower())
            {
                case "xoa":
                    long idbophan = Convert.ToInt64(eventcallback[1]);
                    bool kq = (new BophanBRL().XoaBophan(idbophan));
                    if (kq)
                    {
                        hienDanhsachBophan();
                        Ketqua = Updatecontrol(pnlData);
                    }
                    else
                        Ketqua = "Thatbai#";
                    break;
                case "sua":
                    long idtest = Convert.ToInt64(eventcallback[1]);
                    List<BophanEntity> gltsBophan = (new BophanBRL().GetBophanByPK(idtest));
                    txtTen.Text = gltsBophan[0].STenBophan;
                    Ketqua = Updatecontrol(txtTen);
                    break;
                case "luu":
                    bool ketquaLuuBophan = (new BophanBRL().kiemtraBophan(txtTen.Text));
                    if (ketquaLuuBophan)
                    {
                        hienDanhsachBophan();
                        Ketqua = Updatecontrol(Repeater1);
                        //btnLuu.Visible = false;
                        btnThem.Visible = true;
                    }
                    else
                        Ketqua = "Thatbai#";
                    break;
                case "them":
                    string newTenbophan = eventcallback[1];
                    bool ketquaThem = (new BophanBRL().ThemBophan(newTenbophan));
                    if (ketquaThem)
                    {
                        hienDanhsachBophan();
                        Ketqua = Updatecontrol(Repeater1);
                    }
                    else
                        Ketqua = "Thatbai#";
                    break;
            }
        }

        public string Updatecontrol(Control control)
        {
            StringWriter writer = new StringWriter();
            HtmlTextWriter htmwriter = new HtmlTextWriter(writer);
            System.Reflection.MethodInfo mi = typeof(Control).GetMethod("Render", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            mi.Invoke(control, new object[] { htmwriter });

            return string.Format("{0}", writer.ToString());
        }

        public string GetCallbackResult()
        {
            return Ketqua;
        }
    }
}