<?php

namespace App\Models\Hero;

use Eloquent;
use Illuminate\Database\Eloquent\Builder;
use Illuminate\Database\Eloquent\Model;

/**
 * @mixin Eloquent
 * @mixin Builder
 */
class Ability extends Model
{
  protected $fillable = [
    'name',
    'description',
    'photo_url',
    'hero_id',
  ];

}
