@extends('layouts.app')

@section('content')
<div class="container">

    <form action="/game" enctype="multipart/form-data" method="post">
        @csrf

        <div class="row">
            <div class="col-8 offset-2">

                <div class="row justify-content-center pb-5">
                    <h1>New Game:</h1>
                </div>

                <div class="form-group row align-items-baseline">
                    <label for="result" class="col-md-4 col-form-label text-md-right">{{ __('Game status: ') }}</label>
                    <div class="col-md-6">                                           
                        <label for="result" class="pl-4 pr-2 form-check-label">
                            <input type="radio" name="result" class="form-check-input" value='won' checked>
                            <strong>won</strong>
                        </label>

                        <label for="result" class="pl-4 pr-2 form-check-label">
                            <input type="radio" name="result" class="form-check-input"  value='lost' >
                            <strong>lost</strong>
                        </label>
                    </div>
                </div>

                <div class="form-group row pb-2">
                    <label for="date, time" class="col-md-4 col-form-label text-md-right align-content">{{ __('Match start time: ') }}</label> 
                    <div class="col-md-6">
                        <input class="form-control date-picker mb-2 @error('date') is-invalid @enderror" type="date" value="null" id="dateInput" name="date">             
                        @error('date')
                                        <span class="invalid-feedback" role="alert">
                                            <strong>{{ $message }}</strong>
                                        </span>
                        @enderror
                    </div>
                   
                </div>

                <div class="form-group row pt-2">
                    <label for="match length" class="col-md-4 col-form-label text-md-right align-content">{{ __('Match length: ') }}</label> 
                    <div class="col-md-6">       
                        <input class="form-control time-picker @error('matchLength') is-invalid @enderror" type="time" id="timeInput" max="00:20:00" step="1" name="matchLength">    
                        @error('matchLength')
                                        <span class="invalid-feedback" role="alert">
                                            <strong>{{ $message }}</strong>
                                        </span>
                        @enderror
                    </div>
                   
                </div>

                
                <div class="row pt-3 justify-content-center">
                        <button class="btn btn-primary btn-lg">Create</button>
                </div>

            </div>
        </div>
    </form>

</div>
@endsection
