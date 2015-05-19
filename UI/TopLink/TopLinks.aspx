<%@ Page Title="" Language="C#" MasterPageFile="~/ProgramFiles.Master" AutoEventWireup="true"
    CodeBehind="TopLinks.aspx.cs" Inherits="UI.TopLinks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>Top Links</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main_bg">
        <div class="wrap">
            <div class="main">
                <div class="contact">
                    <div class="contact-form">
                        <h2>
                            Top Link
                        </h2>
                        <div>
                            <span>
                                <asp:Button ID="Button1" runat="server" Text="Input New" CssClass="buttonLogin" OnClick="Button1_Click" />
                            </span>
                        </div>
                        <span id="isi" runat="server"></span>
                    </div>
                    <div class="clear">
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
