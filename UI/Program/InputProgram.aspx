<%@ Page Title="" Language="C#" MasterPageFile="~/ProgramFiles.Master" AutoEventWireup="true"
    CodeBehind="InputProgram.aspx.cs" Inherits="UI.InputProgram" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>Input Program</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main_bg">
        <div class="wrap">
            <div class="main">
                <div class="contact">
                    <div class="contact-form">
                        <h2>
                            Input Program</h2>
                        <div>
                            <span>
                                <label>
                                    Title</label></span> <span>
                                        <input name="title" type="text" class="textbox" runat="server" id="title" /></span>
                        </div>
                        <div>
                            <span>
                                <label>
                                    Size</label></span> <span>
                                        <input name="size" type="text" class="textbox" runat="server" id="ukuran" /></span>
                        </div>
                        <div>
                            <span>
                                <label>
                                    Technology</label></span> <span>
                                        <input name="tech" type="text" class="textbox" runat="server" id="tech" /></span>
                        </div>
                        <div>
                            <span>
                                <label>
                                   Licence</label></span> <span>
                                        <input name="tech" type="text" class="textbox" runat="server" id="licence" /></span>
                        </div>
                        <div>
                            <span>
                                <label>
                                    OS</label></span> <span>
                                        <input name="tech" type="text" class="textbox" runat="server" id="OS" /></span>
                        </div>
                        <div>
                            <span>
                                <label>
                                    Description</label></span> <span>
                                        <textarea name="descr" runat="server" id="descr"> </textarea></span>
                        </div>
                        <div>
                            <span>
                                <label>
                                    Foto</label></span> <span>
                                        <asp:FileUpload ID="FileUpload1" runat="server" /></span>
                        </div>
                        <div>
                            <span>
                                <asp:Button ID="Button1" runat="server" Text="Input" OnClick="Button1_Click" />
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
