<?php

namespace App\Http\Requests\Api;


use App\Exceptions\ApiException;
use Illuminate\Support\Facades\Auth;

class AuthRequest extends ApiRequest
{
  public function authorize(): bool
  {
    if (Auth::attempt(request()->only('login', 'password'))) {
      return true;
    }

    throw new ApiException('Failed auth', 401);
  }

  public function rules(): array
  {
    return [
      'login' => 'required|string',
      'password' => 'required|string',
    ];
  }
}
