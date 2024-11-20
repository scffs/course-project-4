<?php

namespace App\Models\Hero;

use Eloquent;
use Illuminate\Database\Eloquent\Builder;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\Relations\BelongsTo;

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

  public function hero(): BelongsTo
  {
    return $this->belongsTo(Hero::class);
  }
}
