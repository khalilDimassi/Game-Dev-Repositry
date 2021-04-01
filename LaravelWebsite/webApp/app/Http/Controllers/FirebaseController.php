<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Kreait\Firebase;
use Kreait\Firebase\Database;
use Kreait\Firebase\Factory;
use Kreait\Firebase\ServiceAccount;

class FirebaseController extends Controller
{
    //
    public function index(){
        
    $factory = (new Factory)
        ->withServiceAccount(__DIR__.'/FirebaseKey.json')
        ->withDatabaseUri('https://player-accounts-0001-default-rtdb.europe-west1.firebasedatabase.app/');

    $auth = $factory->createAuth();
    $realtimeDatabase = $factory->createDatabase();
    $cloudMessaging = $factory->createMessaging();
    $remoteConfig = $factory->createRemoteConfig();
    $cloudStorage = $factory->createStorage();

    //$factory = (new Factory)->withServiceAccount(__DIR__.'\FirebaseKey.json');

    $database = $factory->createDatabase();

    $newPost = $database

        ->getReference('users')

        ->push(['id' => '0',
                'name' => 'khalil',
                'username' => 'archy',
                'email' => 'dimassi0khalil@gmail.com',
                'name' => 'khalil',]);

    echo"<pre>";

    print_r($newPost->getvalue());
    
    }
}