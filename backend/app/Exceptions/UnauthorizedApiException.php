<?php

namespace App\Exceptions;

use Symfony\Component\HttpFoundation\Response;

class UnauthorizedApiException extends ApiException
{
  public function __construct(string $message = 'Unauthorized', int $code = Response::HTTP_UNAUTHORIZED)
  {
    $exception = [
      'message' => $message,
    ];

    parent::__construct(response()->json($exception, $code));
  }
}
