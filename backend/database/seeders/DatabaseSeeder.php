<?php

namespace Database\Seeders;

use Illuminate\Database\Seeder;

// use Illuminate\Database\Console\Seeds\WithoutModelEvents;

class DatabaseSeeder extends Seeder
{
  public function run(): void
  {
    // Вызов заполнителей
    $this->call([
      RoleSeeder::class,
      UserSeeder::class,
      HeroSeeder::class,
      AbilitySeeder::class,
    ]);
  }
}
