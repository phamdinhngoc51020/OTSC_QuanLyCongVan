<%@ Page Title="" Language="C#" MasterPageFile="~/MasterQuanLyCongVan.Master" AutoEventWireup="true" CodeBehind="Ketquaxuly.aspx.cs" Inherits="QuanLyCongVan.Ketquaxuly" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">
    <div class="container">
        <div class="container-input" style="margin:auto">
                <table style="margin:auto;width:80%">
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblTrangthai" runat="server" Text="Trạng thái"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblNhiemvu" runat="server" Text="Mô tả"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblThoigianghinhan" runat="server" Text="Thời gian ghi nhận"></asp:Label>
                        </td>
                        </tr>
                    <tr>
                        <td>
                           <asp:RadioButton ID="rdbhoanthanh" GroupName="Trangthai" runat="server" Text="Hoàn thành"></asp:RadioButton>
                        </td>
                        <td>
                           <asp:RadioButton ID="rdbChuahoanthanh" GroupName="Trangthai" runat="server" Text="Chưa hoàn thành"></asp:RadioButton>
                        </td>
                        <td>
                            <asp:TextBox ID="txtThoigianghinhan" TextMode="date" runat="server" ></asp:TextBox>
                        </td>
                        <td>
                            <asp:DropDownList ID="cboNhiemvu" runat="server" DataTextField="STenNhiemvu" DataValueField="PK_iMaQuatrinhXulyCongvan"  Width="150px" OnSelectedIndexChanged="cboNhiemvu_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                        </td>
                        </tr>
                    <tr>
                        <td colspan="2">

                        </td>
                        <td>
                            
                        </td>
                        <td>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="cboNhiemvu"></asp:RequiredFieldValidator>--%>
                        </td>
                        </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblMota" runat="server" Text="Mô tả"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblNguoighinhan" runat="server" Text="Người ghi nhận"></asp:Label>
                        </td>
                        </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtMota" runat="server" ></asp:TextBox>
                        </td>
                        <td>
                             <asp:DropDownList ID="cboNguoighinhan" runat="server" DataTextField="STencanbo" DataValueField="Pk_iMaCanbo" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="cboNguoighinhan_SelectedIndexChanged"></asp:DropDownList>
                        </td>
                        </tr>
                    <tr>
                        <td>
                            
                        </td>
                        <td>
                            
                        </td>
                        </tr>
                    <tr>
                        <td></td>
                        <td><asp:Button ID="btnThem" runat="server" Text="Thêm" OnClick="btnThem_Click"  /></td>
                        <td><asp:Button ID="btnTimkiem" runat="server" Text="Tim kiếm"  /></td>
                        </tr>
                    <tr>
                        <td> <asp:Button ID="btnLuu" runat="server" Text="Lưu" OnClick="btnLuu_Click"  /></td>
                        <td>
                            <asp:Button ID="btnHuy" runat="server" Text="Hủy"/>
                        </td>
                    </tr>
                </table>
        </div>
        <div class="container-data">
            <asp:Repeater ID="rptKetquaQuatrinh" runat="server" OnItemDataBound="rptKetquaQuatrinh_ItemDataBound" OnItemCommand="rptKetquaQuatrinh_ItemCommand">
                <HeaderTemplate>
                    <table border="3">
                        <tr>
                            <th>STT</th>
                            <th>Trạng thái xử lý</th>
                            <th>Thời gian ghi nhận</th>
                            <th>Nhiệm vụ xử lý</th>
                            <th>Mô tả</th>
                            <th>Người ghi nhận</th>
                            <th colspan="3">Xử lý</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                         <td><%# Container.ItemIndex +1 %></td>
                        <td><%# Convert.ToBoolean(Eval("BTrangthai"))== true? "Hoàn thành":"Chưa hoàn thành"  %></td>
                        <td><%# string.Format("{0:dd/MM/yyyy}",Eval("DThoigianghinhan"))  %></td>
                        <td>
                            <asp:Literal ID="ltrNhiemvu" runat="server"></asp:Literal>

                        </td>
                        <td><%# Eval("SMota")  %></td>
                        <td>
                            <asp:Literal ID="ltrCanbo" runat="server"></asp:Literal>
                        </td>
                        <td>
                            <asp:Button ID="btnSua" runat="server" Text="Sửa" CommandName="Sua" CommandArgument='<%# Eval("PK_iMaketquaQuatrinhID") %>' /></td>
                        <td>
                            <asp:Button ID="btnXoa" runat="server" Text="Xóa" CommandName="Xoa" CommandArgument='<%# Eval("PK_iMaketquaQuatrinhID") %>' /></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <div class="container-phantrang">
            <asp:Repeater ID="rptPage" runat="server">
                <ItemTemplate>
                    <asp:LinkButton ID="lbtPage" CommandName="Page" runat="server" CommandArgument='<%# Container.DataItem %>'><%# Container.DataItem %></asp:LinkButton>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>