<?php

namespace App\Http\Controllers\Api;

use App\Exceptions\ApiException;
use App\Http\Controllers\Controller;
use App\Http\Requests\Api\ApiRequest;
use App\Http\Requests\Api\RegisterRequest;
use App\Models\Role;
use App\Models\User;
use Illuminate\Http\JsonResponse;
use Illuminate\Support\Facades\Auth;

class AuthController extends Controller
{
  public function register(RegisterRequest $request): JsonResponse
  {
    $role_user = Role::getUserRoleId();
    $path = null;

    if ($request->hasFile('avatar')) {
      $path = $request->file('avatar')->store('avatars', 'public');
    }

    $user = User::create([
      ...$request->validated(), 'avatar' => $path, 'role_id' => $role_user->id
    ]);

    $api_token = $user->generateApiToken();

    return response()->json([
      'user' => $user,
      'token' => $api_token,
    ], 201);
  }

  public function login(ApiRequest $request): JsonResponse
  {
    if (!Auth::attempt($request->only('email', 'password'))) {
      throw new ApiException('Failed auth', 401);
    }

    $user = Auth::user();
    $api_token = $user->generateApiToken();

    return response()->json([
      'user' => $user,
      'token' => $api_token,
    ]);
  }


  public function logout(): JsonResponse
  {
    $user = Auth::user();
    $user->resetApiToken();

    return response()->json();
  }
}
