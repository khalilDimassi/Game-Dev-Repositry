@extends('layouts.app')

@section('content')
<div class="container">
    <div class="row">
        <div class="col-3 p-5">
            <img src={{$user->profile->rank ?? "/svg/emptyLogo.svg"}} alt="rank" style="max-height: 200px;">
        </div>
        <div class="col-9 pt-5">
            <div class="d-flex justify-content-between align-items-baseline">
                <h1>{{$user -> username}}</h1>
                <a href="#">edit profile</a>
                <a href="#">new match</a>
            </div>
            <div>rank ladder <strong style="color: blue;">n° {{$user->profile->user_id ?? $user->id}}</strong> of the server</div>
            <div class="pt-5"><button type="button" class="btn btn-primary btn-lg">Update</button></div>
        </div>
    </div>

    <div class="row pt-5 justify-content-center">     
        <div class="col-5 border m-2" style="color: grey; text-align: center;">
            <h1>⚠</h1>
            <h3>no match found!</h3>
        </div>
    </div>
</div>
@endsection
