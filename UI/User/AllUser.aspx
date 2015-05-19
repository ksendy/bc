<%@ Page Title="" Language="C#" MasterPageFile="~/ProgramFiles.Master" AutoEventWireup="true" CodeBehind="AllUser.aspx.cs" Inherits="UI.AllUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>All Users</title>
<style type="text/css">
.judulUsr
{
color:#777777;
}
.GbrUsr
{
    width:100%;
    height : 300px;
    overflow : hidden;
}

</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="main_bg">
<div class="wrap">	
	<div class="main">
		<h2 class="style top">All User</h2>
		<!-- start grids_of_3 -->
	<div runat="server" id="pro">

    </div>
		<!-- end grids_of_3 -->
	</div>
</div>
</div>		

</asp:Content>
