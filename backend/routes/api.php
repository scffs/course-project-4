<?php

use App\Http\Controllers\AbilityController;
use App\Http\Controllers\ArticleController;
use App\Http\Controllers\AuthController;
use App\Http\Controllers\CommentController;
use App\Http\Controllers\HeroController;
use Illuminate\Support\Facades\Route;

Route::prefix('auth')->group(function () {
  Route::controller(AuthController::class)->group(function () {
    Route::post('login', 'login');
    Route::post('register', 'register');
    Route::get('logout', 'logout')->middleware('auth:api');
  });
});

Route::publicResource('heroes', HeroController::class)->only(['index', 'show']);
Route::publicResource('abilities', AbilityController::class)->only(['index', 'show']);
Route::publicResource('articles', ArticleController::class)->only(['index', 'show']);

Route::middleware('auth:api')->group(function () {
  Route::protectedResource('heroes', HeroController::class)->except(['index', 'show']);
  Route::protectedResource('abilities', HeroController::class)->except(['index', 'show']);
  Route::protectedResource('articles', ArticleController::class)->except(['index', 'show']);
  Route::protectedResource('comments', CommentController::class)->except(['index', 'show']);
});
