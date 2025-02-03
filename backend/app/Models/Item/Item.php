<?php

namespace App\Models\Item;

use Eloquent;
use Illuminate\Database\Eloquent\Builder;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\Relations\BelongsTo;

/**
 * @mixin Eloquent
 * @mixin Builder
 */
class Item extends Model
{
  protected $fillable = [
    'title',
    'is_activated',
    'preview_url',
    'description',
    'price',
    'item_category_id',
  ];
  protected $casts = [
    'price' => 'float'
  ];
  public function itemCategory(): BelongsTo
  {
    return $this->belongsTo(ItemCategory::class);
  }
}
