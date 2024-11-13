<?php

namespace App\Exceptions;

use Illuminate\Contracts\Support\MessageBag;
use Illuminate\Http\Exceptions\HttpResponseException;

class ApiException extends HttpResponseException
{
  public function __construct(string $message, int $code = 500, array|MessageBag $errors = [])
  {
    $exception = [
      'message' => $message,
      'code' => $code,
    ];

    if (!empty($errors)) {
      $exception['errors'] = $errors;
    }

    parent::__construct(response()->json($exception, $code));
  }
}
