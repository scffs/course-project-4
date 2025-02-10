<?php

namespace App\Models;

use App\Interfaces\ApiTokenInterface;
use App\Models\Article\Comment;
use Illuminate\Database\Eloquent\Relations\BelongsTo;
use Illuminate\Database\Eloquent\Relations\HasMany;
use Illuminate\Foundation\Auth\User as Authenticatable;
use Laravel\Sanctum\HasApiTokens;

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

  // Генерация уникального API токена и его возвращение
  public function generateApiToken(): string
  {
    return $this->createToken('user')->plainTextToken;
  }

  // Удаление токена
  public function resetApiToken(): void
  {
    $this->currentAccessToken()->delete();
  }

  // Получение комментариев пользователя по связи
  public function comments(): HasMany
  {
    return $this->hasMany(Comment::class, 'user_id');
  }

  // Получение роли пользователя по связи
  public function role(): BelongsTo
  {
    return $this->belongsTo(Role::class, 'role_id');
  }

  // Проверка является ли текущий пользователь администратором
  public function isAdmin(): bool
  {
    return $this->role->code === 'admin';
  }

  protected function casts(): array
  {
    return [
      'password' => 'hashed',
      'sex' => 'boolean',
    ];
  }
}
