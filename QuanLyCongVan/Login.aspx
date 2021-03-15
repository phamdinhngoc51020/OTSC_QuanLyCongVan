<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="QuanLyCongVan.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng nhập</title>
    <style type="text/css">
        * {
            margin: 0px;
            padding: 0px;
            box-sizing: border-box;
        }

        .content {
            width: 1024px;
            margin: 0px auto;
        }

            .content .login {
                margin: 0px auto;
                margin-top: 50px;
                width: 300px;
                height: 300px;
                border: 1px solid grey;
                border-radius: 10px;
                text-align: center;
                z-index: 1;
                background: #FFF;
            }

        h2 {
            color: #868787;
            font-family: sans-serif;
            padding-top: 20px;
            padding-bottom: 20px;
        }

        .content .login .txt {
            width: 200px;
            height: 40px;
            margin-bottom: 10px;
            border-radius: 5px;
            border: 1px solid grey;
            padding-left: 20px;
        }

        .content .login .btn {
            width: 200px;
            height: 40px;
            margin-bottom: 15px;
            border-radius: 5px;
            border: none;
            background-color: #45a049;
            color: white;
        }

        .content .login:hover .btn {
            background: #3366CC;
        }

        .tb {
            padding-left: 70px;
            text-align: left;
        }

        .ketqua {
            display: block;
        }
    </style>
</head>
<body>
    <form id="frmLogin" runat="server" action="Trangchu.aspx" method="post">
        <div>
            <div class="content">
                <div class="login">
                    <h2>Login
                    </h2>
                    <asp:TextBox ID="txtTaikhoan" runat="server" placeholder="Nhập tài khoản" CssClass="txt"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTaikhoan" runat="server" ControlToValidate="txtTaikhoan" ErrorMessage="Bạn cần nhập tài khoản" ValidationGroup="btndangnhap" Display="None" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtMatkhau" TextMode="Password" runat="server" placeholder="Nhập mật khẩu" CssClass="txt"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvMatkhau" runat="server" ControlToValidate="txtMatkhau" ErrorMessage="Bạn cần nhập mật khẩu" ValidationGroup="btndangnhap" Display="None" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    <asp:Button ID="btnDangnhap" runat="server" Text="Đăng nhập" CssClass="btn" ValidationGroup="btndangnhap" OnClick="btnDangnhap_Click" />
                    <asp:ValidationSummary ID="vdsDangnhap" runat="server" ValidationGroup="btndangnhap" ForeColor="Red" CssClass="tb" />
                    <asp:Label ID="lblTb" runat="server" ForeColor="Red" CssClass="ketqua"></asp:Label>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
