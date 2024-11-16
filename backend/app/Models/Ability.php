<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

class Ability extends Model
{
  protected $fillable = [
    'name',
    'description',
    'photo_url',
    'hero_id',
  ];

}
