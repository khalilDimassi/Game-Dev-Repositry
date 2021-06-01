<!doctype html>
<html lang="{{ str_replace('_', '-', app()->getLocale()) }}">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <!-- CSRF Token -->
    <meta name="csrf-token" content="{{ csrf_token() }}">

    <title>Game Name Here</title>

    <!-- Scripts -->
    <script src="{{ asset('js/app.js') }}" defer></script>

    <!-- Fonts -->
    <link rel="dns-prefetch" href="//fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css?family=Nunito" rel="stylesheet">

    <!-- Styles -->
    <link href="{{ asset('css/app.css') }}" rel="stylesheet">
    <!-- style css -->
    <link rel="stylesheet" href="{{ asset('css/custom/style.css') }}">
</head>
<body class="appBody">
    <div id="app">
        <nav class="navbar navbar-expand-md navbar-light shadow-sm mr-2 ml-3">

                <a class="navbar-brand d-flex" href="{{ url('/welcome') }}">
                    <div><img src="/svg/tempLogo.svg" class="pr-3" style="height: 20px; border-right: 1px solid #000"></div>
                    <div class="pl-3" style="color: black; font-size: 20px;">Era's End</div>
                </a>
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="{{ __('Toggle navigation') }}">
                    <span class="navbar-toggler-icon"></span>
                </button>

                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <!-- Left Side Of Navbar -->
                    <ul class="navbar-nav mr-auto pl-5 ml-2">
                            <li class="nav-item p-2">
                                <a class="nav-link" style="color: white;" href="#">Home</a>
                            </li>
                            <li class="nav-item p-2">
                                <a class="nav-link" style="color: white;" href="#">Contact-us</a>
                            </li>
                    </ul>

                    <!-- Right Side Of Navbar -->
                    
                    <ul class="navbar-nav ml-auto">
                        <!-- Authentication Links -->
                        @guest
                            @if (Route::has('login'))
                                <li class="nav-item">
                                    <a class="nav-link" style="color: white;" href="{{ route('login') }}">{{ __('Login') }}</a>
                                </li>
                            @endif
                            
                            @if (Route::has('register'))
                                <li class="nav-item">
                                    <a class="nav-link" style="color: white;" href="{{ route('register') }}">{{ __('Sign up') }}</a>
                                </li>
                            @endif
                        @else
                            <li class="nav-item pr-5 mr-5">
                                <a href="#">
                                    <button class="btn btn-danger">Download for free!</button>
                                </a>
                            </li>
                                
                            <li class="nav-item dropdown">
                                <a id="navbarDropdown" class="nav-link dropdown-toggle" href="#" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" v-pre>
                                    {{ Auth::user()->name }}
                                </a>

                                <div class="dropdown-menu dropdown-menu-right" aria-labelledby="navbarDropdown">
                                    <a class="dropdown-item" href="{{ route('logout') }}"
                                       onclick="event.preventDefault();
                                                     document.getElementById('logout-form').submit();">
                                        {{ __('Logout') }}
                                    </a>

                                    <form id="logout-form" action="{{ route('logout') }}" method="POST" class="d-none">
                                        @csrf
                                    </form>
                                </div>
                            </li>
                        @endguest
                    </ul>
                </div>

        </nav>

        <main class="py-4" style="margin-top: 200px">
            <div class="container">
                <div class="row">
                    <div class="col-3 p-5">
                        <img src="/svg/ranks/{{$user->profile->rank}}.png" alt="rank" style="max-height: 200px;">
                    </div>
                    <div class="col-9 pt-5">
                        <div class="d-flex justify-content-between align-items-baseline">
                            <h1>{{$user -> username}}</h1>
                            <a href="/game/create">new game</a>
                        </div>
                        <div style="color: grey">rank <strong style="color: blue;">n° {{$user->profile->user_id ?? $user->id}}</strong> of the server</div>
                        <div class="pt-5"><button type="button" class="btn btn-primary btn-lg" onClick="window.location.reload();">Update</button></div>
                    </div>
                </div>
            
                <div class="row pt-5 justify-content-center">     
                    @foreach ($user->games as $game)
                        @if($game -> result == 1) 
                            <div class="col-5 p-3 border m-2" style="color: lightgrey; text-align: center; background-color: rgb(12, 158, 12);">
                            <h1>Game won</h1>
                        @else 
                            <div class="col-5 p-3 border m-2" style="color: lightgrey; text-align: center; background-color: rgb(218, 12, 12);">
                            <h1>Game lost</h1>
                        @endif
                            <h3>Game played on {{$game -> date}} <br> for {{$game -> matchLength}}</h3>
                        </div>
                    @endforeach
                    
                </div>
            </div>
        </main>

         <!--  footer -->
    <footer style="
            position: absolute;
            bottom: 0;
            width: 100%;
            height: 50px;">
        <div class="footer">
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
                                    <a href="index.html"> <img src="{{ asset('svg/issat_logo.png') }}" alt="logo" style="width: 75%; padding-bottom: 30px;"></a>
                                </div>
                            </div>
                            <div class="col-lg-9 col-md-6 col-sm-6 ">
                                <div class="address">
                                    <h3 class="ctsUs">Contact us </h3>
                                    <ul class="loca">
                                        <li class="ml-5">
                                            <a href="#"><img src="{{ asset('svg/icon/loc.png') }}" alt="#" /></a> Sousse <br> Tunisia </li>
                                        <li class="ml-5"> 
                                            <a href="#"><img src="{{ asset('svg/icon/email.png') }}" alt="#" /></a>Eras.End@gmail.com </li>
                                        <li class="ml-5">
                                            <a href="#"><img src="{{ asset('svg/icon/call.png') }}" alt="#" /></a>+216 25 775 569</li>
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

    </div>
</body>
</html>
