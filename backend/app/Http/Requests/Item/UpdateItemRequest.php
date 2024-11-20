<?php

namespace App\Http\Requests\Item;

use App\Http\Requests\ApiRequest;

class UpdateItemRequest extends ApiRequest
{
  public function rules(): array
  {
    return [
      'title' => 'sometimes|string|max:255',
      'is_activated' => 'nullable|boolean',
      'preview_url' => 'sometimes|string|max:255',
      'description' => 'nullable|string',
      'price' => 'sometimes|numeric|min:0.1',
      'item_category_id' => 'sometimes|integer|exists:item_category_id,id',
    ];
  }
}
