<?php

namespace App\Http\Controllers;

use App\Http\Requests\UpdateUserRequest;
use App\Models\User;
use Illuminate\Foundation\Auth\Access\AuthorizesRequests;
use Illuminate\Http\JsonResponse;

class ProfileController extends Controller
{
  use AuthorizesRequests;

  public function __construct()
  {
    $this->authorizeResource(User::class, 'profile');
  }

  // profile - то, какой юзер обновляется
  public function show(User $profile): JsonResponse
  {
    return response()->json($profile);
  }

  public function update(UpdateUserRequest $request, User $profile): JsonResponse
  {
    $profile->update($request->validated());
    return response()->json($profile);
  }
}
