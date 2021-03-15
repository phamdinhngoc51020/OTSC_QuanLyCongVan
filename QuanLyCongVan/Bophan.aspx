<%@ Page Title="" Language="C#" MasterPageFile="~/MasterQuanLyCongVan.Master" AutoEventWireup="true" CodeBehind="Bophan.aspx.cs" Inherits="QuanLyCongVan.Bophan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">
    <style>
        .font {
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
            color: white;
            text-shadow: 0 1px 4px rgba(0,0,0,.2);
        }
    </style>
    <script type="text/javascript">{
            function xoaBophan(bophan) {
                if (confirm("Bạn có chắc muốn xóa bộ phận này ?")) {
                    var context = "xoa#";
                    var eventArg = context + bophan;
                    <%= CallbackRefernce%>
                }
            }

            function suaBophan() {
                alert("Thêm");
            }

            function luuBophan() {
                var sTenbophan = document.getElementById("txtTen").value;
                var context = "luu#";
                var eventArg = context + sTenbophan;
                   <%= CallbackRefernce%>
            }

            function themBophan() {
                var ten = document.getElementById('<%= txtTen.ClientID%>');
                if (ten.value == "") {
                    alert("Bạn chưa nhập dữ liệu");
                }
                else {
                    if (confirm("Bạn có chắc chắn muốn thêm bộ phận này ?")) {
                        var context = "them#";
                        var ten = document.getElementById('<%= txtTen.ClientID%>');
                        var eventArg = context + ten.value;
                <%= CallbackRefernce%>
                    }
                }
            }
            function xemDanhsachBophan(data, context) {
                if (data == "Thatbai#") {
                    alert("Không thành công");
                }
                else {
                    switch (context) {
                        case "xoa#":
                            var danhsach = document.getElementById('<%= pnlData.ClientID%>');
                            danhsach.innerHTML = data;
                            break;
                        case "sua#":
                            var danhsach = document.getElementById('xuly');
                            danhsach.innerHTML = data;
                            break;
                        case "them#":
                            var danhsach = document.getElementById('<%= pnlData.ClientID%>');
                            danhsach.innerHTML = data;
                            break;
                    }
                }
            }
        }
    </script>
    <div id="xuly" class="xuly" runat="server">
        <table style="margin: auto">
            <tr>
                <td>
                    <asp:Label ID="lblTen" runat="server" Text="Tên bộ phận:" CssClass="font"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtTen" runat="server" placeholder="Nhập tên bộ phận" CssClass="font"></asp:TextBox></td>
                <%--<td>
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="fa-2x"><span class="fa fa-search" aria-hidden="true"></span></asp:LinkButton></td>--%>
            </tr>
            <tr>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Style="color: red" ErrorMessage="*Trường này không được để trống !" ControlToValidate="txtTen" Font-Size="16px" ValidationGroup="xuly" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnThem" runat="server" Text="Thêm" ValidationGroup="xuly" CssClass="font btn" OnClick="btnThem_Click" Style="background: #1a75ff" />
                    <a href='javascript:themBophan()'>Them</a>
                </td>
                <td>
                    <asp:Button ID="btnTimkiem" runat="server" Text="Tìm kiếm" CssClass="font btn" Style="background: #1a75ff" /></td>
            </tr>
            <tr>
                <td>
                    <a href='javascript:luuBophan()'>Lưu<span style="color: red" class="font btn" aria-hidden="true"></span></a></td>
                <%--<asp:Button ID="btnLuu" runat="server" Text="Lưu" CssClass="font btn" OnClick="btnLuu_Click" Style="background: #1a75ff" /></td>--%>
                <td>
                    <asp:Button ID="btnHuy" runat="server" Text="Hủy" CssClass="font btn" OnClick="btnHuy_Click" /></td>
            </tr>
        </table>
    </div>
    <asp:Panel ID="pnlData" runat="server">
        <div id="ketquadulieu" style="overflow-x: scroll; overflow-y: scroll; margin: auto; width: 80%">
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                <HeaderTemplate>
                    <table class="dulieu" border="1" style="margin: auto; width: 100%; text-align: center; margin-top: 24px!important;">
                        <tr>
                            <th>STT</th>
                            <%--<th>Mã bộ phân</th>--%>
                            <th>Tên bộ phận</th>
                            <th colspan="2">Xử lý</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Container.ItemIndex +1 %></td>
                        <%-- <td><%# Eval("MaBophan")%></td>--%>
                        <td><%# Eval("TenBophan")%></td>
                        <td style="width: 60px">
                            <%--<asp:LinkButton ID="LinkButton3" runat="server" CommandName="Sua" Text="Sửa"
                            CommandArgument='<%# Eval("MaBophan") %>' CssClass="fa-2x"><i style="color:#0066cc" class="fa fa-pencil-square-o" aria-hidden="true"></i></asp:LinkButton>--%>
                            <a href='javascript:suaBophan()' class="fa-2x"><span style="color: #0066cc" class="fa fa-pencil-square-o" aria-hidden="true"></span>
                            </a>
                        </td>
                        <td style="width: 60px">
                            <a href='javascript:xoaBophan(<%# Eval("MaBophan") %>)'><span style="color: red" class="fa fa-times" aria-hidden="true"></span>
                            </a>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
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
    </asp:Panel>
</asp:Content>
