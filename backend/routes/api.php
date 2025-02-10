<?php

use App\Http\Controllers\AbilityController;
use App\Http\Controllers\ArticleController;
use App\Http\Controllers\AuthController;
use App\Http\Controllers\CommentController;
use App\Http\Controllers\HeroController;
use App\Http\Controllers\ItemController;
use App\Http\Controllers\ProfileController;
use Illuminate\Support\Facades\Route;

Route::prefix('auth')->group(function () {
  Route::controller(AuthController::class)->group(function () {
    // Вход пользователя
    Route::post('login', 'login');

    // Вход администратора
    Route::post('admin/login', 'adminLogin');

    Route::post('register', 'register');
    Route::get('logout', 'logout')->middleware('auth:api');
  });
});

Route::protectedResource('heroes', HeroController::class);
Route::protectedResource('abilities', AbilityController::class);
Route::protectedResource('articles', ArticleController::class);
Route::protectedResource('comments', CommentController::class);
Route::protectedResource('items', ItemController::class);
Route::protectedResource('profile', ProfileController::class);
