<?php

namespace App\Providers;

use Illuminate\Support\Facades\Route;
use Illuminate\Support\ServiceProvider;


class AppServiceProvider extends ServiceProvider
{
  public function boot(): void
  {
    Route::macro('protectedResource', function ($name, $controller) {
      return Route::group([], function () use ($name, $controller) {
        Route::apiResource($name, $controller)->only(['index', 'show']);
        Route::apiResource($name, $controller)->except(['index', 'show'])->middleware('auth:api');
      });
    });
  }
}
