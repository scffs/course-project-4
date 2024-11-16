<?php

namespace Database\Seeders;

use App\Models\User;
use Illuminate\Database\Seeder;

class UserSeeder extends Seeder
{
  /**
   * Run the database seeds.
   */
  public function run(): void
  {
    User::create([
      'surname' => 'Окулов',
      'name' => 'Семён',
      'patronymic' => 'Михайлович',
      'sex' => 1,
      'birthday' => '2005-04-23',
      'status' => null,
      'password' => 'admin',
      'login' => 'admin',
      'avatar_url' => null,
      'api_token' => '1',
      'role_id' => 1,
    ]);
    User::create([
      'surname' => 'Волков',
      'name' => 'Дмитрий',
      'patronymic' => 'Павлович',
      'sex' => 1,
      'birthday' => '1995-10-13',
      'status' => null,
      'password' => 'user',
      'login' => 'user',
      'avatar_url' => null,
      'api_token' => '2',
      'role_id' => 2,
    ]);
  }
}
