<?php

use App\Exceptions\ApiException;
use Illuminate\Foundation\Application;
use Illuminate\Foundation\Configuration\Exceptions;
use Illuminate\Foundation\Configuration\Middleware;
use Illuminate\Http\Request;

return Application::configure(basePath: dirname(__DIR__))
  ->withRouting(
    web: __DIR__ . '/../routes/web.php',
    api: __DIR__ . '/../routes/api.php',
    commands: __DIR__ . '/../routes/console.php',
    health: '/up',
  )
  ->withMiddleware(function (Middleware $middleware) {
    $middleware->redirectGuestsTo(fn() => throw new ApiException('Unauthorized', 401));

  })
  ->withExceptions(function (Exceptions $exceptions) {
    $exceptions->shouldRenderJsonWhen(
      fn(Request $request) => $request->is('api/*') && !config('app.debug')
    );
  })->create();
