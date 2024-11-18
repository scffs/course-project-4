<?php

use App\Http\Controllers\AuthController;
use App\Http\Controllers\HeroController;
use Illuminate\Support\Facades\Route;

Route::prefix('auth')->group(function () {
  Route::controller(AuthController::class)->group(function () {
    Route::post('login', 'login');
    Route::post('register', 'register');
    Route::get('logout', 'logout')->middleware('auth:api');
  });
});

Route::middleware('auth:api')->group(function () {
  Route::apiResource('heroes', HeroController::class);
});
