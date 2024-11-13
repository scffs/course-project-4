<?php

namespace App\Models;

// use Illuminate\Contracts\Auth\MustVerifyEmail;
use Illuminate\Foundation\Auth\User as Authenticatable;
use Illuminate\Support\Facades\Hash;
use Illuminate\Support\Str;

class User extends Authenticatable
{
  protected $fillable = [
    'name',
    'email',
    'password',
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

  protected function casts(): array
  {
    return [
      'email_verified_at' => 'datetime',
      'password' => 'hashed',
    ];
  }
}
