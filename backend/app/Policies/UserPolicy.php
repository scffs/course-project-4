<?php

namespace App\Policies;

use App\Models\User;
use Illuminate\Auth\Access\HandlesAuthorization;

class UserPolicy
{
  use HandlesAuthorization;

  public function viewAny(?User $user): bool
  {
    return true;
  }

  public function view(?User $user): bool
  {
    return true;
  }

  public function update(User $currentUser, User $updatedUser): bool
  {
    return $currentUser->isAdmin() || $currentUser->id == $updatedUser->id;
  }
}
