<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration {
  public function up(): void
  {
    Schema::create('abilities', function (Blueprint $table) {
      $table->id();
      $table->string('name', 100);
      $table->text('description')->nullable();
      $table->string('photo_url');
      $table->foreignId('hero_id')->constrained('heroes', 'id');
      $table->timestamps();
    });
  }
  public function down(): void
  {
    Schema::dropIfExists('abilities');
  }
};
