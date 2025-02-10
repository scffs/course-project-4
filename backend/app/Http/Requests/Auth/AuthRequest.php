<?php

namespace App\Http\Requests\Auth;


use App\Http\Requests\ApiRequest;

class   AuthRequest extends ApiRequest
{
  public function rules(): array
  {
    return [
      'login' => 'required|string',
      'password' => 'required|string',
    ];
  }
}
