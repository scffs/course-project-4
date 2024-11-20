<?php

namespace App\Providers;

use Illuminate\Support\Facades\Route;
use Illuminate\Support\ServiceProvider;

class AppServiceProvider extends ServiceProvider
{
  public function register(): void
  {
    //
  }

  public function boot(): void
  {
    Route::macro('publicResource', function ($name, $controller) {
      return Route::apiResource($name, $controller)->only(['index', 'show']);
    });

    Route::macro('protectedResource', function ($name, $controller) {
      return Route::apiResource($name, $controller)->except(['index', 'show']);
    });
  }
}
