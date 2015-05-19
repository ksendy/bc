<%@ Page Title="" Language="C#" MasterPageFile="~/ProgramFiles.Master" AutoEventWireup="true"
    CodeBehind="History.aspx.cs" Inherits="UI.History" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>Order History</title>
<style type="text/css">
td
{
    border:1px solid #dedede;
    text-align :center;
}
table
{
    width:100%; 
    font-family:Source Sans Pro, sans-serif;
}
.judul
{
    font-weight :bold;
    color:White;
    background-color:#4CCFC1;
}
</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main_bg">
        <div class="wrap">
            <div class="main">
                <div class="contact">
                    <div class="contact-form">
                        <div runat="server" id="tbJual">
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                </div>
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
</asp:Content>
