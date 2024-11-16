<?php

namespace App\Models\User;

// use Illuminate\Contracts\Auth\MustVerifyEmail;
use App\Interfaces\ApiTokenInterface;
use App\Models\Article\Comment;
use Eloquent;
use Illuminate\Database\Eloquent\Builder;
use Illuminate\Database\Eloquent\Concerns\HasAttributes;
use Illuminate\Database\Eloquent\Relations\HasMany;
use Illuminate\Foundation\Auth\User as Authenticatable;
use Illuminate\Support\Facades\Hash;
use Illuminate\Support\Str;
use Laravel\Sanctum\HasApiTokens;

/**
 * @mixin Eloquent
 * @mixin Builder
 */
class User extends Authenticatable implements ApiTokenInterface
{
  use HasAttributes, HasApiTokens;

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
    $this->api_token = Hash::make(Str::random(60));
    $this->save();

    return $this->api_token;
  }

  public function resetApiToken(): void
  {
    $this->api_token = null;
    $this->save();
  }

  public function comments(): HasMany
  {
    return $this->hasMany(Comment::class, 'user_id');
  }

  protected function casts(): array
  {
    return [
      'password' => 'hashed',
      'sex' => 'boolean',
    ];
  }
}
