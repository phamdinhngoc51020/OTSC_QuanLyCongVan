<%@ Page Title="" Language="C#" MasterPageFile="~/MasterQuanLyCongVan.Master" AutoEventWireup="true" CodeBehind="LichsuCongtac.aspx.cs" Inherits="QuanLyCongVan.LichsuCongtac" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">
    <style>
        /*.font {
            font-size: 16px;
        }

        .xuly {
            padding: 10px 20px;
            margin: 0 auto;
            display: block;
            width: 50%;
            padding-left: 20px;
        }

        .input {
            font-size: 16px;
            height: 2em;
        }

        .btn {
            width: 4.4em;
            height: 2em;
            border-radius: 5px;
            color:white;
            text-shadow: 0 1px 4px rgba(0,0,0,.2);
        }*/
         /*.font {
            font-size: 16px;
        }

        .xuly {
            padding: 10px 20px;
            margin: 0 auto;
            display: block;
            width: 50%;
            padding-left: 20px;
        }

        .input {
            font-size: 16px;
            height: 2em;
        }

        .btn {
            width: 4.4em;
            height: 2em;
            border-radius: 5px;
            color:white;
            text-shadow: 0 1px 4px rgba(0,0,0,.2);
        }*/
         .main{}
    </style>
    <div class="main">
        <div class="input" style="margin: auto">
            <table style="margin: auto; width: 80%">
                <tr>
                    <td>
                        <asp:Label ID="lblTenBophan" runat="server" Text="Tên bộ phận"></asp:Label></td>
                    <td>
                        <asp:Label ID="lblTenChucvu" runat="server" Text="Tên chức vụ"></asp:Label></td>
                    <td>
                        <asp:Label ID="lblTenCanbo" runat="server" Text="Tên cán bộ"></asp:Label></td>
                    <td>
                        <asp:Label ID="lblThoigianbatdau" runat="server" Text="Thời gian bắt đầu"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="cboTenBophan" runat="server"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="cboTenChucvu" runat="server"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="cboTenCanbo" runat="server"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="txtThoigianbatdau" TextMode="date" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td>
                        <asp:RequiredFieldValidator ControlToValidate="txtThoigianbatdau" ID="rfvThoigianbatdau" runat="server" ErrorMessage="Bạn phải nhập dữ liệu" ForeColor="Red" ValidationGroup="add" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblThoigianketthuc" runat="server" Text="Thời gian kết thúc"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtThoigianketthuc" TextMode="date" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RequiredFieldValidator ControlToValidate="txtThoigianketthuc" ID="rfvThoigianketthuc" runat="server" ErrorMessage="Bạn phải nhập dữ liệu" ForeColor="Red" ValidationGroup="add" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnThem" runat="server" Text="Thêm" ValidationGroup="add" CssClass="font btn" Style="height: 29px; background: #1a75ff" />
                    </td>
                    <td>
                        <asp:Button ID="btnTimkiem" runat="server" Text="Tim kiếm" Style="height: 29px; background: #1a75ff" CssClass="font btn" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnLuu" runat="server" Text="Lưu" Visible="false" CssClass="font btn" Style="height: 29px; background: #1a75ff" />
                    </td>
                    <td>
                        <asp:Button ID="btnHuy" runat="server" Text="Hủy" Visible="false" CssClass="font btn" />
                    </td>
                </tr>
            </table>
        </div>
        <div id="ketquadulieu" style="overflow-x: scroll; overflow-y: scroll; margin: auto; width: 80%">
            <asp:Repeater ID="rptLichsuCongtac" runat="server" OnItemCommand="rptLichsuCongtac_ItemCommand" OnItemDataBound="rptLichsuCongtac_ItemDataBound">
                <HeaderTemplate>
                    <table class="dulieu" border="1" style="margin: auto; width: 100%; text-align: center; margin-top: 24px!important;">
                        <tr>
                            <th>STT</th>
                            <th>Tên bộ phận</th>
                            <th>Chức chức vụ</th>
                            <th>Mã cán bộ</th>
                            <th>Thời gian bắt đầu</th>
                            <th>Thời gian kết thúc</th>
                            <th colspan="2">Xử lý</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Container.ItemIndex +1 %></td>
                        <td>
                            <asp:Literal ID="ltrbophan" runat="server"></asp:Literal></td>
                        <td>
                            <asp:Literal ID="ltrChucvu" runat="server"></asp:Literal></td>
                        <td>
                            <asp:Literal ID="ltrCanbo" runat="server"></asp:Literal></td>
                        <td><%# Eval("TThoigianbatdau","{0: dd/MM/yyyy}")%></td>
                        <td><%# String.Format( Eval("TThoigianketthuc","{0: dd/MM/yyyy}"))=="01/01/0001"?"Null":Eval("TThoigianketthuc","{0: dd/MM/yyyy}")%></td>
                        <td style="width: 60px">
                            <asp:LinkButton ID="btnSua" runat="server" CommandName="Sua" Text="Sửa"
                                CommandArgument='<%# Eval("PK_iLichsucongtacID") %>' CssClass="fa-2x"><i style="color:#0066cc" class="fa fa-pencil-square-o" aria-hidden="true"></i></asp:LinkButton>
                        </td>
                        <td style="width: 60px">
                            <%--<a href='javascript:xoaBophan(<%# Eval("MaBophan") %>)'><span style="color: red" class="fa fa-times" aria-hidden="true"></span>
                            </a>--%>
                            <asp:LinkButton ID="btnXoa" runat="server" CommandName="Xoa" Text="Xóa"
                                CommandArgument='<%# Eval("PK_iLichsucongtacID")  %>' OnClientClick="return confirm('Bạn chắc chắn muốn xóa?');" CssClass="fa-2x"><span style="color:red" class="fa fa-times" aria-hidden="true" ></span></asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <div style="text-align: center; padding-top: 50px; margin: auto">
                <asp:Repeater ID="rptPages" runat="server" OnItemCommand="rptPages_ItemCommand">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnPage" Style="padding: 1px 3px; margin: 1px; background: #ccc"
                            CommandName="Page" CommandArgument="<%# Container.DataItem %>"
                            runat="server"><%# Container.DataItem %>
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
