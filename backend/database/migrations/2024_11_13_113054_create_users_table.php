<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration {
  public function up(): void
  {
    Schema::create('users', function (Blueprint $table) {
      $table->id();
      $table->string('name');
      $table->string('surname', 100);
      $table->string('patronymic', 100)->nullable();
      $table->date('birthday');
      $table->string('status', 60)->nullable();
      $table->string('login')->unique();
      $table->string('password');
      $table->string('avatar_url')->nullable();
      $table->boolean('sex');
      $table->foreignId('role_id')->constrained();
      $table->timestamps();
    });
  }
  public function down(): void
  {
    Schema::dropIfExists('users');
  }
};
