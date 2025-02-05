<?php

namespace App\Http\Controllers;

use App\Http\Requests\Hero\StoreHeroRequest;
use App\Http\Requests\Hero\UpdateHeroRequest;
use App\Models\Hero\Hero;
use Illuminate\Foundation\Auth\Access\AuthorizesRequests;
use Illuminate\Http\JsonResponse;

class HeroController extends Controller
{
  use AuthorizesRequests;

  public function __construct()
  {
    $this->authorizeResource(Hero::class, 'hero');
  }

  public function index(): JsonResponse
  {
    $heroes = Hero::with('abilities')->get();
    return response()->json($heroes);
  }

  public function store(StoreHeroRequest $request): JsonResponse
  {
    $hero = Hero::create($request->validated());
    return response()->json($hero, 201);
  }

  public function show(Hero $hero): JsonResponse
  {
    $hero->load('abilities');
    return response()->json($hero);
  }

  public function update(UpdateHeroRequest $request, Hero $hero): JsonResponse
  {
    $hero->update($request->validated());
    return response()->json($hero);
  }

  public function destroy(Hero $hero): JsonResponse
  {
    $hero->delete();
    return response()->json(null, 204);
  }
}
