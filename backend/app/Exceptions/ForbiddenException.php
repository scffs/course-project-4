<?php

namespace App\Exceptions;

use Symfony\Component\HttpFoundation\Response;

class ForbiddenException extends ApiException
{
  public function __construct(string $message = 'Forbidden for you', int $code = Response::HTTP_FORBIDDEN)
  {
    $exception = [
      'message' => $message,
    ];

    parent::__construct(response()->json($exception, $code));
  }
}
