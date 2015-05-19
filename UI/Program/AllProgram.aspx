<%@ Page Title="" Language="C#" MasterPageFile="~/ProgramFiles.Master" AutoEventWireup="true"
    CodeBehind="AllProgram.aspx.cs" Inherits="UI.AllProgram" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>All Program</title>
<style type="text/css">
.del
{
  position: absolute;
  z-index : 100;
  width : 7%;
  height : 7%;
  margin-left : 90%;
  margin-right : 3%;
  margin-top : 3%;
}
</style>

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
