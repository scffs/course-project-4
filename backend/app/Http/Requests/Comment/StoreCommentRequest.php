<?php

namespace App\Http\Requests\Comment;

use App\Http\Requests\ApiRequest;

class StoreCommentRequest extends ApiRequest
{
  public function rules(): array
  {
    return [
      'text' => 'required|string',
      'article_id' => 'required|exists:articles,id',
    ];
  }
}
