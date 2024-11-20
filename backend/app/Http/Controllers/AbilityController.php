<?php

namespace App\Http\Controllers;

use App\Http\Requests\Ability\StoreAbilityRequest;
use App\Http\Requests\Ability\UpdateAbilityRequest;
use App\Models\Hero\Ability;
use Illuminate\Foundation\Auth\Access\AuthorizesRequests;
use Illuminate\Http\JsonResponse;

class AbilityController extends Controller
{
  use AuthorizesRequests;

  public function __construct()
  {
    $this->authorizeResource(Ability::class, 'ability');
  }

  public function index(): JsonResponse
  {
    $abilities = Ability::with('hero')->get();
    return response()->json($abilities);
  }

  public function store(StoreAbilityRequest $request): JsonResponse
  {
    $ability = Ability::create($request->validated());
    return response()->json($ability, 201);
  }

  public function show(Ability $ability): JsonResponse
  {
    $ability->load('hero');
    return response()->json($ability);
  }

  public function update(UpdateAbilityRequest $request, Ability $ability): JsonResponse
  {
    $ability->update($request->validated());
    return response()->json($ability);
  }

  public function destroy(Ability $ability): JsonResponse
  {
    $ability->delete();
    return response()->json(null, 204);
  }
}
