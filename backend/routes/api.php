<?php

use App\Http\Controllers\AuthController;
use App\Http\Controllers\HeroController;
use App\Http\Controllers\AbilityController;
use App\Http\Controllers\ItemController;
use Illuminate\Support\Facades\Route;

Route::prefix('auth')->group(function () {
  Route::controller(AuthController::class)->group(function () {
    Route::post('login', 'login');
    Route::post('register', 'register');
    Route::get('logout', 'logout')->middleware('auth:api');
  });
});

Route::apiResource('heroes', HeroController::class)->only(['index', 'show']);
Route::apiResource('abilities', AbilityController::class)->only(['index', 'show']);
Route::apiResource('items', ItemController::class)->only(['index', 'show']);

Route::middleware('auth:api')->group(function () {
  Route::apiResource('heroes', HeroController::class)->except(['index', 'show']);
  Route::apiResource('abilities', HeroController::class)->except(['index', 'show']);
  Route::apiResource('items', ItemController::class)->only(['index', 'show']);
});
