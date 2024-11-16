<?php

namespace App\Exceptions;

use Symfony\Component\HttpFoundation\Response;

class NotFoundException extends ApiException
{
  public function __construct(string $message = 'Not Found', int $code = Response::HTTP_NOT_FOUND)
  {
    $exception = [
      'message' => $message,
    ];

    parent::__construct(response()->json($exception, $code));
  }
}
