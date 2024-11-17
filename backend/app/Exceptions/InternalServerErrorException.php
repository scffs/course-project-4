<?php

namespace App\Exceptions;

use Symfony\Component\HttpFoundation\Response;

class InternalServerErrorException extends ApiException
{
  public function __construct(string $message = 'Internal Server Error', int $code = Response::HTTP_INTERNAL_SERVER_ERROR)
  {
    parent::__construct($message, $code);
  }
}
