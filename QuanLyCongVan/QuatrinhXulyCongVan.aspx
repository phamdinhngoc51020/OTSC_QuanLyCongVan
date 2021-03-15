<%@ Page Title="" Language="C#" MasterPageFile="~/MasterQuanLyCongVan.Master" AutoEventWireup="true" CodeBehind="QuatrinhXulyCongVan.aspx.cs" Inherits="QuanLyCongVan.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">
    <<div class="main">
        <div class="input" style="margin: auto">
            <table style="margin: auto; width: 90%">
                <tr>
                    <td>
                        <asp:Label ID="lblSohieucongvan" runat="server" Text="Số hiệu công văn"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblTennhiemvu" runat="server" Text="Tên nhiệm vụ"></asp:Label></td>
                    <td>
                        <asp:Label ID="lblNgaybatdau" runat="server" Text="Ngày bắt đầu xử lý"></asp:Label></td>
                    <td>
                        <asp:Label ID="lblHanxuly" runat="server" Text="Hạn xử lý"></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="cboSohieu" runat="server" Width="150px" DataTextField="SSohieuCongvan" DataValueField="PK_iMaCongvan" OnSelectedIndexChanged="cboSohieu_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTennhiemvu" runat="server" Width="150px"></asp:TextBox>

                    </td>
                    <td>
                        <asp:TextBox ID="txtNgaybatdauxuly" TextMode="date" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="txthanxuly" TextMode="date" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvtTtennhiemvu" runat="server" Style="color: red" ErrorMessage="*Trường này không được để trống !" ControlToValidate="txtTennhiemvu" Font-Size="16px" ValidationGroup="xuly" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator></td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvNgaybatdau" runat="server" Style="color: red" ErrorMessage="*Trường này không được để trống !" ControlToValidate="txtNgaybatdauxuly" Font-Size="16px" ValidationGroup="xuly" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td>  <asp:CustomValidator ID="cuvHanxuly" runat="server" ErrorMessage="Ngày hết hạn xử lý phải sau ngày bắt đầu xử lý !" Style="color: red" ControlToValidate="txtHanxuly" Font-Size="16px" ValidationGroup="xuly" SetFocusOnError="true" Display="Dynamic" OnServerValidate="cuvHanxuly_ServerValidate"></asp:CustomValidator></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCanboxuly" runat="server" Text="Cán bộ xử lý"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="cboCanboxuly" runat="server" Width="150px" DataTextField="STencanbo" DataValueField="Pk_iMaCanbo" OnSelectedIndexChanged="cboCanboxuly_SelectedIndexChanged"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnThem" runat="server" Text="Thêm" ValidationGroup="xuly" OnClick="btnThem_Click" CssClass="font btn" Style="background: #1a75ff" />
                    </td>
                    <td>
                        <asp:Button ID="btnTimkiem" runat="server" Text="Tim kiếm" OnClick="btnTimkiem_Click" Style="height: 29px; background: #1a75ff" CssClass="font btn" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnLuu" runat="server" Text="Lưu" Visible="false" OnClick="btnLuu_Click" CssClass="font btn" Style="background: #1a75ff" />
                    </td>
                    <td>
                        <asp:Button ID="btnHuy" runat="server" Text="Hủy" Visible="false" OnClick="btnHuy_Click" CssClass="font btn" style="width: 43px" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="container-data">
            <asp:Repeater ID="rptQuatrinhXulyCongvan" runat="server" OnItemCommand="rptQuatrinhXulyCongvan_ItemCommand" OnItemDataBound="rptQuatrinhXulyCongvan_ItemDataBound">
                <HeaderTemplate>
                    <table border="3" style="margin: auto; width: 90%">
                        <tr>
                            <th>STT</th>
                            <th>Số hiệu công văn xử lý</th>
                            <th>Tên nhiệm vụ</th>
                            <th>Ngày bắt đầu xử lý</th>
                            <th>Hạn xử lý</th>
                            <th>Cán bộ xử lý</th>
                            <th colspan="3">Xử lý</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Container.ItemIndex +1 %></td>
                        <td>
                            <asp:Literal ID="ltrCongvan" runat="server"></asp:Literal></td>
                        <td><%# Eval("STenNhiemvu")  %></td>
                        <td><%# string.Format("{0:dd/MM/yyyy}",Eval("DNgaybatdauxuly"))%></td>
                        <td><%# string.Format("{0:dd/MM/yyyy}",Eval("DHanxuly"))%></td>
                        <td>
                            <asp:Literal ID="ltrCanbo" runat="server"></asp:Literal>
                        </td>
                        <td style="width: 60px">
                            <asp:LinkButton ID="lbtnSua" runat="server" CommandName="Sua" Text="Sửa"
                                CommandArgument='<%#Eval("PK_iMaQuatrinhXulyCongvan") %>' CssClass="fa-2x"><i style="color:#0066cc" class="fa fa-pencil-square-o" aria-hidden="true"></i></asp:LinkButton>
                        </td>
                        <td style="width: 60px">
                            <asp:LinkButton ID="lbtnXoa" runat="server" CommandName="Xoa" Text="Xóa"
                                CommandArgument='<%#Eval("PK_iMaQuatrinhXulyCongvan") %>' OnClientClick="return confirm('Bạn chắc chắn muốn xóa?');" CssClass="fa-2x"><span style="color:red" class="fa fa-times" aria-hidden="true" ></span></asp:LinkButton>
                        </td>
                        <td>
                            <asp:Button ID="btnXemketqua" runat="server" Text="Kết quả" CssClass="btn" CommandName="Xemquatrinh" CommandArgument='<%#Eval("PK_iMaQuatrinhXulyCongvan") %>' /></td>
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
    </div>
</asp:Content>

