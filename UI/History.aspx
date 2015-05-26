<%@ Page Title="" Language="C#" MasterPageFile="~/ProgramFiles.Master" AutoEventWireup="true"
    CodeBehind="History.aspx.cs" Inherits="UI.History" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Order History</title>
    <style type="text/css">
        td
        {
            border: 1px solid #dedede;
            text-align: center;
        }
        table
        {
            width: 100%;
            font-family: Source Sans Pro, sans-serif;
        }
        .judul
        {
            font-weight: bold;
            color: White;
            background-color: #4CCFC1;
        }
        select
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
            text-transform: capitalize;</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main_bg">
        <div class="wrap">
            <div class="main">
                <div class="contact">
                <h2>
                        History</h2>
                        <br />
                    <div class="contact-form" style="float: left; width: 50%;">
                        <h3>
                            Month</h3>
                        <div>
                            <asp:DropDownList ID="DropDownList1" runat="server" 
                                onselectedindexchanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="contact-form" style="float: left; width: 50%;">
                        <h3>
                            Register</h3>
                        <div>
                            <asp:DropDownList ID="DropDownList2" runat="server" 
                                onselectedindexchanged="DropDownList2_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                    
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
