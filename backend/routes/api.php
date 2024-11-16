<?php

use App\Http\Controllers\Auth\AuthController;
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
  Route::prefix('admin')->group(function () {
    Route::prefix('heroes')->group(function () {
      Route::controller(HeroController::class)->group(function () {
        Route::get('/', 'index');
        Route::get('/create', 'create');
        Route::post('/', 'store');
        Route::get('/{hero}', 'show');
        Route::get('/{hero}/edit', 'edit');
        Route::put('/{hero}', 'update');
        Route::delete('/{hero}', 'destroy');
      });
    });
  });
});
