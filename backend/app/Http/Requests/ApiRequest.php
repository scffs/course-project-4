<?php

namespace App\Http\Requests;

use App\Exceptions\ApiException;
use App\Exceptions\ForbiddenException;
use Illuminate\Contracts\Validation\Validator;
use Illuminate\Foundation\Http\FormRequest;

class ApiRequest extends FormRequest
{
  /**
   * @throws ApiException
   */
  public function failedAuthorization()
  {
    throw new ForbiddenException();
  }

  /**
   * @throws ApiException
   */
  public function failedValidation(Validator $validator)
  {
    throw new ApiException('Validation failed', 422, $validator->errors());
  }
}
