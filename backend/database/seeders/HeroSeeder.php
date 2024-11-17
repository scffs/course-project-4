<?php

namespace Database\Seeders;

use App\Models\Hero\Hero;
use Illuminate\Database\Seeder;

class HeroSeeder extends Seeder
{
  /**
   * Run the database seeds.
   */
  public function run(): void
  {
    Hero::create([
      'name' => 'Abrams (Абрамс)',
      'sex' => 1,
      'description' => 'Жестокий, твердолобый и сильно пьющий детектив Abrams уже много лет является неотъемлемой частью нью-йоркской следственной жизни.',
      'photo_url' => '123',
      'health' => 600,
      'damage_per_sec' => 63,
      'bullets_amount' => 9,
      'move_speed' => 3,
      'weapon_damage' => 4.68
    ]);
    Hero::create([
      'name' => 'Warden (Дозорный)',
      'sex' => 1,
      'description' => 'Большинство людей думают, что сверхъестественное пришло в мир 50 лет назад. Они ошибаются. Его присутствие формировало фольклор на протяжении нескольких поколений.',
      'photo_url' => '123',
      'health' => 550,
      'damage_per_sec' => 79,
      'bullets_amount' => 17,
      'move_speed' => 3,
      'weapon_damage' => 19.8
    ]);
  }
}
