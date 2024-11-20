<?php

namespace App\Models\Hero;

use Eloquent;
use Illuminate\Database\Eloquent\Builder;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\Relations\HasMany;

/**
 * @mixin Eloquent
 * @mixin Builder
 */
class Hero extends Model
{
  protected $fillable = [
    'name',
    'sex',
    'description',
    'photo_url',
    'health',
    'damage_per_sec',
    'bullets_amount',
    'move_speed',
    'weapon_damage',
  ];

  public function abilities(): HasMany
  {
    return $this->hasMany(Ability::class);
  }
}
