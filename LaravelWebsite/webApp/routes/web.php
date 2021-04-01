<?php

use Illuminate\Support\Facades\Route;
use Illuminate\Support\Facades\Auth;

/*
|--------------------------------------------------------------------------
| Web Routes
|--------------------------------------------------------------------------
|
| Here is where you can register web routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| contains the "web" middleware group. Now create something great!
|
*/

Route::get('/', function () {
    return view('landing');
});

Route::get('/welcome', function () {
    return view('welcome');
});

Route::get('/home', function () {
    return view('landing');
});


Auth::routes();

Route::get('/game/create', [App\Http\Controllers\GameController::class, 'create'])->name('game.create');
Route::post('/game', [App\Http\Controllers\GameController::class, 'store']);

Route::get('/profile/{id}', [App\Http\Controllers\ProfilesController::class, 'index'])->name('profile.show');

Route::get('/testFb', [App\Http\Controllers\FirebaseController::class, 'index']);