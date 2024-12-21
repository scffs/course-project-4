<?php

namespace App\Http\Requests;

class UpdateUserRequest extends ApiRequest
{
  public function rules(): array
  {
    return [
      'name' => 'sometimes|string|min:2|max:255',
      'surname' => 'sometimes|string|min:2|max:100',
      'patronymic' => 'nullable|string|min:2|max:100',
      'birthday' => 'sometimes|date',
      'status' => 'nullable|string|max:60',
      'login' => 'sometimes|string|unique:users,login',
      'password' => 'sometimes|string|min:6',
      'avatar_url' => 'nullable|string',
      'sex' => 'sometimes|boolean',
    ];
  }
}
