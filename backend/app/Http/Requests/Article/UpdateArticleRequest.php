<?php

namespace App\Http\Requests\Article;

use Illuminate\Foundation\Http\FormRequest;

class UpdateArticleRequest extends FormRequest
{
  public function rules(): array
  {
    return [
      'text' => 'string',
      'title' => 'string',
      'description' => 'string',
      'preview' => 'string',
      'author_id' => 'exists:users,id',
      'article_category_id' => 'exists:article_categories,id',
    ];
  }
}
