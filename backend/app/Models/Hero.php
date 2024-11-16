<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

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
