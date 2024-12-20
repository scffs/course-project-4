<?php

namespace App\Models\Article;

use App\Models\User;
use Eloquent;
use Illuminate\Database\Eloquent\Builder;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\Relations\BelongsTo;
use Illuminate\Database\Eloquent\Relations\HasMany;

/**
 * @mixin Eloquent
 * @mixin Builder
 */
class Article extends Model
{
  protected $fillable = [
    'text',
    'title',
    'description',
    'preview',
    'author_id',
    'article_category_id',
  ];

  public function author(): BelongsTo
  {
    return $this->belongsTo(User::class, 'author_id');
  }

  public function articleCategory(): BelongsTo
  {
    return $this->belongsTo(ArticleCategory::class);
  }

  public function comments(): HasMany
  {
    return $this->hasMany(Comment::class);
  }
}
