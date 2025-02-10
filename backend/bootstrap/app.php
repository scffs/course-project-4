<?php

use App\Exceptions\NotFoundException;
use App\Exceptions\UnauthorizedApiException;
use Illuminate\Foundation\Application;
use Illuminate\Foundation\Configuration\Exceptions;
use Illuminate\Foundation\Configuration\Middleware;
use Illuminate\Http\Request;
use Symfony\Component\HttpKernel\Exception\NotFoundHttpException;
use Symfony\Component\HttpKernel\Exception\UnauthorizedHttpException;

//use Symfony\Component\HttpKernel\Exception\UnauthorizedHttpException;

return Application::configure(basePath: dirname(__DIR__))
  ->withRouting(
    web: __DIR__ . '/../routes/web.php',
    api: __DIR__ . '/../routes/api.php',
    commands: __DIR__ . '/../routes/console.php',
    health: '/up',
    apiPrefix: 'encyclopedia',
  )
  ->withMiddleware(function (Middleware $middleware) {
    // Перехватывает переход на страницу входа для не авторизированных пользователей для показа ошибки
    $middleware->redirectGuestsTo(fn() => throw new UnauthorizedApiException());
  })
  ->withExceptions(function (Exceptions $exceptions) {
    // Перехватывает 404 ошибку от Laravel для вызова нашей собственной ошибки
    $exceptions->render(function (NotFoundHttpException $e, Request $request) {
      throw new NotFoundException();
    });

    // Перехватывает 401 ошибку от Laravel для вызова нашей собственной ошибки
    $exceptions->render(function (UnauthorizedHttpException $e, Request $request) {
      throw new UnauthorizedApiException();
    });

    // Настройка для показа ошибок в формате JSON для API
    $exceptions->shouldRenderJsonWhen(
      fn(Request $request) => $request->is('api/*') && !config('app.debug')
    );
  })->create();
