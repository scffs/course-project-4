<?php

namespace App\Policies;

use App\Models\Article\Comment;
use App\Models\User;
use Illuminate\Auth\Access\HandlesAuthorization;

class CommentPolicy
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

  public function create(User $user): bool
  {
    return true;
  }

  public function update(User $user, Comment $comment): bool
  {
    return $user->id === $comment->user_id || $user->isAdmin();
  }

  public function delete(User $user, Comment $comment): bool
  {
    return $user->id === $comment->user_id || $user->isAdmin();
  }
}
