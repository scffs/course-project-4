<?php

namespace App\Http\Controllers;

use App\Http\Requests\Article\StoreArticleRequest;
use App\Http\Requests\Article\UpdateArticleRequest;
use App\Models\Article\Article;
use Illuminate\Foundation\Auth\Access\AuthorizesRequests;
use Illuminate\Http\JsonResponse;

class ArticleController extends Controller
{
  use AuthorizesRequests;

  public function __construct()
  {
    $this->authorizeResource(Article::class, 'article');
  }

  public function index(): JsonResponse
  {
    $articles = Article::with('author', 'articleCategory', 'comments')->get();
    return response()->json($articles);
  }

  public function store(StoreArticleRequest $request): JsonResponse
  {
    $article = Article::create($request->validated());
    return response()->json($article, 201);
  }

  public function show(Article $article): JsonResponse
  {
    $article->load('author', 'articleCategory', 'comments');
    return response()->json($article);
  }

  public function update(UpdateArticleRequest $request, Article $article): JsonResponse
  {
    $article->update($request->validated());
    return response()->json($article);
  }

  public function destroy(Article $article): JsonResponse
  {
    $article->delete();
    return response()->json(null, 204);
  }
}
