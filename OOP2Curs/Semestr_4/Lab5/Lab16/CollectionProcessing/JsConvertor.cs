using AnimalLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using CollectionEvent;
using MyCollectionLibrary;

namespace Serialisation
{
    public class MyNewCollectionJsonConverter<TKey, TVal> : JsonConverter<MyNewCollection<TKey, TVal>>
    {        
        public override void Write(Utf8JsonWriter writer, MyNewCollection<TKey, TVal> value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            // Сериализуем Name как отдельное свойство
            writer.WritePropertyName("name");
            JsonSerializer.Serialize(writer, value.Name, options);

            // Сериализуем Name как отдельное свойство
            writer.WritePropertyName("capacity");
            JsonSerializer.Serialize(writer, value.Count, options);

            // Сериализуем hashTable как отдельное свойство
            writer.WritePropertyName("hashTable");
            JsonSerializer.Serialize(writer, value.Hashtable, options);

            // Сериализуем элементы как словарь
            //writer.WritePropertyName("items");
            //writer.WriteStartObject();
            //foreach (var pair in value)
            //{
            //    writer.WritePropertyName(pair.Key.ToString());
            //    JsonSerializer.Serialize(writer, pair.Value, options);
            //}
            //writer.WriteEndObject();

            writer.WriteEndObject();
        }

        public override MyNewCollection<TKey, TVal> Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
                throw new JsonException();

            var collection = new MyNewCollection<TKey, TVal>();
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                    return collection;

                if (reader.TokenType != JsonTokenType.PropertyName)
                    throw new JsonException();

                var propertyName = reader.GetString();
                reader.Read();

                switch (propertyName)
                {
                    case "name":
                        collection.Name = reader.GetString();
                        break;
                    case "capacity":
                        collection.Hashtable = new Point<TKey, TVal>[(int)reader.GetDecimal()];
                        break;
                    case "hashTable":
                        ReadHashTable(ref reader, collection, options);
                        break;
                    default:
                        reader.Skip(); //Пока до имени нужного свойства не дойдем
                        break;
                }
            }

            throw new JsonException(); //Вышли из цикла но не завершили чтение
        }

        private void ReadHashTable(
            ref Utf8JsonReader reader,
            MyNewCollection<TKey, TVal> collection,
            JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartArray)
                throw new JsonException();

            while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
            {
                if (reader.TokenType == JsonTokenType.Null)
                    continue;

                if (reader.TokenType != JsonTokenType.StartObject)
                    throw new JsonException();

                var point = JsonSerializer.Deserialize<Point<TKey, TVal>>(ref reader, options);
                if (point != null && point.Value != null && point.Key != null)
                    collection.Add(point);
            }
        }
    }




    /*public class AnimalJsonConverter : JsonConverter<Animal>
    {
        public override Animal Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
            {
                JsonElement root = doc.RootElement;

                if (!root.TryGetProperty("$type", out JsonElement typeProp))
                    throw new JsonException("Type discriminator ($type) not found");

                string typeValue = typeProp.GetString();

                if (typeValue == "bird")
                    return JsonSerializer.Deserialize<Bird>(root.GetRawText(), options);
                else if (typeValue == "mammal")
                    return JsonSerializer.Deserialize<Mammal>(root.GetRawText(), options);
                else if (typeValue == "artiodactyl")
                    return JsonSerializer.Deserialize<Artiodactyl>(root.GetRawText(), options);
                else
                    throw new JsonException($"Unknown animal type: {typeValue}");
            }
        }

        public override void Write(
            Utf8JsonWriter writer,
            Animal value,
            JsonSerializerOptions options)
        {
            // Сериализуем как object, чтобы включить $type
            JsonSerializer.Serialize(writer, (object)value, options);
        }
    }*/
}
