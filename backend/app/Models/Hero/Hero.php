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
  protected $casts = [
    'damage_per_sec' => 'float', // или 'decimal:2'
    'move_speed' => 'float',     // или 'decimal:2'
    'weapon_damage' => 'float',  // или 'decimal:2'
  ];

  public function abilities(): HasMany
  {
    return $this->hasMany(Ability::class);
  }
}
