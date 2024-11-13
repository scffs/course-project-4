<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\Relations\HasMany;

class Role extends Model
{
  protected $fillable = [
    'name',
    'code'
  ];

  public static function getUserRoleId()
  {
    return self::where('code', 'user')->first()->id;
  }

  public function users(): HasMany
  {
    return $this->hasMany(User::class);
  }
}
