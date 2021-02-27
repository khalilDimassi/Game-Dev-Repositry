<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Symfony\Contracts\Service\Attribute\Required;

class MatchController extends Controller
{
    //
    public function create(){
        return view('matchs.create');
    }
    //
    public function store(){
        $data = request()->validate([
            'date' => 'required',
            'time' => 'required',
            'match length' => 'required',

        ]);
        dd(request()->all());
    }
}
