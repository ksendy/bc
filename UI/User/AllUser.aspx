<%@ Page Title="" Language="C#" MasterPageFile="~/ProgramFiles.Master" AutoEventWireup="true" CodeBehind="AllUser.aspx.cs" Inherits="UI.AllUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>All Users</title>
<style type="text/css">
h4.judulUsr
{
color:#777777 !important;
}
.GbrUsr
{
    width:100%;
    height : 300px;
    overflow : hidden;
}

span.b_btm {
  position: absolute;
  width: 100%;
  border-bottom: 6px solid #3CC395;
  left: 0px;
  display: block;
  bottom: 0px;
  }
.grids_of_44{
	text-align:center;
	margin: 4% 0;
}
.grid1_of_44{
	float: left;
	width: 20.333%;
	margin-left: 3.3333%;
	border: 1px solid rgb(223, 223, 223);
	position: relative;
	border-radius : 20px;
	overflow : hidden;
}
@media only screen and (max-width: 480px) {
	.grid1_of_44 {
		margin-left:0;
		float: none;
		width: 99.333%;
	}
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
