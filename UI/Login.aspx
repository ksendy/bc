<%@ Page Title="" Language="C#" MasterPageFile="~/ProgramFiles.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="UI.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>Login</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main_bg">
        <div class="wrap">
            <div class="main">
                <div class="contact">
                    <div class="contact-form">
                        <h2>
                            Login</h2>
                        <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="<h3>Wrong Username or Password</h3>"
                            Visible="False"></asp:Label>
                        <div>
                            <span>
                                <label>
                                    Name <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server"
                                        ErrorMessage="Nama Tidak Boleh Kosong!" ControlToValidate="usr" ForeColor="Red"></asp:RequiredFieldValidator>
                                </label>
                            </span><span>
                                <input name="Username" type="text" class="textbox" runat="server" id="usr" /></span>
                        </div>
                        <div>
                            <span>
                                <label>
                                    Password
                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server"
                                        ErrorMessage="RequiredFieldValidator" ControlToValidate="pwds" ForeColor="Red">Password Tidak Boleh Kosong!</asp:RequiredFieldValidator>
                                </label>
                            </span><span>
                                <input name="Password" type="password" class="textbox" runat="server" id="pwds" /></span>
                        </div>
                        <div>
                            <span>
                                <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click1" />
                            </span>
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
