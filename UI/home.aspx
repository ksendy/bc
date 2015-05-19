<%@ Page Title="" Language="C#" MasterPageFile="~/ProgramFiles.Master" AutoEventWireup="true"
    CodeBehind="home.aspx.cs" Inherits="UI.home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!----start-cursual---->
    <div class="wrap">
        <!----start-img-cursual---->
        <%--<div id="owl-demo" class="owl-carousel">
            <div class="item" onclick="location.href='details.html';">
                <div class="cau_left">
                    <img class="lazyOwl" data-src="images/c1.jpg" alt="Lazy Owl Image" />
                </div>
                <div class="cau_left">
                    <h4>
                        <a href="details.html">branded shoessss</a></h4>
                    <a href="details.html" class="btn">shop</a>
                </div>
            </div>
            <div class="item" onclick="location.href='details.html';">
                <div class="cau_left">
                    <img class="lazyOwl" data-src="images/c2.jpg" alt="Lazy Owl Image" />
                </div>
                <div class="cau_left">
                    <h4>
                        <a href="details.html">branded tees</a></h4>
                    <a href="details.html" class="btn">shop</a>
                </div>
            </div>
            <div class="item" onclick="location.href='details.html';">
                <div class="cau_left">
                    <img class="lazyOwl" data-src="images/c3.jpg" alt="Lazy Owl Image" />
                </div>
                <div class="cau_left">
                    <h4>
                        <a href="details.html">branded jeens</a></h4>
                    <a href="details.html" class="btn">shop</a>
                </div>
            </div>
            <div class="item" onclick="location.href='details.html';">
                <div class="cau_left">
                    <img class="lazyOwl" data-src="images/c2.jpg" alt="Lazy Owl Image">
                </div>
                <div class="cau_left">
                    <h4>
                        <a href="details.html">branded tees</a></h4>
                    <a href="details.html" class="btn">shop</a>
                </div>
            </div>
            <div class="item" onclick="location.href='details.html';">
                <div class="cau_left">
                    <img class="lazyOwl" data-src="images/c1.jpg" alt="Lazy Owl Image">
                </div>
                <div class="cau_left">
                    <h4>
                        <a href="details.html">branded shoes</a></h4>
                    <a href="details.html" class="btn">shop</a>
                </div>
            </div>
            <div class="item" onclick="location.href='details.html';">
                <div class="cau_left">
                    <img class="lazyOwl" data-src="images/c2.jpg" alt="Lazy Owl Image">
                </div>
                <div class="cau_left">
                    <h4>
                        <a href="details.html">branded tees</a></h4>
                    <a href="details.html" class="btn">shop</a>
                </div>
            </div>
            <div class="item" onclick="location.href='details.html';">
                <div class="cau_left">
                    <img class="lazyOwl" data-src="images/c3.jpg" alt="Lazy Owl Image">
                </div>
                <div class="cau_left">
                    <h4>
                        <a href="details.html">branded jeens</a></h4>
                    <a href="details.html" class="btn">shop</a>
                </div>
            </div>
        </div>--%>
        <!----//End-img-cursual---->
    </div>
    <!-- start main1 -->
    <div class="main_bg1">
        <div class="wrap">
            <div class="main1">
                <h2>
                    featured products</h2>
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
