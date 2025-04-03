using LAB10_lib;
using Lab13;
using System;
using System.Collections.Generic;
using System.IO;
#pragma warning disable SYSLIB0011
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Lab16
{
    [Serializable]
    public class TreeManager
    {
        private FileJournal logs;
        public TreeEvent<Place> tree { get; set; } // Свойство для доступа к коллекции

        public TreeManager()
        {
            logs = new FileJournal("E:\\C#\\Second_Course\\Lab16\\Lab16\\Logs.txt");
            tree = new TreeEvent<Place>("Бинарное дерево поиска");

            tree.TreeCountChanged += logs.WriteRecord;
            tree.TreeReferenceChanged += logs.WriteRecord;
        }

        
        public void FillCollection(int count)
        {
            if (count <= 0)
            {
                throw new ArgumentException("Количество элементов должно быть больше нуля.");
            }

            for (int i = 0; i < count; i++)
            {
                var elem = new City();
                elem.RandomInit();
                try
                {
                    tree.Add(elem);
                }
                catch
                {
                    i--; // Повторяем попытку, если возникла ошибка
                }
            }
        }

       
        public void SaveCollectionToFile(string filePath, string format)
        {
            try
            {
                switch (format.ToLower())
                {
                    case "json":
                        // Сохранение в JSON
                        var options = new JsonSerializerOptions
                        {
                            WriteIndented = true,
                            IncludeFields = true, // если у вас есть поля
                            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                        };
                        string jsonData = JsonSerializer.Serialize(tree.ToList(), options);
                        File.WriteAllText(filePath, jsonData);
                        break;

                    case "xml":
                        var list = tree.ToList();
                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Place>), new Type[] { typeof(City) });
                        using (StreamWriter writer = new StreamWriter(filePath))
                        {
                            xmlSerializer.Serialize(writer, list);
                        }
                        break;

                    case "binary":
                        // Сохранение в бинарный формат
                        using (FileStream stream = new FileStream(filePath, FileMode.Create))
                        {
                            BinaryFormatter formatter = new BinaryFormatter();
                            formatter.Serialize(stream, tree.ToList());
                        }
                        break;

                    default:
                        throw new ArgumentException("Неподдерживаемый формат файла.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при сохранении коллекции: {ex.Message}", ex);
            }
        }

        public void LoadCollectionFromFile(string filePath, string format)
        {
            try
            {
                List<Place> loadedCollection;

                switch (format.ToLower())
                {
                    case "json":
                        string jsonData = File.ReadAllText(filePath);
                        var options = new JsonSerializerOptions
                        {
                            IncludeFields = true // если у вас есть поля
                        };
                        loadedCollection = JsonSerializer.Deserialize<List<Place>>(jsonData, options);
                        break;

                    case "xml":
                        // Загрузка из XML
                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Place>), new Type[] { typeof(City) });
                        using (StreamReader reader = new StreamReader(filePath))
                        {
                            loadedCollection = (List<Place>)xmlSerializer.Deserialize(reader);
                        }
                        break;

                    case "binary":
                        // Загрузка из бинарного формата
                        using (FileStream stream = new FileStream(filePath, FileMode.Open))
                        {
                            var formatter = new BinaryFormatter();
                            loadedCollection = (List<Place>)formatter.Deserialize(stream);
                        }
                        break;

                    default:
                        throw new ArgumentException("Неподдерживаемый формат файла.");
                }

                if (loadedCollection == null || !loadedCollection.Any())
                {
                    throw new Exception("Файл не содержит данных о требуемых объектах.");
                }

                // Очищаем текущую коллекцию и добавляем загруженные элементы
                tree.Clear();
                foreach (var item in loadedCollection)
                {
                    tree.Add(item);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при загрузке коллекции: {ex.Message}", ex);
            }
        }
    }
}