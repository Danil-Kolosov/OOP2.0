/*

using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

public static class UniversalXmlSerializer
{
    public static void Serialize<T>(T obj, string filePath, XmlSerializer serializer)
    {
        //Это работает но гавно с размерами и чтением получается если только в под коллекцию пихать 
        //var serializer = new XmlSerializer(typeof(T));
        //using (FileStream fs = new FileStream(filePath, FileMode.Create)) 
        //{
        //    serializer.Serialize(fs, obj);
        //}

        //тут он xml= ****** видит и ломается
        //var serializer = new XmlSerializer(typeof(T)); 
        // var settings = new XmlWriterSettings { Indent = true };

        //using (var writer = XmlWriter.Create(filePath, settings))
        //{
        //    serializer.Serialize(writer, obj);
        //}

        //var serializer = new XmlSerializer(typeof(T));
        using (var writer = new StreamWriter(filePath))
        {
            serializer.Serialize(writer, obj);
        }
    }

    public static async Task SerializeAsync<T>(T obj, string filePath, XmlSerializer serializer)
    {
        // 1. Синхронная сериализация в MemoryStream
        using (MemoryStream ms = new MemoryStream())
        {
            serializer.Serialize(ms, obj);
            ms.Position = 0;

            // 2. Асинхронная запись в файл
            using (FileStream fs = new FileStream(
                filePath,
                FileMode.Create,
                FileAccess.Write,
                FileShare.None,
                bufferSize: 8192,
                useAsync: true)) // Можно и без useAsync, но с ним - лучше для больших файлов
            {
                await ms.CopyToAsync(fs).ConfigureAwait(false);
            }
        }
    }

    public static T Deserialize<T>(string filePath, XmlSerializer serializer)
    {
        //Это работает но гавно с размерами и чтением получается если только в под коллекцию пихать 
        //var serializer = new XmlSerializer(typeof(T));
        //using (FileStream fs = new FileStream(filePath, FileMode.Open)) 
        //{
        //    return (T)serializer.Deserialize(fs);
        //}

        //тут он xml= ****** видит и ломается
        //var serializer = new XmlSerializer(typeof(T));
        //using (var reader = XmlReader.Create(filePath))
        //{
        //    return (T)serializer.Deserialize(reader);
        //}

        //var serializer = new XmlSerializer(typeof(T)); теперь в парпаметрах в () метода
        using (var reader = new StreamReader(filePath))
        {

            return (T)serializer.Deserialize(reader);
        }
    }

    public static async Task<T> DeserializeAsync<T>(string filePath, XmlSerializer serializer)
    {
        // 1. Асинхронное чтение файла в MemoryStream
        byte[] fileData;
        using (var fs = new FileStream(
            filePath,
            FileMode.Open,
            FileAccess.Read,
            FileShare.Read,
            bufferSize: 8192,
            useAsync: true)) // Включаем асинхронный режим
        {
            fileData = new byte[fs.Length];
            await fs.ReadAsync(fileData, 0, (int)fs.Length).ConfigureAwait(false);
        }

        // 2. Синхронная десериализация (XmlSerializer не поддерживает async)
        using (var ms = new MemoryStream(fileData))
        {
            return (T)serializer.Deserialize(ms);
        }
    }
}
*/