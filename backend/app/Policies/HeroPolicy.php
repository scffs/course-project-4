<?php

namespace App\Policies;

use App\Models\Hero\Hero;
use App\Models\User\User;
use Illuminate\Auth\Access\HandlesAuthorization;

class HeroPolicy
{
  use HandlesAuthorization;

  public function viewAny(): bool
  {
    return true;
  }

  public function view(): bool
  {
    return true;
  }

  public function create(User $user): bool
  {
    return $user->isAdmin();
  }

  public function update(User $user): bool
  {
    return $user->isAdmin();
  }

  public function delete(User $user): bool
  {
    return $user->isAdmin();
  }
}
