<?php

namespace App\Http\Controllers;

use App\Http\Requests\AuthRequest;
use App\Http\Requests\RegisterRequest;
use App\Models\Role;
use App\Models\User;
use Illuminate\Http\JsonResponse;
use Illuminate\Support\Facades\Auth;

class AuthController extends Controller
{
  public function register(RegisterRequest $request): JsonResponse
  {
    $role_user_id = Role::getUserRoleId();
    $path = null;

    if ($request->hasFile('avatar')) {
      $path = $request->file('avatar')->store('avatars', 'public');
    }

    $user = User::create([
      ...$request->validated(), 'avatar' => $path, 'role_id' => $role_user_id
    ]);

    $api_token = $user->generateApiToken();

    return response()->json([
      'user' => $user,
      'token' => $api_token,
    ], 201);
  }

  public function login(AuthRequest $request): JsonResponse
  {
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
