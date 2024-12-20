<?php

namespace App\Models\Article;

use App\Models\User;
use Eloquent;
use Illuminate\Database\Eloquent\Builder;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\Relations\BelongsTo;

/**
 * @mixin Eloquent
 * @mixin Builder
 */
class Comment extends Model
{
  protected $fillable = [
    'text',
    'user_id',
    'article_id',
  ];

  public function user(): BelongsTo
  {
    return $this->belongsTo(User::class);
  }

  public function article(): BelongsTo
  {
    return $this->belongsTo(Article::class);
  }
}
