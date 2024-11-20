<?php

namespace App\Http\Requests\Article;

use App\Http\Requests\ApiRequest;

class StoreArticleRequest extends ApiRequest
{
  public function rules(): array
  {
    return [
      'text' => 'required|string',
      'title' => 'required|string',
      'description' => 'required|string',
      'preview' => 'required|string',
      'author_id' => 'required|exists:users,id',
      'article_category_id' => 'required|exists:article_categories,id',
    ];
  }
}
