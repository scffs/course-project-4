<?php

namespace App\Models\Item;

use Eloquent;
use Illuminate\Database\Eloquent\Builder;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\Relations\HasMany;

/**
 * @mixin Eloquent
 * @mixin Builder
 */
class ItemCategory extends Model
{
  protected $fillable = [
    'name',
    'code',
  ];

  public function items(): HasMany
  {
    return $this->hasMany(Item::class);
  }
}
