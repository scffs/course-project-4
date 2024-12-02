<?php

namespace App\Providers;

use Illuminate\Support\Facades\Route;
use Illuminate\Support\ServiceProvider;


class AppServiceProvider extends ServiceProvider
{
  public function boot(): void
  {
    Route::macro('protectedResource', function ($name, $controller, array $options = []) {
      $only = $options['only'] ?? ['index', 'show'];
      $except = $options['except'] ?? ['index', 'show'];

      Route::apiResource($name, $controller)
        ->only($only);

      Route::apiResource($name, $controller)
        ->except($except)
        ->middleware('auth:api');
    });
  }

}
