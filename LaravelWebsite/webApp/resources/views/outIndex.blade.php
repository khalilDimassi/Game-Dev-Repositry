<!DOCTYPE html>
<html lang="en">

<head>
    <!-- basic -->
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <!-- mobile metas -->
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="viewport" content="initial-scale=1, maximum-scale=1">
    <!-- site metas -->
    <title>Era's End</title>
    <meta name="keywords" content="">
    <meta name="description" content="">
    <meta name="author" content="">
    <!-- bootstrap css -->
    <link rel="stylesheet" href="{{ asset('css/custom/bootstrap.min.css') }}">
    <!-- style css -->
    <link rel="stylesheet" href="{{ asset('css/custom/style.css') }}">
    <!-- Responsive-->
    <link rel="stylesheet" href="{{ asset('css/custom/responsive.css') }}">
    <!-- fevicon -->
    <link rel="icon" href="images/fevicon.png" type="image/gif" />
    <!-- Scrollbar Custom CSS -->
    <link rel="stylesheet" href="{{ asset('css/custom/jquery.mCustomScrollbar.min.css') }}">
    <!-- Tweaks for older IEs-->
    <link rel="stylesheet" href="https://netdna.bootstrapcdn.com/font-awesome/4.0.3/css/font-awesome.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/fancybox/2.1.5/jquery.fancybox.min.css" media="screen">
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script><![endif]-->
</head>
<!-- body -->

<body class="main-layout">
    <!-- header -->
    <header>
        <!-- header inner -->
        <div class="header-top">
            <div class="header">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-xl-3 col-lg-3 col-md-3 col-sm-3 col logo_section">
                            <div class="full">
                                <div class="center-desk">
                                    <div class="logo">
                                        <a href="index.html">  </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-xl-9 col-lg-9 col-md-9 col-sm-9">
                            @if (Route::has('login'))
                                <ul class="top_icon">
                                    @auth
                                        <li class="button_login"> <a href="{{route('profile.show', [Auth::user()->id])}}">Profile</a> </li>
                                    @else
                                        <li class="button_login"> <a href="{{ route('login') }}">Log in</a></li>
                                        @if (Route::has('register'))
                                            <li class="button_login"> <a href="{{ route('register') }}">Register</a></li>
                                        @endif
                                    @endauth
                                    <li class="mean-last"><a href="#"><img src="{{ asset('svg/images/search_icon.png') }}" alt="#" /></a></li>
                                </ul>
                            @endif
                        </div>
                    </div>
                </div>
            </div>
            <!-- end header inner -->

            <!-- end header -->
            <section class="slider_section" style="background-image: url({{ asset('svg/images/banner2.png') }});">
                <div class="banner_main">

                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-md-2 padding_left0">
                                <div class="menu-area">
                                <div class="limit-box">
                                    <nav class="main-menu">
                                        <ul class="menu-area-main">
                                            <li class="active"> <a href="#game">Game</a> </li>
                                            <li> <a href="#software">Software</a> </li>
                                            <li> <a href="#about">About</a> </li>
                                            <li> <a href="#testimonial">Testimonial</a> </li>
                                            <li> <a href="#contact">Contact</a> </li>
                                           
                                        </ul>
                                    </nav>
                                </div>
                            </div>
                            </div>
                            <div class="col-xl-4 col-lg-4 col-md-4 col-sm-12 ">
                                <div class="text-bg">
                                    <img src="{{ asset('svg/logo.png') }}" alt="logo" style="width: 100%">
                                    <span>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod<br> tempor incididunt ut</span>
                                    <a href="#">download</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <br>
                <br>
                <br>
                <br>
                <br>
                <br>
                <br>
                <br>
                <br>
                <br>
           </section>
        </div>
    </header>

    <!-- our -->
    <div id="games" class="our">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="titlepage">
                        <h2>Our Games</h2>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12 margin_bottom">
                    <div class="row">

                        <div class="col-xl-4 col-lg-4 col-md-4 col-sm-12">
                            <div class="two-box">
                                <figure><img src="{{ asset('svg/images/our-image1.jpg') }}" alt="#" /></figure>
                            </div>
                        </div>

                        <div class="col-xl-8 col-lg-8 col-md-8 col-sm-12">

                            <div class="Games">
                                <h3>Angry Birds</h3>
                                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et </p>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-12 margin_bottom">
                    <div class="row">

                        <div class="col-xl-4 col-lg-4 col-md-4 col-sm-12">
                            <div class="two-box">
                                <figure><img src="{{ asset('svg/images/our-image2.jpg') }}" alt="#" /></figure>
                            </div>
                        </div>

                        <div class="col-xl-8 col-lg-8 col-md-8 col-sm-12">

                            <div class="Games">
                                <h3>Sanke</h3>
                                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et </p>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="row">

                        <div class="col-xl-4 col-lg-4 col-md-4 col-sm-12">
                            <div class="two-box">
                                <figure><img src="{{ asset('svg/images/our-image3.jpg') }}" alt="#" /></figure>
                            </div>
                        </div>

                        <div class="col-xl-8 col-lg-8 col-md-8 col-sm-12">

                            <div class="Games">
                                <h3>Cricket</h3>
                                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et </p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
   
    <!-- end our -->
    <!-- We are -->
    <div id="software" class="We_are">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="titlepage">
                        <h2>Software</h2>
                    </div>
                </div>
            </div>
        </div>
        <div class="container-fluid">
            <div class="row">
                 <div class="col-xl-6 col-lg-6 col-md-6 col-sm-12">
                     <div class="box_bg">
                         <div class="box_bg_img">
                             <figure><img src="{{ asset('svg/images/soft.jpg') }}"></figure>
                         </div>
                     </div>
                 </div>
                 <div class="col-xl-6 col-lg-6 col-md-6 col-sm-12 border_right">
                     <div class="box_text">
                         <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborumLorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat</p>
                         <a href="#">Read more</a>
                     </div>
                 </div> 
            </div>
        </div>
    </div>
    <!-- end We are -->

    <!-- about  -->
    <div id="about" class="about">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="titlepage">
                        <h2>About Our Game</h2>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="about-box">
                        <figure><img src="{{ asset('svg/images/about.jpg') }}" alt="#" /></figure>

                        <p> consectetur adipiscing elit, sed do eiusmod tempor incididunt ut
                            <br> labore et dolore magna aliqua. Ut enim conseq</p>
                    </div>
                </div>
            </div>

        </div>
    </div>
    <!-- end abouts -->

    <!-- contact -->
    <div id="contact" class="contact">
        <div class="container">

            <div class="row">

                <div class="col-md-12">

                    <form class="contact_bg">
                        <div class="row">
                            <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12">
                                <input class="contactus" placeholder="Name" type="text" name="Name">
                            </div>
                            <div class="col-xl-6 col-lg-6 col-md-6 col-sm-12">
                                <input class="contactus" placeholder="Phone" type="text" name="Email">
                            </div>
                            <div class="col-xl-6 col-lg-6 col-md-6 col-sm-12">
                                <input class="contactus" placeholder="Email" type="text" name="Email">
                            </div>
                            <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12">
                                <textarea class="textarea" placeholder="Message" type="text" name="Message"></textarea>
                            </div>
                            <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12">
                                <button class="send">Send</button>
                            </div>
                        </div>
                    </form>
                </div>
            </div>

        </div>
    </div>
   
    <!-- end contact -->

    <!--  footer -->
    <footer>
        <div class="footer ">
            <div class="container">
                <div class="row">
                    <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 ">
                        <div class="row">
                            <div class="col-xl-3 col-lg-3 col-md-6 col-sm-6 ">
                                <div class="address">
                                    <ul class="social_link">
                                        <li><a href="#"><img src="{{ asset('svg/icon/fb.png') }}"></a></li>
                                        <li><a href="#"><img src="{{ asset('svg/icon/tw.png') }}"></a></li>
                                        <li><a href="#"><img src="{{ asset('svg/icon/lin(2).png') }}"></a></li>
                                        <li><a href="#"><img src="{{ asset('svg/icon/instagram.png') }}"></a></li>
                                    </ul>
                                    <a href="index.html"> <img src="{{ asset('svg/images/logo.png') }}" alt="logo"></a>
                                </div>
                            </div>
                            <div class="col-lg-9 col-md-6 col-sm-6 ">
                                <div class="address">
                                    <h3 class="ctsUs">Contact us </h3>
                                    <ul class="loca">
                                        <li class="ml-5">
                                            <a href="#"><img src="{{ asset('svg/icon/loc.png') }}" alt="#" /></a>London 145
                                            <br>United Kingdom </li>
                                        <li class="ml-5">
                                            <a href="#"><img src="{{ asset('svg/icon/email.png') }}" alt="#" /></a>demo@gmail.com </li>
                                        <li class="ml-5">
                                            <a href="#"><img src="{{ asset('svg/icon/call.png') }}" alt="#" /></a>+12586954775 </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>

            </div>
        </div>
    </footer>
    <!-- end footer -->

    <!-- Javascript files-->
    <script src="{{ asset('js/custom/jquery.min.js') }}"></script>
    <script src="{{ asset('js/custom/popper.min.js') }}"></script>
    <script src="{{ asset('js/custom/bootstrap.bundle.min.js') }}"></script>
    <script src="{{ asset('js/custom/jquery-3.0.0.min.js') }}"></script>
    <script src="{{ asset('js/custom/plugin.js') }}"></script>
    <!-- sidebar -->
    <script src="{{ asset('js/custom/jquery.mCustomScrollbar.concat.min.js') }}"></script>
    <script src="{{ asset('js/custom/custom.js') }}"></script>
    <script src="https:cdnjs.cloudflare.com/ajax/libs/fancybox/2.1.5/jquery.fancybox.min.js"></script>

</body>

</html>