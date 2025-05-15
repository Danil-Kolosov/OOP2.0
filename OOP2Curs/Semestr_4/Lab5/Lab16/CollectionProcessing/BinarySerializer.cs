using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CollectionProcessing
{
    public static class BinarySerializer
    {
        public static void SerializeToBinary<T>(T obj, List<string> pathList)
        {
            if (pathList == null || pathList.Count < 2)
                throw new ArgumentException("Список путей файлов должен содержать хотя бы 2 элемента");

            using (FileStream fs = new FileStream(pathList[0], FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, obj);
            }            
        }

        public static async Task<T> DeserializeFromBinaryAsync<T>(string filePath)
        {
            byte[] fileData;

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read,
                FileShare.Read, bufferSize: 4096, useAsync: true))
            {
                fileData = new byte[fs.Length];
                await fs.ReadAsync(fileData, 0, (int)fs.Length);
            }

            using (MemoryStream ms = new MemoryStream(fileData))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return (T)formatter.Deserialize(ms);
            }
        }
    }
}
