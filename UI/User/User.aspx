<%@ Page Title="" Language="C#" MasterPageFile="~/ProgramFiles.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="UI.User" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>User Detail</title>
    <style type="text/css">
        .imgUpload
        {
            max-width: 200px;
        }
        .pwds
        {
            font-family: 'Source Sans Pro' , sans-serif;
            background: #FFFFFF;
            border: 1px solid #E7E7E7;
            color: rgba(85, 81, 81, 0.84);
            padding: 8px;
            display: block;
            width: 96.3333%;
            outline: none;
            -webkit-appearance: none;
            text-transform: capitalize;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main_bg">
        <div class="wrap">
            <div class="main">
                <div class="contact">
                    <div class="contact-form">
                        <h2>User Detail</h2>
                        <div>
                            <asp:Image ID="Image1" runat="server" Visible="False" CssClass="imgUpload" /><br />
                            <asp:FileUpload ID="FileUploadControl" runat="server" />
                            <br />
                            <br />                          
                        </div>
                        <div>
                            <span>
                                <label>
                                    Nama</label></span> <span>
                                        <asp:TextBox ID="Names" CssClass="textbox" runat="server"></asp:TextBox></span>
                        </div>
                        <div>
                            <span>
                                <label>
                                    User Name</label></span> <span>
                                        <asp:TextBox ID="usrnm" CssClass="textbox" runat="server" 
                                ReadOnly="True"></asp:TextBox></span>
                        </div>

                        <div>
                            <span>
                                <label>
                                    Level</label></span> <span>
                                        <asp:TextBox ID="level" CssClass="textbox" runat="server" 
                                ReadOnly="True"></asp:TextBox></span>
                        </div>

                        <div>
                            <span>
                                <label>
                                    Email</label></span> <span>
                                        <asp:TextBox ID="mail" CssClass="textbox" runat="server"></asp:TextBox></span>
                        </div>
                        <div>
                            <span>
                                <label>
                                    Telp</label></span> <span>
                                        <asp:TextBox ID="tel" CssClass="textbox" runat="server"></asp:TextBox></span>
                        </div>
                        <div>
                            <span>
                                <label>
                                    Alamat</label></span> <span>
                                        <textarea name="Address" runat="server" id="alamat"> </textarea></span>
                        </div>
                        <div>
                            <span>
                                <label>
                                    Kota</label></span> <span>
                                        <asp:TextBox ID="city" CssClass="textbox" runat="server"></asp:TextBox></span>
                        </div>
                        <div>
                            <span>
                                <label>
                                    Provinsi</label></span> <span>
                                        <asp:TextBox ID="prov" CssClass="textbox" runat="server"></asp:TextBox></span>
                        </div>
                        <div>
                            <span>
                                <label>
                                    Kode Pos</label></span> <span>
                                        <asp:TextBox ID="kdpos" CssClass="textbox" runat="server"></asp:TextBox></span>
                        </div>
                       
                        <div>
                            <span>
                                <asp:Button ID="Button1" runat="server" Text="Update" OnClick="Button1_Click" /></span>
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
