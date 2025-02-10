<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration {
  public function up(): void
  {
    Schema::create('articles', function (Blueprint $table) {
      $table->id();
      $table->text('text');
      $table->string('title');
      $table->string('description')->nullable();
      $table->string('preview');
      $table->foreignId('author_id')->constrained('users');
      $table->foreignId('article_category_id')->constrained('article_categories');
      $table->timestamps();
    });
  }
  public function down(): void
  {
    Schema::dropIfExists('articles');
  }
};
