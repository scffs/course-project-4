<?php

namespace App\Models\User;

use Eloquent;
use Illuminate\Database\Eloquent\Builder;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\Relations\HasMany;

/**
 * @mixin Eloquent
 * @mixin Builder
 */
class Role extends Model
{
  protected $fillable = [
    'name',
    'code'
  ];

//  public static function getUserRoleId(): ?int
//  {
//    return self::where('code', 'user')->first()->id;
//  }

  public function users(): HasMany
  {
    return $this->hasMany(User::class);
  }
}
