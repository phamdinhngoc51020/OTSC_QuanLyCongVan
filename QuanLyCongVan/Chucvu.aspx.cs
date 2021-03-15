using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanlyCongvan.BRL;
using QuanlyCongvan.Entity;
using System.IO;
namespace QuanLyCongVan
{
    public partial class Chucvu : System.Web.UI.Page, ICallbackEventHandler
    {
        static long suaChucvuID;
        private string m_Ketqua;
        private string m_CallbackRefernce;

        public string Ketqua { get => m_Ketqua; set => m_Ketqua = value; }
        public string CallbackRefernce { get => m_CallbackRefernce; set => m_CallbackRefernce = value; }

        private void hienDanhsachChucvu()
        {
            List<ChucvuEntity> glstChucvu = (new ChucvuBRL()).GetChucvuByPK(0);
            Repeater1.DataSource = glstChucvu;
            Repeater1.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            CallbackRefernce = Page.ClientScript.GetCallbackEventReference(this, "eventArg", "danhsachChucvu", "context", null, true);
            btnLuu.Visible = false;
            btnHuy.Visible = false;
            if (!IsPostBack)
                hienDanhsachChucvu();
        }

        private void reset()
        {
            txtTen.Text = null;
            btnHuy.Visible = false;
            btnLuu.Visible = false;
            btnThem.Visible = true;
            btnTimkiem.Visible = true;
        }
        protected void btnThem_Click(object sender, EventArgs e)
        {
            string ten = txtTen.Text;
            long soluong = Convert.ToInt64(txtSoluong.Text);
            ChucvuBRL chucvu = new ChucvuBRL();
            long newChucvu = chucvu.ThemChucvu(ten, soluong);
            Response.Write("Đã thêm chức vụ có id là " + newChucvu);
            hienDanhsachChucvu();
            reset();
        }

        protected void btnLuu_Click(object sender, EventArgs e)
        {
            string ten = txtTen.Text;
            long soluong = Convert.ToInt64(txtSoluong.Text);
            bool chucvuBRL = (new ChucvuBRL()).SuaChucvu(suaChucvuID, ten, soluong);
            if (chucvuBRL == true)
            {
                Response.Write("<script> alert('Sửa thành công.');</script>");
                hienDanhsachChucvu();
                reset();

            }
            else
                Response.Write("<script> alert('Sửa Không thành công.');</script>");
        }

        protected void btnHuy_Click(object sender, EventArgs e)
        {
            reset();
        }

        protected void btnTimkiem_Click(object sender, EventArgs e)
        {

        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Sua")

            {
                btnThem.Visible = false;
                btnTimkiem.Visible = false;
                btnLuu.Visible = true;
                btnHuy.Visible = true;
                long maChucvu = Convert.ToInt64(e.CommandArgument);
                suaChucvuID = maChucvu;
                if (maChucvu > 0)
                {
                    List<ChucvuEntity> glstChucvu = (new ChucvuBRL()).GetChucvuByPK(maChucvu);
                    //e.Item.FindControl("txtTen").Text= glstBophan[0].TenBophan;
                    txtTen.Text = glstChucvu[0].STenChucvu;
                    txtSoluong.Text = glstChucvu[0].ISoluong.ToString();
                }


            }
            if (e.CommandName == "Xoa")
            {
                long nvID = Convert.ToInt64(e.CommandArgument);
                //Response.Write("<script> alert(nvID);</script>");
                bool chucvuBUS = (new ChucvuBRL()).XoaChucvu(nvID);
                if (chucvuBUS)
                {
                    Response.Write("<script> alert('Xóa thành công!');</script>");
                    hienDanhsachChucvu();
                    reset();
                }
                else
                    Response.Write("<script> alert('Xóa không thành công!');</script>");
            }
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ChucvuEntity chucvu = e.Item.DataItem as ChucvuEntity;

                Repeater rptrNhanvienChucvu = (Repeater)e.Item.FindControl("Repeater3");
                if (rptrNhanvienChucvu != null)
                {
                    List<CanboEntity> glstCanbo = (new CanboBRL()).GetCanboByPKChucvu(chucvu.PK_iChucvuID);
                    if (glstCanbo.Count() > 0)
                    {
                        rptrNhanvienChucvu.DataSource = glstCanbo;
                        rptrNhanvienChucvu.DataBind();
                    }
                }

            }
        }

        public void RaiseCallbackEvent(string eventArgument)
        {
            string[] eventCallback = eventArgument.Split('#');
            switch (eventCallback[0].Trim().ToLower())
            {
                case "xoa":
                    long ChucvuID = Convert.ToInt64(eventCallback[1]);
                    bool ketqua = (new ChucvuBRL().XoaChucvu(ChucvuID));
                    if (ketqua)
                    {
                        hienDanhsachChucvu();
                        m_Ketqua = Updatecontrol(Repeater1);
                    }
                    else
                        m_Ketqua = "Thatbai#";
                    break;
                case "them":
                    string[] eventArg = eventCallback[1].Split('_');
                    string tenChucvu = eventArg[0];
                    long soluong = Convert.ToInt64(eventArg[1]);
                    long i = (new ChucvuBRL().ThemChucvu(tenChucvu, soluong));
                    if (i>0)
                    {
                        hienDanhsachChucvu();
                        m_Ketqua = Updatecontrol(Repeater1);
                    }
                    else
                        m_Ketqua = "Thatbai#";
                    break;
            }
        }

        private string Updatecontrol(Control control)
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