<%@ Page Title="" Language="C#" MasterPageFile="~/MasterQuanLyCongVan.Master" AutoEventWireup="true" CodeBehind="Chucvu.aspx.cs" Inherits="QuanLyCongVan.Chucvu" %>

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
            padding: 0px 10px;
        }

        .btn {
            width: 4.4em;
            height: 2em;
            border-radius: 5px;
            color: white;
            text-shadow: 0 1px 4px rgba(0,0,0,.2);
        }
    </style>
    <script type="text/javascript">
        function xoaChucvu(chucvuID) {
            if (confirm("Bạn có muốn xóa chức vụ này không ?")) {
                var context = "xoa#";
                var eventArg = context + chucvuID;
                <%= CallbackRefernce%>
            }
        }

        function themChucvu() {
            var ten = document.getElementById('<%= txtTen.ClientID%>');
            var soluong = document.getElementById('<%= txtSoluong.ClientID%>')
            if (ten.value == "" || soluong.value=="") {
                alert("Bạn cần nhập đủ dữ liệu");
            } else {
                if (confirm("Bạn có chắc chắn muốn thêm chức vụ này?")) {
                    var context = "them#";
                    var eventArg = context + ten.value +"_"+ soluong.value;
                    <%= CallbackRefernce%>;
                }
            }
        }

        function danhsachChucvu(data, context) {
            if (data == "Thatbai#") {
                alert("Không thành công do Chức vụ này đã được sử dụng");
            } else {
                switch (context) {
                    case "xoa#":
                        var danhsach = document.getElementById('ketquadulieu');
                        danhsach.innerHTML = data;
                        alert("Xóa thành công!")
                        break;
                    case "them#":
                        var danhsach = document.getElementById('ketquadulieu');
                        danhsach.innerHTML = data;
                        var ten = document.getElementById('<%= txtTen.ClientID%>');
                        var soluong = document.getElementById('<%= txtSoluong.ClientID%>');
                        ten.value = "";
                        soluong.value = "";
                        alert("Thêm thành công !");
                        break;
                }
            }
        }
    </script>
    <div class="xuly">
        <table style="margin: auto">
            <tr>
                <td>
                    <asp:Label ID="lblTen" runat="server" Text="Tên chức vụ:" CssClass="font"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtTen" runat="server" placeholder="Nhập tên chức vụ" CssClass="font input"></asp:TextBox></td>
                <%--<td>
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="fa-2x"><span class="fa fa-search" aria-hidden="true"></span></asp:LinkButton></td>--%>
            </tr>
            <tr>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Style="color: red" ErrorMessage="*Trường này không được để trống !" ControlToValidate="txtTen" Font-Size="16px" ValidationGroup="xuly" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblSoluong" runat="server" Text="Số lượng:" CssClass="font"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtSoluong" runat="server" TextMode="number" CssClass="font input"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtSoluong" ValidationExpression="([1-9])*" ErrorMessage="*Số lượng phải lớn hơn 0 !" Style="color: red" Font-Size="16px" ValidationGroup="xuly" SetFocusOnError="true" Display="Dynamic"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnThem" runat="server" Text="Thêm" ValidationGroup="xuly" CssClass="font btn" Style="background: #1a75ff" OnClick="btnThem_Click" />
                    <a href='javascript:themChucvu()'>Them</a>
                </td>
                <td>
                    <asp:Button ID="btnTimkiem" runat="server" Text="Tìm kiếm" CssClass="font btn" Style="background: #1a75ff" OnClick="btnTimkiem_Click" /></td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnLuu" runat="server" Text="Lưu" CssClass="font btn" Style="background: #1a75ff" OnClick="btnLuu_Click" /></td>
                <td>
                    <asp:Button ID="btnHuy" runat="server" Text="Hủy" CssClass="font btn" OnClick="btnHuy_Click" /></td>
            </tr>
        </table>
    </div>
    <div id="ketquadulieu"  style="overflow-x:scroll;overflow-y:scroll; margin:auto; width: 80%;height:400px">
    <asp:Repeater ID="Repeater1" runat="server"  OnItemDataBound="Repeater1_ItemDataBound">
        <HeaderTemplate>
            <table class="dulieu" border="1" style="margin: auto; width: 100%; text-align: center; margin-top: 24px!important;">
                <tr>
                    <th>STT</th>
                    <%--<th>Mã bộ phân</th>--%>
                    <th>Tên chức vụ</th>
                    <th>Số lượng</th>
                    <th colspan="2">Xử lý</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Container.ItemIndex +1 %></td>
                <%-- <td><%# Eval("MaBophan")%></td>--%>
                <td><%# Eval("TenChucvu")%></td>
                <td><%# Eval("SoLuong") %></td>
                <td style="width: 60px">
                    <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Sua" Text="Sửa"
                        CommandArgument='<%# Eval("MaChucvu") %>' CssClass="fa-2x"><i style="color:#0066cc" class="fa fa-pencil-square-o" aria-hidden="true"></i></asp:LinkButton>
                </td>
                <td style="width: 60px">
                    <a href='javascript:xoaChucvu(<%# Eval("MaChucvu") %>)' class="fa-2x"><span style="color:red" class="fa fa-times" aria-hidden="true" ></span></a>
                </td>
            </tr>
            <tr>
                <td></td>
                <td colspan="2">
            <asp:Repeater ID="Repeater3" runat="server" >
                    <HeaderTemplate>
                        <table  border="1" style="margin: auto;width:80%; text-align: center" >
                            <tr>
                                <th>STT</th>
                                <%--<th>Mã bộ phân</th>--%>
                                <th>Mã</th>
                                <th>tên</th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%# Container.ItemIndex +1 %></td>
                            <%-- <td><%# Eval("MaBophan")%></td>--%>
                            <td><%# Eval("MaCabo")%></td>
                            <td><%# Eval("TenCanbo") %></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
                    </td>
                </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
        </div>
</asp:Content>
