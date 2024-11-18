<?php

namespace App\Http\Requests;


class AuthRequest extends ApiRequest
{
  public function rules(): array
  {
    return [
      'login' => 'required|string',
      'password' => 'required|string',
    ];
  }
}
