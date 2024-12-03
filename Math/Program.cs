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
            if (!isCorrect || n < 0)
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

    static string GetMDNF(string sdnf)
    {
        string[] implicants = sdnf.Split(new string[] { " v " }, StringSplitOptions.RemoveEmptyEntries);
        HashSet<string> checkedImplicants = new HashSet<string>();
        List<string> resultImplicants = new List<string>();

        foreach (var imp in implicants)
        {
            bool canBeCombined = false;

            foreach (var otherImp in implicants)
            {
                if (imp != otherImp && !checkedImplicants.Contains(otherImp))
                {
                    string combinedTerm = CombineImplicants(imp, otherImp);
                    if (combinedTerm != null)
                    {
                        resultImplicants.Add(combinedTerm);
                        checkedImplicants.Add(imp);
                        checkedImplicants.Add(otherImp);
                        canBeCombined = true;
                    }
                }
            }

            if (!canBeCombined && !checkedImplicants.Contains(imp))
            {
                resultImplicants.Add(imp);
            }
        }

        // Убираем дубликаты
        HashSet<string> uniqueImplicants = new HashSet<string>(resultImplicants);

        return string.Join(" v ", uniqueImplicants);
    }

    static string CombineImplicants(string imp1, string imp2)
    {
        int length = imp1.Length / 2;
        int diffCount = 0;
        string combinedPart = "";

        for (int i = 0; i < length; i++)
        {
            string var1 = imp1.Substring(i * 2, 2);
            string var2 = imp2.Substring(i * 2, 2);

            if (var1 == var2)
            {
                combinedPart += var1;
            }
            else if (var1.Substring(1) == var2.Substring(1) &&
                     ((var1[0] == '!' && var2[0] != '!') || (var1[0] != '!' && var2[0] == '!')))
            {
                diffCount++;
            }
            else
            {
                return null;
            }
        }

        return diffCount == 1 ? combinedPart : null;
    }

    static void Main()
    {
        Console.Write("Введите количество переменных (n<=5): ");
        int n = ReadElem();

        bool[] values = FillResult(n);

        bool[,] table = GenerateTruthTable(n, values);

        Console.WriteLine("Таблица истинности:");
        for (int i = 0; i < table.GetLength(0); i++)
        {
            for (int j = 0; j < table.GetLength(1); j++)
            {
                Console.Write((table[i, j] ? 1 : 0) + " ");
            }
            Console.WriteLine();
        }

        string sdnf = GetSDNF(table, n);
        string sknf = GetSKNF(table, n);
        string sdnfConsole = sdnf.Replace(".", "");
        Console.WriteLine("СДНФ: " + sdnf);
        Console.WriteLine("СКНФ: " + sknf);

        // Получение и вывод МДНФ
        string mdnf = GetMDNF(sdnf);
        Console.WriteLine("МДНФ: " + mdnf);
    }
}
