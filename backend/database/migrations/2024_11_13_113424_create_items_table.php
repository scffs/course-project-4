<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration {
  public function up(): void
  {
    Schema::create('items', function (Blueprint $table) {
      $table->id();
      $table->string('title');
      $table->boolean('is_activated')->default(false);
      $table->string('preview_url');
      $table->text('description')->nullable();
      $table->decimal('price', 10);
      $table->foreignId('item_category_id')->constrained('item_categories');
      $table->timestamps();
    });
  }
  public function down(): void
  {
    Schema::dropIfExists('items');
  }
};
