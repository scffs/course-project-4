<?php

namespace App\Http\Requests\Hero;

use App\Http\Requests\ApiRequest;

class UpdateHeroRequest extends ApiRequest
{
  public function rules(): array
  {
    return [
      'name' => 'sometimes|string|max:255',
      'sex' => 'sometimes|boolean',
      'description' => 'nullable|string',
      'photo_url' => 'sometimes|string|max:255',
      'health' => 'sometimes|integer|min:1',
      'damage_per_sec' => 'sometimes|numeric|min:0.01',
      'bullets_amount' => 'sometimes|integer|min:1',
      'move_speed' => 'sometimes|numeric|min:0.01',
      'weapon_damage' => 'sometimes|numeric|min:0.01',
    ];
  }
}
