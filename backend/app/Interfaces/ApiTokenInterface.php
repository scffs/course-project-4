<?php

namespace App\Interfaces;

interface ApiTokenInterface
{
  public function generateApiToken(): string;
  public function resetApiToken(): void;
}
