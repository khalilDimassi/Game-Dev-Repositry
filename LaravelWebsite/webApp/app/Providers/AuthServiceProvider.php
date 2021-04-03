<?php

namespace App\Providers;


use Illuminate\Support\Carbon;
use Laravel\Passport\Passport;

use Illuminate\Foundation\Support\Providers\AuthServiceProvider as ServiceProvider;
use Illuminate\Support\Facades\Gate;

use App\User;
use App\Http\Controllers\Controller;
use Illuminate\Foundation\Auth\RegistersUsers;
use Illuminate\Http\Request;
use Laravel\Passport\Client;
use function MongoDB\BSON\toJSON;

class AuthServiceProvider extends ServiceProvider
{
    /**
     * The policy mappings for the application.
     *
     * @var array
     */
    protected $policies = [
        // 'App\Models\Model' => 'App\Policies\ModelPolicy',
    ];

    /**
     * Register any authentication / authorization services.
     *
     * @return void
     */

    public function boot()
    {
        $this->registerPolicies();

        Passport::routes();

        Passport::tokensExpireIn(Carbon::now()->addSecond(1));

        Passport::refreshTokensExpireIn(Carbon::now()->addDays(30));
    }
}

class ApiController extends Controller {
/*
|--------------------------------------------------------------------------
| Register Controller
|--------------------------------------------------------------------------
|
| This controller handles the registration of new users as well as their
| validation and creation. By default this controller uses a trait to
| provide this functionality without requiring any additional code.
|
*/

use RegistersUsers;

public function logout(Request $request)
{
    $request->user()->token()->revoke();

    $json = [
        'success' => true,
        'code' => 200,
        'message' => 'You are Logged out.',
    ];
    return response()->json($json, '200');
}




}


