<?php

namespace App\Http\Requests\Ability;

use App\Http\Requests\ApiRequest;

class UpdateAbilityRequest extends ApiRequest
{
  public function rules(): array
  {
    return [
      'name' => 'sometimes|string|max:100',
      'description' => 'nullable|string',
      'photo_url' => 'sometimes|string|max:255',
      'hero_id' => 'sometimes|integer|exists:heroes,id',
    ];
  }
}
