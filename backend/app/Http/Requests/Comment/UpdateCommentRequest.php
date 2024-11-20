<?php

namespace App\Http\Requests\Comment;

use Illuminate\Foundation\Http\FormRequest;

class UpdateCommentRequest extends FormRequest
{
  public function rules(): array
  {
    return [
      'text' => 'string',
      'user_id' => 'exists:users,id',
      'article_id' => 'exists:articles,id',
    ];
  }
}
