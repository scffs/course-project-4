<?php

namespace App\Models\Hero;

use Eloquent;
use Illuminate\Database\Eloquent\Builder;
use Illuminate\Database\Eloquent\Concerns\HasAttributes;
use Illuminate\Database\Eloquent\Model;

/**
 * @mixin Eloquent
 * @mixin Builder
 */
class Ability extends Model
{
  use HasAttributes;

  protected $fillable = [
    'name',
    'description',
    'photo_url',
    'hero_id',
  ];

}
