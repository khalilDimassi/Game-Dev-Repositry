<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;
use Illuminate\Support\Facades\DB;

class CreateProfilesTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('profiles', function (Blueprint $table) {
            $table->id();
            $table->unsignedBigInteger('user_id');
           
            $table->String('rank')->default("rabbit");
            $table->integer('playedMatches')->nullable();
            $table->integer('wonMatches')->nullable();
            $table->float('winRate')->nullable();
           
            $table->timestamps();
            $table->index('user_id');

            $table->integer('level')->default(0);
            $table->integer('exp')->default(0);
        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::dropIfExists('profiles');
    }
}
