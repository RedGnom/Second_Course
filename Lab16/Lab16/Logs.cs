using Lab13;
using System;
using System.IO;

namespace Lab16
{
    public class FileJournal
    {
        private string filePath;

        // Конструктор, принимающий путь к файлу журнала
        public FileJournal(string filePath)
        {
            this.filePath = filePath;

            // Если файла нет, создаем его
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
        }

        // Метод для записи записи в файл
        public void WriteRecord(object source, TreeEventHandlerArgs args)
        {
            // Форматируем строку для записи
            string record = $"Коллекция: {args.CollectionName}, Изменение: {args.ChangeType}, Предмет: {args.ChangedItem?.ToString()}";

            // Записываем строку в файл
            using (StreamWriter writer = new StreamWriter(filePath, true)) // true - добавление в конец файла
            {
                writer.WriteLine(record);
            }
        }

        
    }
}