<?php

namespace App\Http\Requests\Ability;


use App\Http\Requests\ApiRequest;

class StoreAbilityRequest extends ApiRequest
{
  public function rules(): array
  {
    return [
      'name' => 'required|string|max:100',
      'description' => 'nullable|string',
      'photo_url' => 'required|string|max:255',
      'hero_id' => 'required|integer|exists:heroes,id',
    ];
  }
}
