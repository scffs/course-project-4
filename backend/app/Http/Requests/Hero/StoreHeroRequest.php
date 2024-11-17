<?php

namespace App\Http\Requests\Hero;


use App\Http\Requests\ApiRequest;

class StoreHeroRequest extends ApiRequest
{
  public function rules(): array
  {
    return [
      'name' => 'required|string|max:255',
      'sex' => 'required|boolean',
      'description' => 'nullable|string',
      'photo_url' => 'required|string|max:255',
      'health' => 'required|integer|min:1',
      'damage_per_sec' => 'required|numeric|min:0.01',
      'bullets_amount' => 'required|integer|min:1',
      'move_speed' => 'required|numeric|min:0.01',
      'weapon_damage' => 'required|numeric|min:0.01',
    ];
  }
}
