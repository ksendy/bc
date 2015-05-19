<%@ Page Title="" Language="C#" MasterPageFile="~/ProgramFiles.Master" AutoEventWireup="true"
    CodeBehind="AllProgram.aspx.cs" Inherits="UI.AllProgram" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>All Program</title>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main_bg">
        <div class="wrap">
            <div class="main">
                <div id="tec" runat="server">
                </div>
                <h2 class="style top">
                    All Program</h2>
                <div runat="server" id="pro">
                </div>
            </div>
        </div>
        <div class="main_bg1">
            <div class="wrap">
                <div class="main3" runat="server" id="pagination">
                </div>
            </div>
        </div>
        <br />
        <div class="clear">
        </div>
    </div>
</asp:Content>
