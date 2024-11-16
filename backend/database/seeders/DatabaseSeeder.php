<?php

namespace Database\Seeders;

use Illuminate\Database\Seeder;

// use Illuminate\Database\Console\Seeds\WithoutModelEvents;

class DatabaseSeeder extends Seeder
{
  /**
   * Seed the application's database.
   */
  public function run(): void
  {
    // Вызов наполнителей
    $this->call([
      RoleSeeder::class,
      UserSeeder::class,
      HeroSeeder::class,
      AbilitySeeder::class,
    ]);
  }
}
