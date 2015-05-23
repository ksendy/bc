<%@ Page Title="" Language="C#" MasterPageFile="~/ProgramFiles.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="UI.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>All Program</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main_bg1">
        <div class="wrap">
            <div class="main1">
                <h2 runat="server" id="jdl" ></h2>
            </div>
        </div>
    </div>
    <!-- start main -->
    <div class="main_bg">
        <div class="wrap">
            <div class="main">
                <!-- start grids_of_3 -->
                <div runat="server" id="pr">
                </div>
                <!-- end grids_of_3 -->
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
