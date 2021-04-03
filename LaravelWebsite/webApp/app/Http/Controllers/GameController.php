<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\App;
use Symfony\Contracts\Service\Attribute\Required;

class GameController extends Controller
{   

    public function __construct()
    {
        $this->middleware('auth');
    }

    //
    public function create(){
        return view('games.create');
    }
    
    //
    public function store(){
        $data = request()->validate([
            'result' => '',
            'date' => 'required',
            'matchLength' => ['required',],
        ]);

        auth()->user()->games()->create($data);

        return redirect('/profile/' . auth()->user()->id);
    }
}
