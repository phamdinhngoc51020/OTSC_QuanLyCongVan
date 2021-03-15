<%@ Page Title="" Language="C#" MasterPageFile="~/MasterQuanLyCongVan.Master" AutoEventWireup="true" CodeBehind="Canbo.aspx.cs" Inherits="QuanLyCongVan.Canbo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">
    <div class="main">
        <div class="input"style="margin:auto">
                <table style="margin:auto;width:80%">
                    <tr>
                        <td>
                            <asp:Label ID="lblTenCanbo" runat="server" Text="Tên cán bộ"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblSodienthoai" runat="server" Text="Số điện thoại"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblNgaysinh" runat="server" Text="Ngày sinh"></asp:Label></td>
                        </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtTenCanbo" runat="server" ></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtSodienthoai" runat="server" ></asp:TextBox>
                        </td>
                        <td>
                             <asp:TextBox ID="txtEmail" runat="server" ></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNgaysinh" TextMode="date"  runat="server"></asp:TextBox>
                        </td>
                        </tr>
                    <tr>
                        <td>
                    <asp:RequiredFieldValidator ControlToValidate="txtTenCanbo" ID="rfvTenCanbo" runat="server" ErrorMessage="Bạn phải nhập dữ liệu" ForeColor="Red" ValidationGroup="add" Display="Dynamic" SetFocusOnError="true" ></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ControlToValidate="txtSodienthoai" ID="rfvSodienthoai" runat="server" ErrorMessage="Bạn phải nhập dữ liệu" ForeColor="Red" ValidationGroup="add" Display="Dynamic" SetFocusOnError="true" ></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ControlToValidate="txtEmail" ID="rfvEmail" runat="server" ErrorMessage="Bạn phải nhập dữ liệu" ForeColor="Red" ValidationGroup="add" Display="Dynamic" SetFocusOnError="true" ></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ControlToValidate="txtNgaysinh" ID="rfvNgaysinh" runat="server" ErrorMessage="Bạn phải nhập dữ liệu" ForeColor="Red" ValidationGroup="add" SetFocusOnError="true" Display="Dynamic" ></asp:RequiredFieldValidator>
                        </td>
                        </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblGioitinh" runat="server" Text="Giới tính"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblDiachi" runat="server" Text="Địa chỉ"></asp:Label>
                        </td>
                         <td>
                            <asp:Label ID="lblCmnd" runat="server" Text="Chứng minh thư"></asp:Label>
                        </td>
                        </tr>
                    <tr>
                        <td >
                            <asp:RadioButton ID="rdbNam" runat="server" GroupName="Gioitinh" Checked="true"/>Nam
                        </td>
                        <td>
                            <asp:RadioButton ID="rdbNu" runat="server" GroupName="Gioitinh" />Nữ
                        </td>
                        <td>
                            <asp:TextBox ID="txtDiachi"  runat="server" ></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCmnd"  runat="server" ></asp:TextBox>
                        </td>
                        </tr>
                    <tr>
                        <td colspan="2"></td>
                        <td>
                             <asp:RequiredFieldValidator ControlToValidate="txtDiachi" ID="rfvDiachi" runat="server" ErrorMessage="Bạn phải nhập dữ liệu" ForeColor="Red" ValidationGroup="add" SetFocusOnError="true" Display="Dynamic" ></asp:RequiredFieldValidator>
                        </td>     
                        <td>
                             <asp:RequiredFieldValidator ControlToValidate="txtCmnd" ID="rfvCmnd" runat="server" ErrorMessage="Bạn phải nhập dữ liệu" ForeColor="Red" ValidationGroup="add" SetFocusOnError="true" Display="Dynamic" ></asp:RequiredFieldValidator>
                        </td>    
                        </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" Text="Tài khoản"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label6" runat="server" Text="Mật khẩu"></asp:Label>
                        </td>
                        </tr>
                    <tr>
                         <td>
                            <asp:TextBox ID="txtTaikhoan"  runat="server" ></asp:TextBox>
                        </td>
                         <td>
                            <asp:TextBox ID="txtMatkhau"  runat="server" ></asp:TextBox>
                        </td>
                        </tr>
                    <tr>
                        <td>
                            <asp:RequiredFieldValidator ControlToValidate="txtTaikhoan" ID="rfvTaikhoan" runat="server" ErrorMessage="Bạn phải nhập dữ liệu" ForeColor="Red" ValidationGroup="add" SetFocusOnError="true" Display="Dynamic" ></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ControlToValidate="txtMatkhau" ID="RequiredFieldValidator6" runat="server" ErrorMessage="Bạn phải nhập dữ liệu" ForeColor="Red" ValidationGroup="add" SetFocusOnError="true" Display="Dynamic" ></asp:RequiredFieldValidator>
                        </td>
                        </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="btnThem" runat="server" Text="Thêm"  ValidationGroup="add"  CssClass="font btn"  style="height: 29px;background: #1a75ff" OnClick="btnThem_Click"/>
                        </td>
                        <td >
                            <asp:Button ID="btnTimkiem" runat="server" Text="Tim kiếm"  style="height: 29px;background: #1a75ff" CssClass="font btn" />
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td >
                            <asp:Button ID="btnLuu" runat="server" Text="Lưu" Visible="false"  CssClass="font btn"  Style="height: 29px;background: #1a75ff" OnClick="btnLuu_Click"/>
                        </td>
                        <td >
                            <asp:Button ID="btnHuy" runat="server" Text="Hủy" Visible="false"  CssClass="font btn" OnClick="btnHuy_Click"/>
                        </td>
                    </tr>
                    </table>                 
            </div>
        <div class="container-data" style="overflow-x:scroll;overflow-y:scroll">
            <asp:Repeater ID="rptCanbo" runat="server" OnItemCommand="rptCanbo_ItemCommand"  >
                <HeaderTemplate>
                    <table border="3" style="margin:auto;width:70%">
                        <tr>
                            <th>STT</th>
                            <th>Tên cán bộ</th>
                            <th>Số điện thoại</th>
                            <th>Email</th>
                            <th>Ngày sinh</th>
                            <th>Giới tính</th>
                            <th>Địa chỉ</th>
                            <th>CMND</th>
                            <th>Tài khoản</th>
                            <th>Mật khẩu</th>
                            <th colspan="2">Xử lý</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td ><%# Container.ItemIndex +1 %></td>
                        <td ><%# Eval("STenCanbo")  %></td>
                        <td ><%# Eval("SSodienthoai")  %></td>
                        <td ><%# Eval("SEmail")  %></td>
                        <td><%# Eval("TNgaySinh","{0: dd/MM/yyyy}")%></td>
                        <td><%# string.Format("{0}",(bool)Eval("BGioiTinh")?"Nam":"Nữ")%></td>
                        <td ><%# Eval("SDiaChi")  %></td>
                        <td ><%# Eval("SCMND") %></td>
                        <td ><%# Eval("STenTaikhoan") %></td>
                        <td ><%# Eval("SMatkhau") %></td>
                        <td class="btn-xuly">
                             <asp:LinkButton ID="lkSua" runat="server" CommandName="Sua" Text="Sửa"
                        CommandArgument='<%# Eval("PK_iCanboID") %>' CssClass="fa-2x"><i style="color:#0066cc" class="fa fa-pencil-square-o" aria-hidden="true"></i></asp:LinkButton>
                         <td class="btn-xuly">
                            <asp:Button ID="btnXemlichsuCongtac" runat="server" Text="Lịch sử công tác"  CommandName="xemLichsuCongtac" CommandArgument='<%# Eval("PK_iCanboID") %>' /></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <div style="text-align:center;padding-top:50px;margin:auto">
                <asp:Repeater ID="rptPages" runat="server"  >
                    <ItemTemplate>
                        <asp:LinkButton ID="btnPage" style="padding:1px 3px; margin:1px; background:#ccc"
                            CommandName="Page" CommandArgument="<%# Container.DataItem %>"
                            runat="server"><%# Container.DataItem %>
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:Repeater>
        </div>
        </div>
</asp:Content>
