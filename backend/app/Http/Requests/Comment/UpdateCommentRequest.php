<?php

namespace App\Http\Requests\Comment;

use App\Http\Requests\ApiRequest;

class UpdateCommentRequest extends ApiRequest
{
  public function rules(): array
  {
    return [
      'text' => 'string',
      'article_id' => 'exists:articles,id',
    ];
  }
}
