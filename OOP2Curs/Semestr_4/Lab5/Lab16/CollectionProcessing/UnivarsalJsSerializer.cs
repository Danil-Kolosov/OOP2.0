using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Json.Serialization.Metadata;
using System.Text.Json.Serialization;
using System.Collections.ObjectModel;
using AnimalLibrary;
using CollectionProcessing;
using CollectionEvent;
using System.Runtime.InteropServices.ComTypes;


namespace Serialisation
{
    public static class UniversalJsSerializer<TKey, TVal>
    {

        public static async Task SerializeAsync<T>(T obj, string filePath)
        {
            var options = new JsonSerializerOptions
            {
                Converters = { new MyNewCollectionJsonConverter<TKey, TVal>() },
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping, // Кириллица
                //IncludeFields = true,  // Сериализовать поля (если нужно)
                WriteIndented = true,  // Красивый вывод
                //PropertyNamingPolicy = JsonNamingPolicy.CamelCase,  // camelCase в JSON
                //IgnoreReadOnlyProperties = false  // Сериализовать свойства без сеттера
            };
            using (FileStream stream = new FileStream(
                filePath,
                FileMode.Create,
                FileAccess.Write,
                FileShare.None,
                bufferSize: 4096,
                useAsync: true)) // Включаем асинхронный режим
            {
                await JsonSerializer.SerializeAsync(stream, obj, options)
                    .ConfigureAwait(false);
            }
        }

        public static async Task<T> DeserializeAsync<T>(string filePath)
        {
            var options = new JsonSerializerOptions
            {
                Converters = { new MyNewCollectionJsonConverter<TKey, TVal>() },
                PropertyNameCaseInsensitive = true
            };

            using (FileStream stream = new FileStream(
                filePath,
                FileMode.Open,
                FileAccess.Read,
                FileShare.Read,
                bufferSize: 8192,
                useAsync: true)) // Критично для асинхронности!
            {
                return await JsonSerializer.DeserializeAsync<T>(stream, options)
                       .ConfigureAwait(false);
            }
        }









        public static /*async*/ void Serialize<T>(T obj, string filePath)
        {
            var options = new JsonSerializerOptions
            {
                Converters = { new MyNewCollectionJsonConverter<string, Animal>() },
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping, // Кириллица
                IncludeFields = true,  // Сериализовать поля (если нужно)
                WriteIndented = true,  // Красивый вывод
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,  // camelCase в JSON
                IgnoreReadOnlyProperties = false  // Сериализовать свойства без сеттера
            };
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                JsonSerializer.Serialize<T>(stream, obj, options);
            }
        }                

        public static /*async Task<T>*/T Deserialize<T>(string filePath)
        {
            var options = new JsonSerializerOptions
            {
                Converters = { new MyNewCollectionJsonConverter<TKey, TVal/*string, Animal*/>() },
                PropertyNameCaseInsensitive = true,  // Игнорирует регистр
            };
            using (FileStream stream = new FileStream(filePath, FileMode.Open))
            {
                //Get data as a dictionary because JS serializator can't properly work with custom hashtable
                MyNewCollectionJsonConverter<TKey, TVal/*string, Animal*/>  pp = new MyNewCollectionJsonConverter<TKey, TVal/*string, Animal*/>();
                T data = JsonSerializer.Deserialize<T>(stream, options);
                return data;
            }
        }
       
    }
}
