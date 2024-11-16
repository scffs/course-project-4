<?php

namespace App\Http\Requests;

class RegisterRequest extends ApiRequest
{
  public function rules(): array
  {
    return [
      'name' => 'required|string|min:2|max:255',
      'surname' => 'required|string|min:2|max:100',
      'patronymic' => 'nullable|string|min:2|max:100',
      'birthday' => 'required|date',
      'status' => 'nullable|string|max:60',
      'login' => 'required|string|unique:users,login',
      'password' => 'required|string|min:6',
      'avatar_url' => 'nullable|string',
      'sex' => 'required|boolean',
    ];
  }
}
