<?php

namespace Database\Seeders;

use App\Models\Ability;
use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;
class AbilitySeeder extends Seeder
{
    /**
     * Run the database seeds.
     */
    public function run(): void
    {
      Ability::create([
        'name' => 'Siphon Life',
        'description' => 'Высасывает здоровье врагов, которые находятся спереди и попадают в радиус действия.',
        'photo_url' => '123',
        'hero_id' => 1
      ]);
      Ability::create([
        'name' => 'Shoulder Charge',
        'description' => 'Abrams делает рывок вперёд, тащит за собой врагов и оглушает их, если ударится об стену. При столкновении с вражескими героями скорость рывка увеличивается.',
        'photo_url' => '123',
        'hero_id' => 1
      ]);
      Ability::create([
        'name' => 'Infernal Resilence',
        'description' => 'Постепенно восстанавливает часть здоровья, потерянного при получении урона.',
        'photo_url' => '123',
        'hero_id' => 1
      ]);
      Ability::create([
        'name' => 'Seismic Impact',
        'description' => 'Герой подпрыгивает высоко в воздух, а затем обрушивается в выбранную точку. Ударная волна от приземления наносит урон всем врагам в радиусе действия и оглушает их.',
        'photo_url' => '123',
        'hero_id' => 1
      ]);
      Ability::create([
        'name' => 'Alchemical Flask',
        'description' => 'Кидает вперёд бутыль, которая при попадании во вражескую сущность или землю нанесёт урон, замедлит и уменьшит урон от пуль всем противникам в радиусе.',
        'photo_url' => '123',
        'hero_id' => 2
      ]);
      Ability::create([
        'name' => 'Willpower',
        'description' => 'Даёт Вардену щит защищающий от духовного урона и блокирующий эффекты наносящие духовный урон. Также щит увеличивает скорость передвижения Вардена.',
        'photo_url' => '123',
        'hero_id' => 2
      ]);
      Ability::create([
        'name' => 'Binding Word',
        'description' => 'Направленная способность. Создаёт вокруг выбранного противника область. Если по истечении времени противник не выберется из этой области он получит урон и будет прикован к земле на время.',
        'photo_url' => '123',
        'hero_id' => 2
      ]);
      Ability::create([
        'name' => 'Last Stand',
        'description' => 'После подготовки выпускает пульсации, которые наносят урон противникам и лечат Вардена на часть нанесённого урона.',
        'photo_url' => '123',
        'hero_id' => 2
      ]);
    }
}
