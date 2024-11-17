<?php

namespace App\Policies;

use App\Models\Hero\Hero;
use App\Models\User\User;
use Illuminate\Auth\Access\HandlesAuthorization;

class HeroPolicy
{
  use HandlesAuthorization;

  public function viewAny(User $user): bool
  {
    return $user->isAdmin();
  }

  public function view(User $user, Hero $hero): bool
  {
    return $user->isAdmin();
  }

  public function create(User $user): bool
  {
    return $user->isAdmin();
  }

  public function update(User $user, Hero $hero): bool
  {
    return $user->isAdmin();
  }

  public function delete(User $user, Hero $hero): bool
  {
    return $user->isAdmin();
  }
}
