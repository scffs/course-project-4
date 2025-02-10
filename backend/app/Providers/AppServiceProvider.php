<?php

namespace App\Providers;

use Illuminate\Support\Facades\Route;
use Illuminate\Support\ServiceProvider;


class AppServiceProvider extends ServiceProvider
{
  public function boot(): void
  {
    // Регистрация своего вида маршрута Laravel
    Route::macro('protectedResource', function ($name, $controller) {
      return Route::group([], function () use ($name, $controller) {
        // Без посредника будут только методы index и show
        Route::apiResource($name, $controller)->only(['index', 'show']);
        // С посредником будут все другие методы, которые есть в контроллере
        Route::apiResource($name, $controller)->except(['index', 'show'])->middleware('auth:api');
      });
    });
  }
}
