<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="UI.index" %>

<!DOCTYPE HTML>
<html>
<head>
    <title>Program Files</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href='http://fonts.googleapis.com/css?family=Source+Sans+Pro:400,700' rel='stylesheet'
        type='text/css'>
    <link href="css/style.css" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript" src="js/jquery.min.js"></script>
    <!-- start slider -->
    <link href="css/slider.css" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript" src="js/modernizr.custom.28468.js"></script>
    <script type="text/javascript" src="js/jquery.cslider.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#da-slider').cslider();
        });
    </script>
    <!-- Owl Carousel Assets -->
    <link href="css/owl.carousel.css" rel="stylesheet">
    <!-- Owl Carousel Assets -->
    <!-- Prettify -->
    <script src="js/owl.carousel.js"></script>
    <script>
		    $(document).ready(function() {
		
		      $("#owl-demo").owlCarousel({
		        items : 4,
		        lazyLoad : true,
		        autoPlay : true,
		        navigation : true,
			    navigationText : ["",""],
			    rewindNav : false,
			    scrollPerPage : false,
			    pagination : false,
    			paginationNumbers: false,
		      });
		
		    });
    </script>
    <!-- //Owl Carousel Assets -->
    <!-- start top_js_button -->
    <script type="text/javascript" src="js/move-top.js"></script>
    <script type="text/javascript" src="js/easing.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function ($) {
            $(".scroll").click(function (event) {
                event.preventDefault();
                $('html,body').animate({ scrollTop: $(this.hash).offset().top }, 1200);
            });
        });
    </script>
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/css/bootstrap.min.css">
    <!-- Optional theme -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/css/bootstrap-theme.min.css">
    <!-- Latest compiled and minified JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/js/bootstrap.min.js"></script>
</head>
<body>
    <!-- start header -->
    <div class="header_bg">
        <div class="wrap">
            <div class="header">
                <div class="logo">
                    <a href="index.html">
                        <img src="images/logo.png"/></a>
                </div>
                <div class="h_icon">
                    <ul class="icon1 sub-icon1">
                        <li><a class="active-icon c1" href="#"><i>$300</i></a>
                            <ul class="sub-icon1 list">
                                <li>
                                    <h3>
                                        shopping cart empty</h3>
                                    <a href=""></a></li>
                                <li>
                                    <p>
                                        if items in your wishlit are missing, <a href="contact.html">contact us</a> to view
                                        them</p>
                                </li>
                            </ul>
                        </li>
                    </ul>
                </div>
                <div class="h_search">
                    <form>
                    <input type="text" value="">
                    <input type="submit" value="">
                    </form>
                </div>
                <div class="clear">
                </div>
            </div>
        </div>
    </div>
    <div class="header_btm">
        <div class="wrap">
            <div class="header_sub">
                <div class="h_menu">
                    <ul id="menuAtas" runat="server" style="text-align: center !important;">
                        <%--<li class="active"><a href="index.aspx">Home</a></li> |
				<li><a href="sale.html">sale</a></li> |
				<li><a href="wallets.html">History</a></li> |
				<li><a href="sale.html">Change Password</a></li> |
				<li><a href="index.html">Pesanan</a></li> |
				<li><a href="shoes.html">Logout</a></li> |
				<li><a href="sale.html">Login</a></li> |
				<li><a href="service.html">Register</a></li> |
				<li><a href="contact.html">About Us</a></li>--%>
                    </ul>
                </div>
                <div class="top-nav">
                    <nav class="nav">	        	
	    	    <a href="#" id="w3-menu-trigger"> </a>
	                  <ul runat="server" id="menuMobile" class="nav-list" style="">
	            <li class="active"><a href="index.aspx">Home</a></li>
				<li class="nav-item"><a href="sale.html">sale</a></li>
				<li class="nav-item"><a href="wallets.html">History</a></li>
				<li class="nav-item"><a href="sale.html">Change Password</a></li>
				<li class="nav-item"><a href="index.html">Pesanan</a></li>
				<li class="nav-item"><a href="shoes.html">Logout</a></li>
				<li class="nav-item"><a href="sale.html">Login</a></li>
				<li class="nav-item"><a href="service.html">Register</a></li>
				<li class="nav-item"><a href="contact.html">About Us</a></li>
	                 </ul>
	           </nav>
                    <div class="search_box">
                        <form>
                        <input type="text" value="Search" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'Search';}"><input
                            type="submit" value="">
                        </form>
                    </div>
                    <div class="clear">
                    </div>
                    <script src="js/responsive.menu.js"></script>
                </div>
                <div class="clear">
                </div>
            </div>
        </div>
    </div>



    <!-- content -->
    <div>
    </div>


    <!-- start footer -->
    <div class="footer_bg">
        <div class="wrap">
            <div class="footer">
                <!-- start grids_of_4 -->
                <div class="grids_of_4">
                    <div class="grid1_of_4">
                        <h4>
                            featured sale</h4>
                        <ul class="f_nav">
                            <li><a href="">alexis Hudson</a></li>
                            <li><a href="">american apparel</a></li>
                            <li><a href="">ben sherman</a></li>
                            <li><a href="">big buddha</a></li>
                            <li><a href="">channel</a></li>
                            <li><a href="">christian audigier</a></li>
                            <li><a href="">coach</a></li>
                            <li><a href="">cole haan</a></li>
                        </ul>
                    </div>
                    <div class="grid1_of_4">
                        <h4>
                            mens store</h4>
                        <ul class="f_nav">
                            <li><a href="">alexis Hudson</a></li>
                            <li><a href="">american apparel</a></li>
                            <li><a href="">ben sherman</a></li>
                            <li><a href="">big buddha</a></li>
                            <li><a href="">channel</a></li>
                            <li><a href="">christian audigier</a></li>
                            <li><a href="">coach</a></li>
                            <li><a href="">cole haan</a></li>
                        </ul>
                    </div>
                    <div class="grid1_of_4">
                        <h4>
                            women store</h4>
                        <ul class="f_nav">
                            <li><a href="">alexis Hudson</a></li>
                            <li><a href="">american apparel</a></li>
                            <li><a href="">ben sherman</a></li>
                            <li><a href="">big buddha</a></li>
                            <li><a href="">channel</a></li>
                            <li><a href="">christian audigier</a></li>
                            <li><a href="">coach</a></li>
                            <li><a href="">cole haan</a></li>
                        </ul>
                    </div>
                    <div class="grid1_of_4">
                        <h4>
                            quick links</h4>
                        <ul class="f_nav">
                            <li><a href="">alexis Hudson</a></li>
                            <li><a href="">american apparel</a></li>
                            <li><a href="">ben sherman</a></li>
                            <li><a href="">big buddha</a></li>
                            <li><a href="">channel</a></li>
                            <li><a href="">christian audigier</a></li>
                            <li><a href="">coach</a></li>
                            <li><a href="">cole haan</a></li>
                        </ul>
                    </div>
                    <div class="clear">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- start footer -->
    <div class="footer_bg1">
        <div class="wrap">
            <div class="footer">
                <!-- scroll_top_btn -->
                <script type="text/javascript">
                    $(document).ready(function () {

                        var defaults = {
                            containerID: 'toTop', // fading element id
                            containerHoverID: 'toTopHover', // fading element hover id
                            scrollSpeed: 1200,
                            easingType: 'linear'
                        };


                        $().UItoTop({ easingType: 'easeOutQuart' });

                    });
                </script>
                <a href="#" id="toTop" style="display: block;"><span id="toTopHover" style="opacity: 1;">
                </span></a>
                <!--end scroll_top_btn -->
                <div class="copy">
                    <p class="link">
                        &copy; All rights reserved | Template by&nbsp;&nbsp;<a href="http://w3layouts.com/">
                            W3Layouts</a></p>
                </div>
                <div class="clear">
                </div>
            </div>
        </div>
    </div>
</body>
</html>
