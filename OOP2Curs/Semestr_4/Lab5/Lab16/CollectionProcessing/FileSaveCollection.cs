using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionEvent;
//using MyCollectionLibrary;
using AnimalLibrary;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Collections;
//бинарная
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using MyCollectionLibrary;
using Serialisation;
namespace CollectionProcessing
{
    public class FileSaveCollection
    {
        private static MyNewCollection<string, Animal> hashTable = null;
        //private static JournalEntry<Animal> journal = null;
        private static Journal<Animal> allEventZoo = new Journal<Animal>();

        //private static string filePathJournal = null;
        //private static string filePathCollection = null;
        //private static string collectionExtension = null;

        private static List<string> collectionPathList = null;

        public static MyNewCollection<string, Animal> HashTable
        {
            get
            {
                return hashTable;
            }
           set
            {
                hashTable = value;
            }
        }

        //запросы добавить
        //    + роверить вссе ли хоророш с журналами
        //    + стили вывода подправить чуток
        //    + кнопку просто сохранить оживить
        //    + сохранять журнал с расширением, чтобы на коллекцию с одним именем и разными расширениями был не 1 журнал, а 3 - ведь действия-то разные могут быть сделаны

        //сделать ассинхронной запись и чтение ---- осталось про тестировать --- работает
        //    +окошки при cancel - чтобы без сообщений об ошибке
        //    + ссылаться на сер/десер хмл в решение процессинг файл, а не универсальный сериализатор


        private static void JournalLink() 
        {
            //hashTable.GetALLItems();
            //journal = new JournalEntry<Animal>(args.Name, args.Type, args.ObjectData); хотел хранить ссылку на журнал
            //hashTable.CollectionCountChanged += (sourcer, args) => allEventZoo.Add(new JournalEntry<Animal>(args.Name, args.Type, args.ObjectData));
            //hashTable.CollectionReferenceChanged += (sourcer, args) => allEventZoo.Add(new JournalEntry<Animal>(args.Name, args.Type, args.ObjectData));
            // Отписываемся от предыдущих событий - если открыли коллекцию, при уже открытой
            hashTable.CollectionCountChanged -= (sourcer, args) => allEventZoo.Add(new JournalEntry<Animal>(args.Name, args.Type, args.ObjectData));
            hashTable.CollectionReferenceChanged -= (sourcer, args) => allEventZoo.Add(new JournalEntry<Animal>(args.Name, args.Type, args.ObjectData));

            // Подписываемся заново
            hashTable.CollectionCountChanged += (sourcer, args) => allEventZoo.Add(new JournalEntry<Animal>(args.Name, args.Type, args.ObjectData));
            hashTable.CollectionReferenceChanged += (sourcer, args) => allEventZoo.Add(new JournalEntry<Animal>(args.Name, args.Type, args.ObjectData));
        }

        public static void Create(int capacity)
        {
            hashTable = new MyNewCollection<string, Animal>(capacity);
            JournalLink();
            //ReportLink?            
        }

        public static void AddItem(string type, Dictionary<string, string> pararmetrs) 
        {
            switch (type)
            {
                case "Животное":
                    //из-за парсинга чисел нужно либо предусмотреть в интерфейсе либо тут трайй катч
                    hashTable.Add(
                        pararmetrs["Ключ"], 
                        new Animal(float.Parse(pararmetrs["Вес"]), 
                        float.Parse(pararmetrs["Рост"]), int.Parse(pararmetrs["Возраст"]), 
                        pararmetrs["Имя"], new NoteClass(pararmetrs["Заметки"])));
                    break;
                case "Млекопитающее":
                    hashTable.Add
                        (pararmetrs["Ключ"], new Mammal(float.Parse(pararmetrs["Вес"]),
                        float.Parse(pararmetrs["Рост"]), int.Parse(pararmetrs["Возраст"]),
                        pararmetrs["Имя"], pararmetrs["Вид"], pararmetrs["Место обитания"], 
                        pararmetrs["Среда обитания"], pararmetrs["Образ жизни"], new NoteClass(pararmetrs["Заметки"]))
                        );                       
                    break;
                case "Парнокопытное":
                    hashTable.Add
                        (pararmetrs["Ключ"], new Artiodactyl(float.Parse(pararmetrs["Вес"]),
                        float.Parse(pararmetrs["Рост"]), int.Parse(pararmetrs["Возраст"]),
                        pararmetrs["Имя"], pararmetrs["Вид"], pararmetrs["Место обитания"],
                        pararmetrs["Среда обитания"], pararmetrs["Образ жизни"], 
                        int.Parse(pararmetrs["Размер копыт"]), int.Parse(pararmetrs["Размер рогов"]),
                        new NoteClass(pararmetrs["Заметки"]))
                        );
                    break;
                case "Птица":
                    hashTable.Add(pararmetrs["Ключ"],
                        new Bird(float.Parse(pararmetrs["Вес"]),
                        float.Parse(pararmetrs["Рост"]), int.Parse(pararmetrs["Возраст"]),
                        pararmetrs["Имя"], int.Parse(pararmetrs["Размах крыльев"]), 
                        int.Parse(pararmetrs["Дальность полета"]), pararmetrs["Вид"], new NoteClass(pararmetrs["Заметки"]))
                        );
                    break;
            }
        }

        public static bool RandomInit() 
        {
            if (hashTable == null)
                return false;
            int p = 0;
            foreach(var item in hashTable) 
            {
               p++;
            }
            if (p == 0)
            {
                Random rnd = new Random();
                for (int i = 0; i < hashTable.Count; i++)
                {
                    switch (rnd.Next(1, 5))
                    {
                        case 1:
                            Animal man1 = new Animal();
                            man1.RandomInit();
                            hashTable.Add($"{i + 1}", man1);
                            break;
                        case 2:
                            Mammal man2 = new Mammal();
                            man2.RandomInit();
                            hashTable.Add($"{i + 1}", man2);
                            break;
                        case 3:
                            Artiodactyl man3 = new Artiodactyl();
                            man3.RandomInit();
                            hashTable.Add($"{i + 1}", man3);
                            break;
                        case 4:
                            Bird man4 = new Bird();
                            man4.RandomInit();
                            hashTable.Add($"{i + 1}", man4);
                            break;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool RemoveByKey(string key) 
        {
            if (hashTable == null)
                return false;
            try
            {
                return hashTable.Remove(key);
            }
            catch 
            {
                return false;
            }
        }

        public static bool UpdayeByKey(string type, Dictionary<string, string> pararmetrs) 
        {
            switch (type)
            {
                case "Животное":
                    //из-за парсинга чисел нужно либо предусмотреть в интерфейсе либо тут трайй катч
                    hashTable[pararmetrs["Ключ"]] = 
                        new Animal(float.Parse(pararmetrs["Вес"]),
                        float.Parse(pararmetrs["Рост"]), int.Parse(pararmetrs["Возраст"]),
                        pararmetrs["Имя"], new NoteClass(pararmetrs["Заметки"])
                        );
                    return true;
                case "Млекопитающее":
                    hashTable[pararmetrs["Ключ"]] =
                        new Mammal(float.Parse(pararmetrs["Вес"]),
                        float.Parse(pararmetrs["Рост"]), int.Parse(pararmetrs["Возраст"]),
                        pararmetrs["Имя"], pararmetrs["Вид"], pararmetrs["Место обитания"],
                        pararmetrs["Среда обитания"], pararmetrs["Образ жизни"], new NoteClass(pararmetrs["Заметки"])
                        );
                    return true;
                case "Парнокопытное":
                    hashTable[pararmetrs["Ключ"]] =
                        new Artiodactyl(float.Parse(pararmetrs["Вес"]),
                        float.Parse(pararmetrs["Рост"]), int.Parse(pararmetrs["Возраст"]),
                        pararmetrs["Имя"], pararmetrs["Вид"], pararmetrs["Место обитания"],
                        pararmetrs["Среда обитания"], pararmetrs["Образ жизни"],
                        int.Parse(pararmetrs["Размер копыт"]), int.Parse(pararmetrs["Размер рогов"]),
                        new NoteClass(pararmetrs["Заметки"])
                        );
                    return true;
                case "Птица":
                    hashTable[pararmetrs["Ключ"]] =
                        new Bird(float.Parse(pararmetrs["Вес"]),
                        float.Parse(pararmetrs["Рост"]), int.Parse(pararmetrs["Возраст"]),
                        pararmetrs["Имя"], int.Parse(pararmetrs["Размах крыльев"]),
                        int.Parse(pararmetrs["Дальность полета"]), pararmetrs["Вид"],
                        new NoteClass(pararmetrs["Заметки"])
                        );
                    return true;
            }
            return false;
        }

        public static bool ContainsKey(string key) 
        {
            if (hashTable == null)
                return false;
            return hashTable.ContainsKey(key);
        }

        public static string SearchByKey(string key) 
        {
            if (ContainsKey(key))
                return hashTable[key].ToString();
            else
                return null;
        }

        public static string GetJournal() 
        {
            if(collectionPathList == null)
                return "Журнал операций:\n" + allEventZoo.ToString();

            if (File.Exists(collectionPathList[1]/*filePathJournal*/)) 
            {
                //JournalSave(filePathJournal);
                return File.ReadAllText(collectionPathList[1]/*filePathJournal*/) + allEventZoo.ToString(); 
            }
            else
                return "Журнал операций:\n" + allEventZoo.ToString();
        }

        public static void FileSave(List<string> pathList) 
        {
            switch (pathList[3])
            {
                case ".bin":
                    SerializeToBinary(hashTable, pathList);
                    break;
                case ".xml":
                    SerializeToXml(pathList);
                    break;
                case ".js":
                    SerializeToJs(pathList);
                    break;
            }
        }

        public static List<KeyValuePair<string, string>> FilterBy(string type, string value) 
        {
            switch (type) 
            {
                case "Weight":
                    int val = int.Parse(value);
                    var temp = (hashTable.SelectionOnCondition(item => item.Value.Weight == val));
                    List<KeyValuePair<string, string>> result = new List<KeyValuePair<string, string>>();
                    foreach (var item in temp) 
                    {
                        result.Add(new KeyValuePair<string, string>(item.Key, item.Value.ToString()));
                    }
                    return result;
                case "Height":
                    int height = int.Parse(value);
                    var heightFilter = (hashTable.SelectionOnCondition(item => item.Value.Height == height));
                    List<KeyValuePair<string, string>> listHeightFilt = new List<KeyValuePair<string, string>>();
                    foreach (var item in heightFilter)
                    {
                        listHeightFilt.Add(new KeyValuePair<string, string>(item.Key, item.Value.ToString()));
                    }
                    return listHeightFilt;
                case "Age":
                    int age = int.Parse(value);
                    var ageFilter = (hashTable.SelectionOnCondition(item => item.Value.Age == age));
                    List<KeyValuePair<string, string>> listAgeFilt = new List<KeyValuePair<string, string>>();
                    foreach (var item in ageFilter)
                    {
                        listAgeFilt.Add(new KeyValuePair<string, string>(item.Key, item.Value.ToString()));
                    }
                    return listAgeFilt;
                case "Name":
                    string name = value/*.ToString()*/;
                    var nameFilter = (hashTable.SelectionOnCondition(item => item.Value.Name == name));
                    List<KeyValuePair<string, string>> listNameFilt = new List<KeyValuePair<string, string>>();
                    foreach (var item in nameFilter)
                    {
                        listNameFilt.Add(new KeyValuePair<string, string>(item.Key, item.Value.ToString()));
                    }
                    return listNameFilt;
                case "Specie":
                    string specie = value/*.ToString()*/;
                    var specieFilter1 = (
                    hashTable
                        .Where(item => item.Value is Mammal)
                        .Select(item => new KeyValuePair<string, Mammal>(
                            item.Key,
                            (Mammal)item.Value))
                        .Where(item => item.Value.Specie == specie)
                        .ToList());
                    var specieFilter2 = (
                    hashTable
                        .Where(item => item.Value is Artiodactyl)
                        .Select(item => new KeyValuePair<string, Artiodactyl>(item.Key, (Artiodactyl)item.Value))
                        .Where(item => item.Value.Specie == specie));

                    var specieFilter3 = (
                    hashTable
                        .Where(item => item.Value is Bird)
                        .Select(item => new KeyValuePair<string, Bird>(item.Key, (Bird)item.Value))
                        .Where(item => item.Value.Specie == specie));

                    List<KeyValuePair<string, string>> listSpecieFilt = new List<KeyValuePair<string, string>>();
                    foreach (var item in specieFilter1)
                    {
                        listSpecieFilt.Add(new KeyValuePair<string, string>(item.Key, item.Value.ToString()));
                    }
                    foreach (var item in specieFilter2)
                    {
                        listSpecieFilt.Add(new KeyValuePair<string, string>(item.Key, item.Value.ToString()));
                    }
                    foreach (var item in specieFilter3)
                    {
                        listSpecieFilt.Add(new KeyValuePair<string, string>(item.Key, item.Value.ToString()));
                    }
                    return listSpecieFilt;
                case "Location":
                    string location = value;
                    var locationFilter = (
                    hashTable
                        .Where(item => item.Value is Mammal)
                        .Select(item => new KeyValuePair<string, Mammal>(item.Key, (Mammal)item.Value))
                        .Where(item => item.Value.Location == location));
                    List<KeyValuePair<string, string>> listlocationFilt = new List<KeyValuePair<string, string>>();
                    foreach (var item in locationFilter)
                    {
                        listlocationFilt.Add(new KeyValuePair<string, string>(item.Key, item.Value.ToString()));
                    }
                    return listlocationFilt;
                case "Living environment":
                    string livingEn = value;
                    var livingEnFilter = (
                    hashTable
                        .Where(item => item.Value is Mammal)
                        .Select(item => new KeyValuePair<string, Mammal>(item.Key, (Mammal)item.Value))
                        .Where(item => item.Value.LivingEnvironment == livingEn));
                    List<KeyValuePair<string, string>> listlivingEnFilt = new List<KeyValuePair<string, string>>();
                    foreach (var item in livingEnFilter)
                    {
                        listlivingEnFilt.Add(new KeyValuePair<string, string>(item.Key, item.Value.ToString()));
                    }
                    return listlivingEnFilt;
                case "Life style":
                    string lifeStyle = value;
                    var lifeStyleFilter = (
                    hashTable
                        .Where(item => item.Value is Mammal)
                        .Select(item => new KeyValuePair<string, Mammal>(item.Key, (Mammal)item.Value))
                        .Where(item => item.Value.Lifestyle == lifeStyle));
                    List<KeyValuePair<string, string>> listlifeStyleFilt = new List<KeyValuePair<string, string>>();
                    foreach (var item in lifeStyleFilter)
                    {
                        listlifeStyleFilt.Add(new KeyValuePair<string, string>(item.Key, item.Value.ToString()));
                    }
                    return listlifeStyleFilt;
                case "hoofSize":
                    int hoofSize = int.Parse(value);
                    var hoofSizeFilter = (
                    hashTable
                        .Where(item => item.Value is Artiodactyl)
                        .Select(item => new KeyValuePair<string, Artiodactyl>(item.Key, (Artiodactyl)item.Value))
                        .Where(item => item.Value.HoofSize == hoofSize));
                    List<KeyValuePair<string, string>> listhoofSizeFilt = new List<KeyValuePair<string, string>>();
                    foreach (var item in hoofSizeFilter)
                    {
                        listhoofSizeFilt.Add(new KeyValuePair<string, string>(item.Key, item.Value.ToString()));
                    }
                    return listhoofSizeFilt;
                case "hornsSize":
                    int hornsSize = int.Parse(value);
                    var hornsSizeFilter = (
                    hashTable
                        .Where(item => item.Value is Artiodactyl)
                        .Select(item => new KeyValuePair<string, Artiodactyl>(item.Key, (Artiodactyl)item.Value))
                        .Where(item => item.Value.HornsSize == hornsSize));
                    List<KeyValuePair<string, string>> listhornsSizeFilt = new List<KeyValuePair<string, string>>();
                    foreach (var item in hornsSizeFilter)
                    {
                        listhornsSizeFilt.Add(new KeyValuePair<string, string>(item.Key, item.Value.ToString()));
                    }
                    return listhornsSizeFilt;
                case "wingspan":
                    int wingspan = int.Parse(value);
                    var wingspanFilter = (
                    hashTable
                        .Where(item => item.Value is Bird)
                        .Select(item => new KeyValuePair<string, Bird>(item.Key, (Bird)item.Value))
                        .Where(item => item.Value.Wingspan == wingspan));
                    List<KeyValuePair<string, string>> listwingspanFilt = new List<KeyValuePair<string, string>>();
                    foreach (var item in wingspanFilter)
                    {
                        listwingspanFilt.Add(new KeyValuePair<string, string>(item.Key, item.Value.ToString()));
                    }
                    return listwingspanFilt;
                case "flightRange":
                    int flightRange = int.Parse(value);
                    var flightRangeFilter = (
                    hashTable
                        .Where(item => item.Value is Bird)
                        .Select(item => new KeyValuePair<string, Bird>(item.Key, (Bird)item.Value))
                        .Where(item => item.Value.FlightRange == flightRange));
                    List<KeyValuePair<string, string>> listflightRangeFilt = new List<KeyValuePair<string, string>>();
                    foreach (var item in flightRangeFilter)
                    {
                        listflightRangeFilt.Add(new KeyValuePair<string, string>(item.Key, item.Value.ToString()));
                    }
                    return listflightRangeFilt;
            }
            return null;
        }
        public static List<KeyValuePair<string, string>> SortBy(string type) 
        {
            List<KeyValuePair<string, string>> result = new List<KeyValuePair<string, string>>();
            var temp = (hashTable.Order(item => item.Value.Weight));
            switch (type) 
            {
                case "Weight":
                    temp = (hashTable.Order(item => item.Value.Weight));
                    foreach (var item in temp)
                    {
                        result.Add(new KeyValuePair<string, string>(item.Key, item.Value.ToString()));
                    }
                    return result;
                case "Height":
                    temp = (hashTable.Order(item => item.Value.Height));
                    foreach (var item in temp)
                    {
                        result.Add(new KeyValuePair<string, string>(item.Key, item.Value.ToString()));
                    }
                    return result;
                case "Age":
                    temp = (hashTable.Order(item => item.Value.Age));
                    foreach (var item in temp)
                    {
                        result.Add(new KeyValuePair<string, string>(item.Key, item.Value.ToString()));
                    }
                    return result;
                case "Name":
                    temp = (hashTable.Order(item => item.Value.Name));
                    foreach (var item in temp)
                    {
                        result.Add(new KeyValuePair<string, string>(item.Key, item.Value.ToString()));
                    }
                    return result;
                case "Specie":
                    var combined = hashTable
                    .Where(item => item.Value is Mammal || item.Value is Artiodactyl || item.Value is Bird)
                    .Select(item => new
                    {
                        Key = item.Key,
                        Value = (dynamic)item.Value,  // dynamic позволяет обратиться к Specie
                        Type = item.Value.GetType()   // Сохраняем тип для проверки
                    })
                    .OrderBy(item => item.Value.Specie);       // Сортировка по Specie
                    foreach (var item in combined)
                    {
                        result.Add(new KeyValuePair<string, string>(item.Key, item.Value.ToString()));
                    }
                    return result;
                case "Location":
                    var locationSort = (
                    hashTable
                        .Where(item => item.Value is Mammal)
                        .Select(item => new KeyValuePair<string, Mammal>(item.Key, (Mammal)item.Value))
                        .OrderBy(item => item.Value.Location));
                    foreach (var item in locationSort)
                    {
                        result.Add(new KeyValuePair<string, string>(item.Key, item.Value.ToString()));
                    }
                    return result;
                case "Living environment":
                    var livingEnSort = (
                    hashTable
                        .Where(item => item.Value is Mammal)
                        .Select(item => new KeyValuePair<string, Mammal>(item.Key, (Mammal)item.Value))
                        .OrderBy(item => item.Value.LivingEnvironment));
                    foreach (var item in livingEnSort)
                    {
                        result.Add(new KeyValuePair<string, string>(item.Key, item.Value.ToString()));
                    }
                    return result;
                case "Life style":
                  
                    var lifeStyleSort = (
                    hashTable
                        .Where(item => item.Value is Mammal)
                        .Select(item => new KeyValuePair<string, Mammal>(item.Key, (Mammal)item.Value))
                        .OrderBy(item => item.Value.Lifestyle));
                    foreach (var item in lifeStyleSort)
                    {
                        result.Add(new KeyValuePair<string, string>(item.Key, item.Value.ToString()));
                    }
                    return result;
                case "hoofSize":
                    var hoofSizeSort = (
                    hashTable
                        .Where(item => item.Value is Artiodactyl)
                        .Select(item => new KeyValuePair<string, Artiodactyl>(item.Key, (Artiodactyl)item.Value))
                        .OrderBy(item => item.Value.HoofSize));
                    foreach (var item in hoofSizeSort)
                    {
                        result.Add(new KeyValuePair<string, string>(item.Key, item.Value.ToString()));
                    }
                    return result;
                case "hornsSize":
                    var hornsSizeSort = (
                    hashTable
                        .Where(item => item.Value is Artiodactyl)
                        .Select(item => new KeyValuePair<string, Artiodactyl>(item.Key, (Artiodactyl)item.Value))
                        .OrderBy(item => item.Value.HornsSize));
                    foreach (var item in hornsSizeSort)
                    {
                        result.Add(new KeyValuePair<string, string>(item.Key, item.Value.ToString()));
                    }
                    return result;
                case "wingspan":
                    var wingspanSort = (
                    hashTable
                        .Where(item => item.Value is Bird)
                        .Select(item => new KeyValuePair<string, Bird>(item.Key, (Bird)item.Value))
                        .OrderBy(item => item.Value.Wingspan));
                    foreach (var item in wingspanSort)
                    {
                        result.Add(new KeyValuePair<string, string>(item.Key, item.Value.ToString()));
                    }
                    return result;
                case "flightRange":
                    var flightRangeSort = (
                    hashTable
                        .Where(item => item.Value is Bird)
                        .Select(item => new KeyValuePair<string, Bird>(item.Key, (Bird)item.Value))
                        .OrderBy(item => item.Value.FlightRange));
                    foreach (var item in flightRangeSort)
                    {
                        result.Add(new KeyValuePair<string, string>(item.Key, item.Value.ToString()));
                    }
                    return result;
            }
            return null;
        }

        public static List<KeyValuePair<string, string>> Query(string key) 
        {
            int i = 0;
            foreach(var item in hashTable) 
            {
                if (item.Key != null)
                { 
                    i++; 
                }
            }
            if (i == 0)
                return new List<KeyValuePair<string, string>>();
            switch (key) 
            {
                case "AverageWeight":
                    return QuerryAverageWeight();
                case "MaxAge":
                    return QuerryMaxAge();
                case "FoodSupply":
                    return QuerryFoodSupply();
            }
            return new List<KeyValuePair<string, string>>();
        }

        private static List<KeyValuePair<string, string>> QuerryAverageWeight() 
        {
            List<KeyValuePair<string, string>> result = new List<KeyValuePair<string, string>>();
            var querry = (
                    hashTable
                        .MyAggregate(item => item.Value.Weight, (a, b) => a + b, true));
            result.Add(new KeyValuePair<string, string>("Средний вес", querry.ToString()));
            return result;
        }

        private static List<KeyValuePair<string, string>> QuerryMaxAge()
        {
            List<KeyValuePair<string, string>> result = new List<KeyValuePair<string, string>>();
            var querry = (
                    hashTable
                        .MyAggregate(item => item.Value.Age, (a, b) => (a > b) ? a : b));
            result.Add(new KeyValuePair<string, string>("Максимальный возраст:", querry.ToString()));
            foreach(var item in hashTable) 
            {
                if(item.Value.Age == querry) 
                {
                    result.Add(new KeyValuePair<string, string>(item.Key.ToString(), item.Value.ToString()));
                }
            }            
            return result;
        }

        private static List<KeyValuePair<string, string>> QuerryFoodSupply()
        {
            List<KeyValuePair<string, string>> result = new List<KeyValuePair<string, string>>();
            var querry = (
                    hashTable
                        .Select(animalQ => new
                        {
                            animalQ,
                            averageFoodKG = animalQ.Value.Weight * 0.105
                        }));
            result.Add(new KeyValuePair<string, string>("Нормы питания:", "Вес * 0.105"));
            foreach (var item in querry)
            {                
                result.Add(new KeyValuePair<string, string>(item.animalQ.Key.ToString(), item.animalQ.Value.ToString() /*+ item.averageFoodKG.ToString()*/));
                result.Add(new KeyValuePair<string, string>(item.animalQ.Key.ToString(), item.averageFoodKG.ToString()));
            }
            return result;
        }

        //flightRange
        //public static string GetJournalPath()
        //{
        //    if (File.Exists(filePathJournal))
        //    {
        //        JournalSave(filePathJournal);
        //        return /*File.ReadAllText(*/filePathJournal/*)*/;
        //    }
        //    else
        //        return "Журнал операций:\n" + allEventZoo.ToString();
        //}

        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //Сериализация
        //бинарная
        //using System.IO;
        //using System.Runtime.Serialization.Formatters.Binary;
        private static void JournalSave(string journalPath) 
        {
            //collectionPathList[1]/*filePathJournal*/ = journalPath;
            // 3. Сериализуем журнал отдельно
            //if (!File.Exists(journalPath))
            //{
            //    File.WriteAllText(journalPath, "Журнал событий:\n"); //Перезаписываеем или осздаем новый
            //}
            if (collectionPathList == null)
                File.AppendAllText(journalPath, allEventZoo.ToString());
            else
            {
                if (journalPath == collectionPathList[1])
                    File.AppendAllText(journalPath, allEventZoo.ToString()); //Добавляем в конец ил новый создаем
                else
                    File.AppendAllText(journalPath, (File.ReadAllText(collectionPathList[1])) + allEventZoo.ToString());
                allEventZoo = new Journal<Animal>();
            }
            //JournalLink();

            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //теперь если вывести хоятт- смотрим, существует ли файл, если да - записсываем и выводим из фалйа, нет - просто выводим
        }

        public static bool QuikSave() 
        {
            if (collectionPathList == null)
                return false;
            FileSave(collectionPathList);
            return true;
        }

        public static void SerializeToBinary<T>(T obj, List<string> pathList)
        {

            //hashTable.CollectionCountChanged -= null;
            //ЖУРНАЛ ПЕРЕД СЕРИАЛИЗАЦИЕЙ ОТВЯЗЫВАЕТСЯ, ПОТОМ НУЖНО ПРИВЯЗАТЬ БУДЕТ, ПОТОМУ ЧТО ДЕЛЕГАТЫ И ИВЕНТЫ - НЕ СЕРИАЛИЗУЕМЫЕ ОБЪЕКТЫ, ИХ МОЖНО ЗАМЕНИТЬ НА СЕРИАЛИЗУЕМЫЕ КЛАССЫ
            //var formatter = new BinaryFormatter();
            //using (var stream = File.Create("data.bin"))
            //{
            //    formatter.Serialize(stream, hashTable);
            //}

            using (FileStream fs = new FileStream(pathList[0], FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, obj);
            }
            JournalSave(pathList[1]);
            collectionPathList = pathList;
            


            //// 3. Сериализуем журнал отдельно
            //using (FileStream fs = new FileStream("journal.txt", FileMode.Create))
            //{
            //    BinaryFormatter formatter = new BinaryFormatter();
            //    formatter.Serialize(fs, journal);
            //}

            //// 4. Подписываем журнал обратно (если коллекция продолжит работу)
            //journal.SubscribeToEvents(hashTable);
        }

        public static async Task DeserializeFromBinary(List<string> filePath)
        {
            hashTable =  (await DeserializeFromBinaryAsync<MyNewCollection<string, Animal>>(filePath[0]));
            collectionPathList = filePath;
            JournalLink();
            //if (File.Exists(filePath[1]))
            //    filePathJournal = filePath[1];
            //JournalLink();
        }
        private static async Task<T> DeserializeFromBinaryAsync<T>(string filePath)
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
        //как эотот метод сделать асинхронным правильно
        //private static async T DeserializeFromBinary<T>(string filePath)
        //{
        //    using (FileStream fs = new FileStream(filePath, FileMode.Open))
        //    {
        //        BinaryFormatter formatter = new BinaryFormatter();
        //        return (T)formatter.Deserialize(fs);
        //    }



        //    // Восстанавливаем подписки на события
        //    //loadedTable.ItemAdded += (key, value) => Console.WriteLine($"Added: {key}");
        //    //loadedTable.ItemRemoved += key => Console.WriteLine($"Removed: {key}");
        //}



        //хмл

        public static async void SerializeToXml(List<string> pathList)
        {
            //SerializeXML.SerializeToXml(hashTable, pathList[0]);
            var serializer = new XmlSerializer(
            typeof(MyNewCollection<string, Animal>),
            new[] { typeof(Bird), typeof(Mammal), typeof(Artiodactyl) } // Все возможные типы
            );

            var ns = new XmlSerializerNamespaces();
            ns.Add("", ""); // Отключаем стандартные пространства имен
            await UniversalXmlSerializer.SerializeAsync(hashTable, pathList[0], serializer);
            //filePathCollection = pathList[0];
            //collectionExtension = pathList[3];
            JournalSave(pathList[1]);
            collectionPathList = pathList;
            
        }
        //*********
        public static async Task DeserializeFromXml(List<string> pathList)
        {
            //hashTable = SerializeXML.DeserializeFromXml<MyNewCollection<string, Animal>>(filePath);
            var serializer = new XmlSerializer(
                typeof(MyNewCollection<string, Animal>),
                new[] { typeof(Bird), typeof(Mammal), typeof(Artiodactyl) }
                );

            var ns = new XmlSerializerNamespaces();
            ns.Add("", ""); // Глобальное отключение пространств имён - чисто для красоты
            hashTable = ( await UniversalXmlSerializer.DeserializeAsync<MyNewCollection<string, Animal>>(pathList[0], serializer));
            collectionPathList = pathList;
            JournalLink();
        }

        private static async void SerializeToJs(List<string> pathList) 
        {
            await Serialisation.UniversalJsSerializer<string, Animal>.SerializeAsync(hashTable, pathList[0]);

            //filePathCollection = pathList[0];
            //collectionExtension = pathList[3];
            JournalSave(pathList[1]);
            collectionPathList = pathList;            
        }
        //************нужно в параметры список патчей передаввать чтобы востановить все при первой выписи
        public static async Task DeserializeFromJs(List<string> pathList/*string filePath*/) 
        {
            hashTable = await Serialisation.UniversalJsSerializer<string, Animal>.DeserializeAsync<MyNewCollection<string, Animal>>(pathList[0]);
            collectionPathList = pathList;
            JournalLink();
        }
        //using System.Xml.Serialization;

        //public static void SerializeToXml<T>(T obj, string filePath)
        //    {
        //        XmlSerializer serializer = new XmlSerializer(typeof(T));
        //        using (TextWriter writer = new StreamWriter(filePath))
        //        {
        //            serializer.Serialize(writer, obj);
        //        }
        //    }

        //public static T DeserializeFromXml<T>(string filePath)
        //{
        //    XmlSerializer serializer = new XmlSerializer(typeof(T));
        //    using (TextReader reader = new StreamReader(filePath))
        //    {
        //        return (T)serializer.Deserialize(reader);
        //    }
        //}

        //джейсон
        //using System.Text.Json;
        //public static void SerializeToJson<T>(T obj, string filePath)
        //{
        //    string json = JsonSerializer.Serialize(obj);
        //    File.WriteAllText(filePath, json);
        //}

        //public static T DeserializeFromJson<T>(string filePath)
        //{
        //    string json = File.ReadAllText(filePath);
        //    return JsonSerializer.Deserialize<T>(json);
        //}

        //пример ипользования
        //var hashTable = new CustomHashTable<string, Animal>();
        //hashTable.Add("Lion", new Mammal { Name = "Lion", Age = 5, HasFur = true });
        //hashTable.Add("Cow", new Artiodactyl { Name = "Cow", Age = 3, HasFur = true, HoofCount = 4 });
        //hashTable.Add("Eagle", new Bird { Name = "Eagle", Age = 2, CanFly = true });

        //// Бинарная сериализация
        //SerializeToBinary(hashTable, "animals.bin");
        //var fromBinary = DeserializeFromBinary<CustomHashTable<string, Animal>>("animals.bin");

        //// XML
        //SerializeToXml(hashTable, "animals.xml");
        //var fromXml = DeserializeFromXml<CustomHashTable<string, Animal>>("animals.xml");

        //// JSON
        //SerializeToJson(hashTable, "animals.json");
        //var fromJson = DeserializeFromJson<CustomHashTable<string, Animal>>("animals.json");
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    }
}
