<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration {
  public function up(): void
  {
    Schema::create('heroes', function (Blueprint $table) {
      $table->id();
      $table->string('name');
      $table->boolean('sex')->default(false);
      $table->string('description')->nullable();
      $table->string('photo_url');
      $table->integer('health');
      $table->decimal('damage_per_sec', 7, 2);
      $table->integer('bullets_amount');
      $table->decimal('move_speed', 5, 2);
      $table->decimal('weapon_damage', 7, 2);
      $table->timestamps();
    });
  }

  public function down(): void
  {
    Schema::dropIfExists('heroes');
  }
};
