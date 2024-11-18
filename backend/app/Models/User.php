<?php

namespace App\Models;

// use Illuminate\Contracts\Auth\MustVerifyEmail;
use App\Interfaces\ApiTokenInterface;
use App\Models\Article\Comment;
use Eloquent;
use Illuminate\Database\Eloquent\Builder;
use Illuminate\Database\Eloquent\Relations\BelongsTo;
use Illuminate\Database\Eloquent\Relations\HasMany;
use Illuminate\Foundation\Auth\User as Authenticatable;
use Laravel\Sanctum\HasApiTokens;

/**
 * @mixin Eloquent
 * @mixin Builder
 */
class User extends Authenticatable implements ApiTokenInterface
{
  use HasApiTokens;

  protected $fillable = [
    'name',
    'surname',
    'patronymic',
    'sex',
    'birthday',
    'status',
    'login',
    'avatar_url',
    'password',
    'role_id',
  ];

  protected $hidden = [
    'password',
    'remember_token',
  ];

  public function generateApiToken(): string
  {
    return $this->createToken('user')->plainTextToken;
  }

  public function resetApiToken(): void
  {
    $this->currentAccessToken()->delete();
  }

  public function comments(): HasMany
  {
    return $this->hasMany(Comment::class, 'user_id');
  }

  public function isAdmin(): bool
  {
    return $this->role->code === 'admin';
  }

  public function role(): BelongsTo
  {
    return $this->belongsTo(Role::class, 'role_id');
  }

  protected function casts(): array
  {
    return [
      'password' => 'hashed',
      'sex' => 'boolean',
    ];
  }
}
