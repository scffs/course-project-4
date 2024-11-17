<?php

namespace App\Models\Hero;

use Eloquent;
use Illuminate\Database\Eloquent\Builder;
use Illuminate\Database\Eloquent\Model;

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
}
