<?php

namespace App\Models;

use Eloquent;
use Illuminate\Database\Eloquent\Builder;
use Illuminate\Database\Eloquent\Concerns\HasAttributes;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\Relations\BelongsTo;

/**
 * @mixin Eloquent
 * @mixin Builder
 */
class Comment extends Model
{
  use HasAttributes;

  protected $fillable = [
    'text',
    'user_id',
    'article_id',
  ];

  public function user(): BelongsTo
  {
    return $this->belongsTo(User::class, 'author_id');
  }

  public function article(): BelongsTo
  {
    return $this->belongsTo(Article::class);
  }
}
