<!doctype html>
<html lang="en">
  <head>
    <title>Wake Me Up</title>
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    
    <!-- my CSS -->
    <link rel="stylesheet" href="{{ asset('css/landing.css') }}" type="text/css">
  </head>
  <body>
      

      <div class="container-fluid">
        <section class="container nav-section py-2" style="height: 100vh">

          <div class="row px-5 py-2 align-items-center justify-content-around" style="width: 100%; height: 20%">        
            <div class="col-3 justify-content-center align-items-center d-flex h-100">
              <div href="#" class="d-flex justify-content-center align-items-center">
                <span class="deco">
                  <img class="i1" src="svg\anim\Deco-1.svg" alt="deco">
                </span>
                
                <span class="deco">
                  <img class="i2" src="svg\anim\Deco-1.svg" alt="deco">
                </span>
              </div>
            </div>
            <div class="col-3 justify-content-center align-items-center d-flex h-100"></div>
            <div class="col-3 justify-content-center align-items-center d-flex h-100">
              <a href="{{ route('login') }}" class="d-flex align-items-center justify-content-center">
                <span class="panels">  
                  <img src="svg\anim\signin.svg" alt="signin">
                </span>
              </a>
            </div>
          </div>

          <div class="row px-5 py-2 align-items-center justify-content-around" style="width: 100%; height: 20%">
            <div class="col-2 justify-content-center align-items-center d-flex h-100"></div>
            <div class="col-2 justify-content-center align-items-center d-flex h-100"></div>
            <div class="col-2 justify-content-center align-items-center d-flex h-100">
              <div class="d-flex align-items-center justify-content-center">
                <span id="sign-link">  
                  <img src="svg\anim\signLink.svg" alt="signup">
                </span>
              </div>
            </div>
            <div class="col-2 justify-content-center align-items-center d-flex h-100">
              <a href="{{ route('register') }}" class="d-flex align-items-center justify-content-center">
                <span class="panels">  
                  <img src="svg\anim\signup.svg" alt="signup">
                </span>
              </a>
            </div>
          </div>
          
          <div class="row px-5 py-2 align-items-center justify-content-around" style="width: 100%; height: 20%">
            
            <div class="col-2 h-100"></div>
            <div class="col-2 h-100"></div>
            <div class="col-2 h-100 d-flex align-items-center justify-content-center">
              <a class="a-start d-flex align-items-center justify-content-center" href="#">
                <span id="L6"> <img src="svg\anim\layer-6.svg" alt="lay6"> </span>
                <span id="L5"> <img src="svg\anim\layer-5.svg" alt="lay6"> </span>
                <span id="L4"> <img src="svg\anim\layer-4.svg" alt="lay6"> </span>
                <span id="L3"> <img src="svg\anim\layer-3.svg" alt="lay6"> </span>
                <span id="L2"> <img src="svg\anim\layer-2.svg" alt="lay6"> </span>
                <span id="L1"> <img src="svg\anim\layer-1.svg" alt="lay6"> </span>
                <span id="sb"> <img src="svg\anim\center.svg" alt="cb"> </span>
                <span id="start-btn"> <img src="svg\anim\symbol.svg" alt="sb"> </span>
              </a>
            </div>
            <div class="col-2 h-100"></div>
            <div class="col-2 h-100"></div>
          </div>
          
          <div class="row px-5 py-2 align-items-center justify-content-around" style="width: 100%; height: 20%">
            <div class="col-2 justify-content-center align-items-center d-flex h-100">
              <a href="#" class="d-flex align-items-center justify-content-center">
                <span class="panels">  
                  <img src="svg\anim\abtUs.svg" alt="abtUs">
                </span>
              </a>
            </div>
            <div class="col-2 justify-content-center align-items-center d-flex h-100">
              <div class="d-flex align-items-center justify-content-center">
                <span class="panels" id="dwn-link">  
                  <img src="svg\anim\dwnLink.svg" alt="dwnL">
                </span>
              </div>
            </div>
            <div class="col-2 justify-content-center align-items-center d-flex h-100">
              <a href="#" class="d-flex align-items-center justify-content-center">
                <span class="panels">  
                  <img src="svg\anim\ctnUs.svg" alt="ctnUs">
                </span>
              </a>
            </div>
          </div>

          <div class="row px-5 py-2 align-items-center justify-content-around" style="width: 100%; height: 20%">
            
            <div class="col-3 justify-content-center align-items-center d-flex h-100"></div>
            
            <div class="col-3 justify-content-center align-items-center d-flex h-100">
              <a href="#" class="d-flex align-items-center justify-content-center">
                <span class="panels">  
                  <img src="svg\anim\download.svg" alt="dwn">
                </span>
              </a>
            </div>
            
            <div class="col-3 justify-content-center align-items-center d-flex h-100"></div>

          </div>

        </section>
      </div>


    <!-- Optional JavaScript -->

    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
  </body>
</html>