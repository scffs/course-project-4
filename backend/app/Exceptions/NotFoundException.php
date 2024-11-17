<?php

namespace App\Exceptions;

use Symfony\Component\HttpFoundation\Response;

class NotFoundException extends ApiException
{
  public function __construct(string $message = 'Not Found', int $code = Response::HTTP_NOT_FOUND)
  {
    parent::__construct($message, $code);
  }
}
