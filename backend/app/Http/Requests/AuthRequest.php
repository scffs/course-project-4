<?php

namespace App\Http\Requests;


use App\Exceptions\UnauthorizedException;
use Illuminate\Support\Facades\Auth;

class AuthRequest extends ApiRequest
{
  public function authorize(): bool
  {
    if (Auth::attempt(request()->only('login', 'password'))) {
      return true;
    }

    throw new UnauthorizedException();
  }

  public function rules(): array
  {
    return [
      'login' => 'required|string',
      'password' => 'required|string',
    ];
  }
}
