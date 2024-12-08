using System;
using System.Collections.Generic;

class Program
{
    public static int ReadElem()
    {
        int n;
        bool isCorrect = true;
        do
        {
            isCorrect = int.TryParse(Console.ReadLine(), out n);
            if (!isCorrect || n < 0 || n > 5)
            {
                Console.WriteLine("Неверные данные, повторите попытку ввода");
                isCorrect = false;
            }
        }
        while (!isCorrect);
        return n;
    }

    static bool[,] GenerateTruthTable(int n, bool[] values)
    {
        int rows = (int)Math.Pow(2, n); // Количество строк в таблице истинности
        bool[,] table = new bool[rows, n + 1]; // Создаем двумерный массив

        for (int i = 0; i < rows; i++)
        {
            string binary = Convert.ToString(i, 2).PadLeft(n, '0'); // Преобразование в двоичный формат
            for (int j = 0; j < n; j++)
            {
                table[i, j] = binary[j] == '1'; // Заполнение столбцов значениями переменных
            }
            table[i, n] = values[i]; // Заполнение последнего столбца результатом функции
        }

        return table;
    }
    static Random random = new Random();
    static bool[] FillResult(int n)
    {
        bool[] values = new bool[(int)Math.Pow(2, n)];
        Console.WriteLine("Введите результаты функции для каждого набора данных (0 или 1):");
        for (int i = 0; i < values.Length; i++)
        {
            Console.Write($"{Convert.ToString(i, 2).PadLeft(n, '0')}: ");
            values[i] = ReadElem() == 1;
        }
        return values;
    }
    static bool[] FillRandom(int n) {
        bool[] values = new bool[(int)Math.Pow(2, n)];
        for (int i = 0; i < values.Length; i++)
        {
            values[i] = random.Next(2) == 1;
        }
        return values;
    }
    static string GetSDNF(bool[,] table, int n)
    {
        string[] variables = { "x", "y", "z", "i", "j" };
        List<string> terms = new List<string>();

        for (int i = 0; i < table.GetLength(0); i++)
        {
            if (table[i, n])
            {
                string term = "";
                for (int j = 0; j < n; j++)
                {
                    if (table[i, j])
                    {
                        term += "." + variables[j];
                    }
                    else
                    {
                        term += "!" + variables[j];
                    }
                }
                terms.Add(term);
            }
        }

        return string.Join(" v ", terms);
    }

    static string GetSKNF(bool[,] table, int n)
    {
        string[] variables = { "x", "y", "z", "i", "j" };
        List<string> terms = new List<string>();

        for (int i = 0; i < table.GetLength(0); i++)
        {
            if (!table[i, n])
            {
                string term = "(";
                for (int j = 0; j < n; j++)
                {
                    if (!table[i, j])
                    {
                        term += variables[j];
                    }
                    else
                    {
                        term += "!" + variables[j];
                    }

                    if (j < n - 1)
                    {
                        term += " v ";
                    }
                }
                term += ")";
                terms.Add(term);
            }
        }
        return string.Join(" & ", terms);
    }

    static List<string> GetCombinedImplicants(string sdnf, int variableCount)
    {
        string[] initialImplicants = sdnf.Split(new string[] { " v " }, StringSplitOptions.RemoveEmptyEntries);
        List<string> currentImplicants = new List<string>(initialImplicants);
        bool changesMade;

        do
        {
            changesMade = false;
            List<string> nextImplicants = new List<string>();
            HashSet<string> alreadyCombined = new HashSet<string>();
            bool[] used = new bool[currentImplicants.Count];

            for (int i = 0; i < currentImplicants.Count; i++)
            {
                for (int j = i + 1; j < currentImplicants.Count; j++)
                {
                    string combined = CombineImplicants(currentImplicants[i], currentImplicants[j]);
                    if (combined != null && !alreadyCombined.Contains(combined))
                    {
                        nextImplicants.Add(combined);
                        alreadyCombined.Add(combined);
                        used[i] = true;
                        used[j] = true;
                        changesMade = true;
                    }
                }
            }

            // Добавляем необъединённые импликанты в следующий список
            for (int i = 0; i < currentImplicants.Count; i++)
            {
                if (!used[i] && !nextImplicants.Contains(currentImplicants[i]))
                {
                    nextImplicants.Add(currentImplicants[i]);
                }
            }

            // Переходим к следующему набору импликант
            currentImplicants = nextImplicants;
        }
        while (changesMade); // Продолжаем, пока происходят изменения

        return currentImplicants.Distinct().ToList();
    }






    static string GetMDNF(List<string> combinedImplicants, string[] initialImplicants)
    {
        int rows = initialImplicants.Length;
        int cols = combinedImplicants.Count;
        bool[,] coverageTable = new bool[cols, rows];

        // Создание таблицы покрытий
        for (int i = 0; i < cols; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                coverageTable[i, j] = CheckCoverage(combinedImplicants[i], initialImplicants[j]);
            }
        }


        HashSet<int> selectedIndices = new HashSet<int>();
        HashSet<int> coveredRows = new HashSet<int>();

        while (coveredRows.Count < rows)
        {
            int bestImplicant = -1;
            int maxCoverage = 0;

            for (int i = 0; i < cols; i++)
            {
                if (selectedIndices.Contains(i)) continue;

                int coverageCount = 0;
                for (int j = 0; j < rows; j++)
                {
                    if (!coveredRows.Contains(j) && coverageTable[i, j])
                    {
                        coverageCount++;
                    }
                }

                if (coverageCount > maxCoverage)
                {
                    maxCoverage = coverageCount;
                    bestImplicant = i;
                }
            }

            if (bestImplicant == -1) break; // Если импликант больше не находится, выходим

            selectedIndices.Add(bestImplicant);
            for (int j = 0; j < rows; j++)
            {
                if (coverageTable[bestImplicant, j])
                {
                    coveredRows.Add(j);
                }
            }
        }

        // Формирование МДНФ
        List<string> finalImplicants = new List<string>();
        foreach (int index in selectedIndices)
        {
            finalImplicants.Add(combinedImplicants[index]);
        }

        return string.Join(" v ", finalImplicants);
    }



    static bool CheckCoverage(string combined, string full)
    {
        int variableCount = 0; // Общее количество переменных в склеенном импликанте
        int matchingCount = 0; // Количество совпадающих переменных

        string[] variables = { "x", "y", "z", "i", "j" };

        // Подсчитываем количество переменных в склеенном импликанте
        foreach (var variable in variables)
        {
            if (combined.Contains(variable))
            {
                variableCount++;
            }
        }

        int length = full.Length / 2;

        for (int i = 0; i < length; i++)
        {
            string var1 = combined.Substring(i * 2, 2);
            string var2 = full.Substring(i * 2, 2);

            if (var1 == var2)
            {
                matchingCount += 1;
            }
        }

        return matchingCount == variableCount; 
    }

    static string CombineImplicants(string imp1, string imp2)
    {
        int length = imp1.Length / 2; // Количество переменных в импликанте
        int diffCount = 0; // Количество различий
        string combinedPart = "";

        for (int i = 0; i < length; i++)
        {
            string var1 = imp1.Substring(i * 2, 2);
            string var2 = imp2.Substring(i * 2, 2);

            if (var1 == var2)
            {
                
                combinedPart += var1;
            }
            else if ((var1 == ".." && var2 != "..") || (var2 == ".." && var1 != ".."))
            {
                // Если одна переменная уже является "любой", объединение невозможно
                return null;
            }
            else if (var1[1] == var2[1] && ((var1[0] == '!' && var2[0] != '!') || (var1[0] != '!' && var2[0] == '!')))
            {
                // Переменные различаются только знаком
                combinedPart += "..";
                diffCount++;
            }
            else
            {
                // Переменные различаются по сути, объединение невозможно
                return null;
            }
        }

        // Объединение возможно только если различие ровно одно
        return diffCount == 1 ? combinedPart : null;
    }

    

    static void Main()
    {
        bool isFinal = false;
        while (!isFinal) {
            Console.Write("Введите количество переменных (n<=5): ");
            int n = ReadElem();
            Console.WriteLine("Выберите метод для заполнения таблицы. 1- Ручной, 2 - Автомат");
            int choice = ReadElem();
            
            bool[] values = [];
            switch (choice)
            {
                case 1: values = FillResult(n);
                    break;
                case 2: values = FillRandom(n);
                    break ;
                default:
                    Console.WriteLine("Повторите ввод");
                    break;
            }


            bool[,] table = GenerateTruthTable(n, values);

            ShowTable(table);
            string sdnf = GetSDNF(table, n);
            string sknf = GetSKNF(table, n);
            string output = sdnf.Replace(".", "");
            Console.WriteLine("СДНФ: " + output);
            Console.WriteLine("СКНФ: " + sknf);

            // Получение склеенных импликант
            List<string> combinedImplicants = GetCombinedImplicants(sdnf, n);

            // Получение и вывод МДНФ
            string mdnf = GetMDNF(combinedImplicants, sdnf.Split(new string[] { " v " }, StringSplitOptions.RemoveEmptyEntries));
            output = mdnf.Replace(".", "");
            Console.WriteLine("МДНФ: " + output);
            Console.WriteLine("Хотите ли продолжить, любая цифра кроме 1 - нет ");
            choice = ReadElem();
            if (choice != 1) { isFinal = true; }
        }
        

        // Показать таблицу покрытий
        //ShowCoverageTable(combinedImplicants, sdnf.Split(new string[] { " v " }, StringSplitOptions.RemoveEmptyEntries));
    }

    static void ShowTable(bool[,] table)
    {
        Console.WriteLine("Таблица истинности:");
        for (int i = 0; i < table.GetLength(0); i++)
        {
            for (int j = 0; j < table.GetLength(1); j++)
            {
                Console.Write((table[i, j] ? 1 : 0) + " ");
            }
            Console.WriteLine();
        }
    }

    static void ShowCoverageTable(List<string> combinedImplicants, string[] initialImplicants)
    {
        Console.WriteLine("\nТаблица покрытий:");
        Console.Write("Импликанта\t");

        foreach (var imp in initialImplicants)
        {
            Console.Write(imp + "\t");
        }
        Console.WriteLine();

        foreach (var imp in combinedImplicants)
        {
            Console.Write(imp + "\t");
            foreach (var innerImp in initialImplicants)
            {
                Console.Write((CheckCoverage(imp, innerImp) ? "+" : "-") + "\t");
            }
            Console.WriteLine();
        }
    }
}
