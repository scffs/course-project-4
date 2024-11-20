<?php

namespace App\Http\Controllers;

use App\Http\Requests\Item\StoreItemRequest;
use App\Http\Requests\Item\UpdateItemRequest;
use App\Models\Item\Item;
use Illuminate\Foundation\Auth\Access\AuthorizesRequests;
use Illuminate\Http\JsonResponse;

class ItemController extends Controller
{
  use AuthorizesRequests;

  public function __construct()
  {
    $this->authorizeResource(Item::class, 'item');
  }

  public function index(): JsonResponse
  {
    $items = Item::all();
    return response()->json($items);
  }

  public function store(StoreItemRequest $request): JsonResponse
  {
    $item = Item::create($request->validated());
    return response()->json($item, 201);
  }

  public function show(Item $item): JsonResponse
  {
    return response()->json($item);
  }

  public function update(UpdateItemRequest $request, Item $item): JsonResponse
  {
    $item->update($request->validated());
    return response()->json($item);
  }

  public function destroy(Item $item): JsonResponse
  {
    $item->delete();
    return response()->json(null, 204);
  }
}
