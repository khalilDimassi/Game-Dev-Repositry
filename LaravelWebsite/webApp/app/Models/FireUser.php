<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;
use Mpociot\Firebase\SyncsWithFirebase;


class FireUser extends Model
{
    use HasFactory;
    use SyncsWithFirebase;

    protected $fillable = ['name', 'username', 'email', 'email_verified_at', 'password'];

    protected $visible = ['id', 'name', 'username', 'email', 'email_verified_at', 'password'];
}
