<%@ Page Title="" Language="C#" MasterPageFile="~/ProgramFiles.Master" AutoEventWireup="true"
    CodeBehind="AddProgram.aspx.cs" Inherits="UI.AddProgram" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Add Program</title>
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
                        <h2>
                            Register</h2>
                        <div>
                            <asp:Image ID="Image1" runat="server" Visible="False" CssClass="imgUpload" /><br />
                            <asp:FileUpload ID="FileUploadControl" runat="server" />
                            <br />
                            <br />
                        </div>
                        <div>
                            <span>
                                <label>
                                    Title
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="title"
                                        Display="Dynamic" ErrorMessage="Title Empty" ForeColor="Red"></asp:RequiredFieldValidator>
                                </label>
                                <asp:TextBox ID="title" CssClass="textbox" runat="server"></asp:TextBox>
                            </span>
                        </div>
                        <div>
                            <span>
                                <label>
                                    Description
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="descr"
                                        Display="Dynamic" ErrorMessage="Description Empty" ForeColor="Red"></asp:RequiredFieldValidator>
                                </label>
                                <asp:TextBox ID="descr" CssClass="textbox" runat="server"></asp:TextBox>
                            </span>
                        </div>
                        <div>
                            <span>
                                <label>
                                    Size
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="size"
                                        Display="Dynamic" ErrorMessage="Size Empty" ForeColor="Red"></asp:RequiredFieldValidator>
                                    &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                        ControlToValidate="size" Display="Dynamic" ErrorMessage="Size Must be Number(s)"
                                        ForeColor="Red" ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                                </label>
                                <asp:TextBox ID="size" CssClass="textbox" runat="server"></asp:TextBox>
                            </span>
                        </div>
                        <div>
                            <span>
                                <label>
                                    OS
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="os"
                                        Display="Dynamic" ErrorMessage="OS Empty" ForeColor="Red"></asp:RequiredFieldValidator>
                                </label>
                                <asp:TextBox ID="os" CssClass="textbox" runat="server"></asp:TextBox></span>
                        </div>
                        <div>
                            <span>
                                <label>
                                    License
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="license"
                                        Display="Dynamic" ErrorMessage="License Empty" ForeColor="Red"></asp:RequiredFieldValidator>
                                </label>
                                <asp:TextBox ID="license" CssClass="textbox" runat="server"></asp:TextBox></span>
                        </div>
                        <div>
                            <span>
                                <label>
                                    Technology
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="tech"
                                        Display="Dynamic" ErrorMessage="Technology" ForeColor="Red"></asp:RequiredFieldValidator>
                                </label>
                            </span>&nbsp;<span><asp:TextBox ID="tech" CssClass="textbox" runat="server"></asp:TextBox></span>
                        </div>
                        <div>
                            <span>
                                <asp:Button ID="Button1" runat="server" Text="Add Program" OnClick="Button1_Click" /></span>
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
