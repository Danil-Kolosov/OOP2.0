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


//namespace Serialisation
//{
//    public static class UniversalJsSerializer
//    {
//        public static /*async*/ void Serialize<T>(T obj, string filePath)
//        {
//            var options = new JsonSerializerOptions
//            {
//                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping, // Кириллица
//                IncludeFields = true,  // Сериализовать поля (если нужно)
//                WriteIndented = true,  // Красивый вывод
//                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,  // camelCase в JSON
//                IgnoreReadOnlyProperties = false  // Сериализовать свойства без сеттера
//            };
//            using (FileStream stream = new FileStream(filePath, FileMode.Create))
//            {
//                JsonSerializer.Serialize<T>(stream, obj, options);
//            }


//            //using (FileStream fs = new FileStream(filePath, FileMode.Create))
//            //{
//            //    var options = new JsonSerializerOptions
//            //    {
//            //        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
//            //        WriteIndented = true,
//            //        IncludeFields = true, // Для сериализации полей
//            //        //ReferenceHandler = ReferenceHandler.Preserve // Для сложных структур
//            //    };

//                //вот это последнеее было
//                //var options = new JsonSerializerOptions
//                //{
//                //    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
//                //    WriteIndented = true,
//                //    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
//                //};
//                //var options = new JsonSerializerOptions
//                //{
//                //    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
//                //    WriteIndented = true,
//                //    IncludeFields = true, // Для сериализации полей
//                //    ReferenceHandler = ReferenceHandler.Preserve // Для сложных структур
//                //};
//                //var options = new JsonSerializerOptions
//                //{
//                //    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping, // Кириллица
//                //    WriteIndented = true                                  // Читаемый JSON
//                //};
//                //var options = new JsonSerializerOptions
//                //{
//                //    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
//                //    WriteIndented = true,
//                //    // Отключаем ReferenceHandler, если он не нужен
//                //    ReferenceHandler = null,
//                //    // Добавляем кастомный конвертер для Animal
//                //    Converters = { new CollectionProcessing.AnimalJsonConverter() }
//                //};

//                //var options = new JsonSerializerOptions
//                //{
//                //    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
//                //    WriteIndented = true,
//                //    ReferenceHandler = ReferenceHandler.Preserve,
//                //    IncludeFields = true
//                //};
//                //var options = new JsonSerializerOptions
//                //{
//                //    // Основные настройки:
//                //    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping, // Для кириллицы
//                //    WriteIndented = true,                                  // Читаемый JSON
//                //    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, // Игнорировать null

//                //    // Критически важные настройки для Point<TKey, TValue>[]:
//                //    ReferenceHandler = ReferenceHandler.Preserve,          // Для сложных структур
//                //    IncludeFields = true,                                  // Если Point использует поля

//                //    // Для полиморфизма (если TValue - Animal и наследники):
//                //    TypeInfoResolver = new DefaultJsonTypeInfoResolver
//                //    {
//                //        Modifiers = { TypeModifier }
//                //    }
//                //};
//                //var options = new JsonSerializerOptions
//                //{
//                //    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,// Разрешает кириллицу
//                //    WriteIndented = true,
//                //    IncludeFields = true // Если используете поля
//                //};               

//                //await JsonSerializer.SerializeAsync<T>(fs, obj, options);
//            //}
//        }

//        public static /*async Task<T>*/T Deserialize<T>(string filePath)
//        {
//            //var options = new JsonSerializerOptions
//            //{
//            //    PropertyNameCaseInsensitive = true,
//            //    ReadCommentHandling = JsonCommentHandling.Skip
//            //};
//            //await using var fs = new FileStream(filePath, FileMode.Open);
//            //return await JsonSerializer.DeserializeAsync<T>(fs);
//            //var options = new JsonSerializerOptions
//            //{
//            //    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
//            //    WriteIndented = true,
//            //    IncludeFields = true, // Для сериализации полей
//            //    ReferenceHandler = ReferenceHandler.Preserve // Для сложных структур
//            //    ////PropertyNameCaseInsensitive = true
//            //};
//            //using (FileStream fs = new FileStream(filePath, FileMode.Open))
//            //{
//            //    return await JsonSerializer.DeserializeAsync<T>(fs);
//            //}
//            using (FileStream stream = new FileStream(filePath, FileMode.Open))
//            {
//                //Get data as a dictionary because JS serializator can't properly work with custom hashtable
//                T data = JsonSerializer.Deserialize<T>(stream);
//                return data;
//            }
//        }
//    }
//}
