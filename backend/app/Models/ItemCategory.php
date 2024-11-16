<?php

namespace App\Models;

use Eloquent;
use Illuminate\Database\Eloquent\Builder;
use Illuminate\Database\Eloquent\Concerns\HasAttributes;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\Relations\HasMany;

/**
 * @mixin Eloquent
 * @mixin Builder
 */
class ItemCategory extends Model
{
  use HasAttributes;

  protected $fillable = [
    'name',
    'code',
  ];

  public function items(): HasMany
  {
    return $this->hasMany(Item::class);
  }
}
