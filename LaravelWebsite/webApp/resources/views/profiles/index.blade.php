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
                <a href="/game/create">new game</a>
            </div>
            <div>rank ladder <strong style="color: blue;">n° {{$user->profile->user_id ?? $user->id}}</strong> of the server</div>
            <div class="pt-5"><button type="button" class="btn btn-primary btn-lg">Update</button></div>
        </div>
    </div>

    <div class="row pt-5 justify-content-center">     
        @foreach ($user->games as $game)
            <div class="col-5 p-3 border m-2" style="color: grey; text-align: center;">
                <h1>Game {{$game -> result}}</h1>
                <h3>Game played on {{$game -> date}} and lasted {{$game -> matchLength}} minutes</h3>
            </div>
        @endforeach
        
    </div>
</div>
@endsection
