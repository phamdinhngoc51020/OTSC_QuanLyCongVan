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
    public partial class LichsuCongtac : System.Web.UI.Page
    {
        private long canboID;
        private long chucvuID;
        private long bophanID;

        private void hienDanhsachPhantrang(List<LichsucongtacEntity> glstLichsuCongtac)
        {
            PagedDataSource pgitems = new PagedDataSource();
            pgitems.DataSource = glstLichsuCongtac;
            pgitems.AllowPaging = true;
            pgitems.PageSize = 5;
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
            rptLichsuCongtac.DataSource = pgitems;
            rptLichsuCongtac.DataBind();
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

        private void xemDanhsachBophan()
        {
            List<BophanEntity> gltsBophan = (new BophanBRL().GetBophanByPK(0));
            cboTenBophan.DataSource = gltsBophan;
            cboTenBophan.DataTextField = "STenBophan";
            cboTenBophan.DataValueField = "PK_iBophanID";
            cboTenBophan.DataBind();
        }

        private void xemDanhsachCanbo()
        {
            List<CanboEntity> gltsCanbo = (new CanboBRL().GetCanboByPK(0));
            cboTenCanbo.DataSource = gltsCanbo;
            cboTenCanbo.DataTextField = "STenCanbo";
            cboTenCanbo.DataValueField = "PK_iCanboID";
            cboTenCanbo.DataBind();
        }
        private void xemDanhsachChucvu()
        {
            List<ChucvuEntity> gltsChucvu = (new ChucvuBRL().GetChucvuByPK(0));
            cboTenChucvu.DataSource = gltsChucvu;
            cboTenChucvu.DataTextField = "STenChucvu";
            cboTenChucvu.DataValueField = "PK_iChucvuID";
            cboTenChucvu.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            btnThem.Visible = true;
            btnLuu.Visible = false;
            if (!Page.IsPostBack)
            {
                xemDanhsachCanbo();
                xemDanhsachChucvu();
                xemDanhsachBophan();
                xemLichsuCongtac();
            }
        }

        private void xemLichsuCongtac()
        {
            List<LichsucongtacEntity> glstLichsuCongtac = (new LichsucongtacBRL()).gltsLichsucongtac(0);
            hienDanhsachPhantrang(glstLichsuCongtac);
        }

        protected void rptLichsuCongtac_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LichsucongtacEntity lichsucongtac = e.Item.DataItem as LichsucongtacEntity;
                if (lichsucongtac != null)
                {
                    Literal ltrBophan = e.Item.FindControl("ltrBophan") as Literal;
                    if (ltrBophan != null)
                    {
                        List<BophanEntity> glstBophan = (new BophanBRL()).GetBophanByPK(lichsucongtac.FK_iBophanID);
                        if (glstBophan.Count > 0)
                            ltrBophan.Text = glstBophan[0].STenBophan;
                    }

                    Literal ltrChucvu = e.Item.FindControl("ltrChucvu") as Literal;
                    if (ltrChucvu != null)
                    {
                        List<ChucvuEntity> gltsChucvu = (new ChucvuBRL().GetChucvuByPK(lichsucongtac.FK_iChucvuID));
                        if (gltsChucvu.Count > 0)
                            ltrChucvu.Text = gltsChucvu[0].STenChucvu;
                    }
                    Literal ltrCanbo = e.Item.FindControl("ltrCanbo") as Literal;
                    if (ltrCanbo != null)
                    {
                        List<CanboEntity> gltsCanbo = (new CanboBRL().GetCanboByPK(lichsucongtac.FK_iCanboID));
                        if (gltsCanbo.Count > 0)
                            ltrCanbo.Text = gltsCanbo[0].STenCanbo;
                    }
                }
            }
        }

        protected void rptLichsuCongtac_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void rptPages_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
    }
}