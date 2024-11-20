<?php

namespace App\Http\Controllers;

use App\Http\Requests\Comment\StoreCommentRequest;
use App\Http\Requests\Comment\UpdateCommentRequest;
use App\Models\Article\Comment;
use Illuminate\Foundation\Auth\Access\AuthorizesRequests;
use Illuminate\Http\JsonResponse;
use Illuminate\Support\Facades\Auth;

class CommentController extends Controller
{
  use AuthorizesRequests;

  public function __construct()
  {
    $this->authorizeResource(Comment::class, 'comment');
  }

  public function store(StoreCommentRequest $request): JsonResponse
  {
    $validatedData = $request->validated();
    $validatedData['user_id'] = Auth::id();

    $comment = Comment::create($validatedData);
    return response()->json($comment, 201);
  }

  public function update(UpdateCommentRequest $request, Comment $comment): JsonResponse
  {
    $comment->update($request->validated());
    return response()->json($comment);
  }

  public function destroy(Comment $comment): JsonResponse
  {
    $comment->delete();
    return response()->json(null, 204);
  }
}
