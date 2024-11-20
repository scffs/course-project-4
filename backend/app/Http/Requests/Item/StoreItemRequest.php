<?php

namespace App\Http\Requests\Item;


use App\Http\Requests\ApiRequest;

class StoreItemRequest extends ApiRequest
{
  public function rules(): array
  {
    return [
      'title' => 'required|string|max:255',
      'is_activated' => 'nullable|boolean',
      'preview_url' => 'required|string|max:255',
      'description' => 'nullable|string',
      'price' => 'required|numeric|min:0.1',
      'item_category_id' => 'required|integer|exists:item_category_id,id',
    ];
  }
}
