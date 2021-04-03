<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Profile extends Model
{
    use HasFactory;


     /**
     * The attributes that are mass assignable.
     *
     * @var array
     */
    protected $fillable = [
        'user_id',
        'rank',
        'playedMatches',
        'wonMatches',
        'winRate',
    ];

    public function user()
    {
        return $this -> belongsTo(User::class);
    }

    public function show($id)
    {
        return view('profile.index')->with('id');
    }
    
}

