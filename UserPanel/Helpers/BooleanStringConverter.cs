﻿using System;
using System.Buffers;
using System.Text.Json;
using System.Text.Json.Serialization;

public class BooleanStringConverter : JsonConverter<bool>
{
    public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.String:
                // Преобразование строковых значений ("true", "false")
                if (bool.TryParse(reader.GetString(), out var result))
                {
                    return result;
                }
                break;

            case JsonTokenType.Number:
                // Преобразование числовых значений (1 -> true, 0 -> false)
                if (reader.TryGetInt32(out var number))
                {
                    return number != 0;
                }
                break;

            case JsonTokenType.True:
                return true;

            case JsonTokenType.False:
                return false;
        }

        throw new JsonException($"Cannot convert value to boolean: {reader.TokenType}");
    }

    public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
    {
        writer.WriteBooleanValue(value);
    }
}