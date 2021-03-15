<%@ Page Title="" Language="C#" MasterPageFile="~/MasterQuanLyCongVan.Master" AutoEventWireup="true" CodeBehind="Congvan.aspx.cs" Inherits="QuanLyCongVan.Congvan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="server">
    <style>
        .main .container-data{
            /*padding: 10px 20px;*/
            margin: 0 auto;
            display: block;
            max-width:80%;
            max-height:450px;
            /*width: 50%;
            padding-left: 20px;
            display:block;*/
            overflow-x:scroll;
            overflow-y:scroll;
        }
             .font {
            font-size: 16px;
        }
             .btn {
            width: 4.4em;
            height: 2em;
            border-radius: 5px;
            color:white;
            text-shadow: 0 1px 4px rgba(0,0,0,.2);
        }
    </style>
    <div class="main">
        <div class="input"style="margin:auto">
                <table style="margin:auto;width:80%">
                    <tr>
                        <td>
                            <asp:Label ID="lblSohieu" runat="server" Text="Số hiệu"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblCoquan" runat="server" Text="Cơ quan ban hành"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblBanhanh" runat="server" Text="Ngày ban hành"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblNguoiki" runat="server" Text="Người kí"></asp:Label></td>
                        </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtSohieu" runat="server" ></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCoquanbanhanh" runat="server" ></asp:TextBox>
                        </td>
                        <td>
                             <asp:TextBox ID="txtNgaybanhanh"  TextMode="date" runat="server" ></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNguoiki" runat="server"></asp:TextBox>
                        </td>
                        </tr>
                    <tr>
                        <td>
                            <asp:RequiredFieldValidator ControlToValidate="txtSohieu" ID="rfvSohieu" runat="server" ErrorMessage="Bạn phải nhập dữ liệu" ForeColor="Red" ValidationGroup="add" Display="Dynamic" SetFocusOnError="true" ></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ControlToValidate="txtCoquanbanhanh" ID="rfvCoquanbanhanh" runat="server" ErrorMessage="Bạn phải nhập dữ liệu" ForeColor="Red" ValidationGroup="add" Display="Dynamic" SetFocusOnError="true" ></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ControlToValidate="txtNgaybanhanh" ID="rfvNgaybanhanh" runat="server" ErrorMessage="Bạn phải nhập dữ liệu" ForeColor="Red" ValidationGroup="add" Display="Dynamic" SetFocusOnError="true" ></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ControlToValidate="txtNguoiki" ID="rfvNguoiki" runat="server" ErrorMessage="Bạn phải nhập dữ liệu" ForeColor="Red" ValidationGroup="add" SetFocusOnError="true" Display="Dynamic" ></asp:RequiredFieldValidator>
                        </td>
                        </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblCongvan" runat="server" Text="Công văn"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblThoigiandaotao" runat="server" Text="Thời gian tạo"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblHieuluc" runat="server" Text="Ngày hết hiệu lực"></asp:Label>
                        </td>
                        </tr>
                    <tr>
                        <td colspan="2">
                            <asp:FileUpload ID="fCongvan" runat="server" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtThoigiantao" TextMode="date" runat="server" ></asp:TextBox>
                        </td>
                        <td>
                             <asp:TextBox ID="txtNgayhethhieuluc" runat="server" TextMode="date" ></asp:TextBox>
                        </td>
                        </tr>
                    <tr>
                        <td>
                            <asp:CustomValidator ID="cuvFile" runat="server" ErrorMessage="Bạn chưa chọn file" ControlToValidate="fCongvan" Display="Dynamic"  ForeColor="Red" ValidationGroup="add" ></asp:CustomValidator>
                        </td>
                        <td>
                             <asp:RequiredFieldValidator ControlToValidate="txtThoigiantao" ID="rfvThoigiantao" runat="server" ErrorMessage="Bạn phải nhập dữ liệu" ForeColor="Red" ValidationGroup="add" SetFocusOnError="true" Display="Dynamic" ></asp:RequiredFieldValidator>
                        </td>
                        <td>
                             <asp:RequiredFieldValidator ControlToValidate="txtNgayhethhieuluc" ID="rfvNgahehieuluc" runat="server" ErrorMessage="Bạn phải nhập dữ liệu" ForeColor="Red" ValidationGroup="add" SetFocusOnError="true" Display="Dynamic" ></asp:RequiredFieldValidator>
                        </td>
                        </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label7" runat="server" Text="Trích yếu"></asp:Label>
                        </td>
                        </tr>
                    <tr>
                        <td colspan="2">
                             <asp:TextBox ID="txtTrichyeu" runat="server" TextMode="MultiLine" Width="200px" Height="30px"></asp:TextBox>
                        </td>
                        </tr>
                    <tr>
                        <td colspan="2">
                            <asp:RequiredFieldValidator ControlToValidate="txtTrichyeu" ID="rfvTrichyeu" runat="server" ErrorMessage="Bạn phải nhập dữ liệu" ForeColor="Red" ValidationGroup="add" SetFocusOnError="true" Display="Dynamic" ></asp:RequiredFieldValidator>
                        </td>
                        </tr>
                    <tr>
                        <td></td>
                        <td >
                            <asp:Button ID="btnThem" runat="server" Text="Thêm"  ValidationGroup="add" OnClick="btnThem_Click" CssClass="font btn"  Style="background: #1a75ff"/>
                        </td>
                        <td >
                            <asp:Button ID="btnTimkiem" runat="server" Text="Tim kiếm" OnClick="btnTimkiem_Click" style="height: 29px;background: #1a75ff" CssClass="font btn" />
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td >
                            <asp:Button ID="btnLuu" runat="server" Text="Lưu" Visible="false" OnClick="btnLuu_Click" CssClass="font btn"  Style="background: #1a75ff"/>
                        </td>
                        <td >
                            <asp:Button ID="btnHuy" runat="server" Text="Hủy" Visible="false" OnClick="btnHuy_Click" CssClass="font btn"/>
                        </td>
                    </tr>
                    </table>                 
            </div>
        <div class="container-data">
            <asp:Repeater ID="rptQuanLycongVan" runat="server" OnItemCommand="rptQuanLycongVan_ItemCommand" >
                <HeaderTemplate>
                    <table border="3" style="margin:auto;width:80%">
                        <tr>
                            <th>STT</th>
                            <th>Số hiệu</th>
                            <th>Cơ quan ban hành</th>
                            <th>Ngày ban hành</th>
                            <th>Người kí</th>
                            <th>Trích yếu</th>
                            <th>File</th>
                            <th>Ngày hết hiệu lực</th>
                            <th>Thời gian tạo</th>
                            <th colspan="2">Xử lý</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td ><%# Container.ItemIndex +1 %></td>
                        <td class="data-sohieu"><%# Eval("SSohieu")  %></td>
                        <td class="data-coquan"><%# Eval("SCoquanbanhanh")  %></td>
                        <td class="data-date"><%# string.Format("{0:dd/MM/yyyy}", Eval("TNgaybanhanh"))%></td>
                        <td class="data-nguoiki"><%# Eval("SNguoiky")  %></td>
                        <td class="data-trichyeu" style="width:200px !important"><%# Eval("STrichyeu")  %></td>
                        <td class="datafile"><a href="Data/<%# Eval("SFile") %>"+"download"+<%# Eval("SFile") %>><%# Eval("SFile") %></a></td>
                        <td class="data-date"><%# string.Format("{0:dd/MM/yyyy}",Eval("TNgayhethieuluc")) %></td>
                        <td class="data-date"><%# string.Format("{0:dd/MM/yyyy}", Eval("TThoigiantao")) %></td>
                        <td class="btn-xuly">
                             <asp:LinkButton ID="lbSua" runat="server" CommandName="Sua" Text="Sửa"
                        CommandArgument='<%# Eval("PK_iMaCongvan") %>' CssClass="fa-2x"><i style="color:#0066cc" class="fa fa-pencil-square-o" aria-hidden="true"></i></asp:LinkButton>
                         <td class="btn-xuly">
                            <asp:Button ID="BtnXemquatrinhxuly" runat="server" Text="Quá trình xử lý"  CommandName="Xemquatrinhxuly" CommandArgument='<%# Eval("PK_iMaCongvan") %>' /></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <div style="text-align:center;padding-top:50px;margin:auto">
                <asp:Repeater ID="rptPages" runat="server" OnItemCommand="rptPages_ItemCommand" >
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