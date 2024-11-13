<?php

use App\Http\Controllers\Api\AuthController;
use Illuminate\Support\Facades\Route;

Route::controller(AuthController::class)->group(function () {
  Route::prefix('auth')->group(function () {
    Route::post('login', 'login');
    Route::post('register', 'register');
    Route::get('logout', 'logout')->middleware('auth:api');
  });
});;
