<%@ Page Title="" Language="C#" MasterPageFile="~/ProgramFiles.Master" AutoEventWireup="true"
    CodeBehind="AddTopLink.aspx.cs" Inherits="UI.AddTopLink" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main_bg">
        <div class="wrap">
            <div class="main">
                <div class="contact">
                    <div class="contact-form">
                        <h2>
                           Add Top Link</h2>
                        <div>
                            <span>
                                <label>
                                    Name</label></span> <span>
                                        <asp:TextBox ID="TextBox1" CssClass="textbox" runat="server"></asp:TextBox>
                                    </span>
                        </div>
                        <div>
                            <span>
                                <label>
                                    Links</label></span> <span>
                                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                    </span>
                        </div>
                        <div>
                            <span>
                                <label>
                                    Status</label></span> <span>
                                        <select runat="server" id="stats" class="statusAktif">
                                        <option value="0">Non Active</option>
                                        <option value="1">Active</option>
                                        </select>
                                    </span>
                        </div>
                        <div>
                            <span>
                                <label>
                                    Level</label></span> <span>
                                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                    </span>
                            <div>
                                <span>
                                    <asp:Button ID="Button1" runat="server" Text="Submit" 
                                    onclick="Button1_Click" />
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
