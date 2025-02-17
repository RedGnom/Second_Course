using System.Drawing;
using System.Numerics;

namespace Lab3_math
{
    internal class Program
    {
        private static Random random = new Random();
        static Dictionary<int, char> dict = new Dictionary<int, char>();
        static void ShowMatrix(int[,] arr, Dictionary<int, char> dict)
        {
            NormalizeMatrix(arr);
            // Выводим буквы над матрицей
            Console.Write("  "); 
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                if (dict.ContainsKey(j))
                {
                    Console.Write(dict[j] + " ");
                }
            }
            Console.WriteLine();

            // Выводим буквы слева от матрицы и саму матрицу
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                if (dict.ContainsKey(i))
                {
                    Console.Write(dict[i] + " ");  
                }
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n");
        }
        static void NormalizeMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++) 
            {
                for (int j = 0; j < matrix.GetLength(1); j++)  
                {
                    if (matrix[i, j] > 1)
                    {
                        matrix[i, j] = 1;
                    }
                }
            }
        }

        static void ZeroMatrix(int[,] arr) {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                arr[i, i] = 1;
            }
        }
        static void FillMatrix(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i,j] = random.Next(2);
                }
            }
        }
        static int[,] MatrixMultiplie(int[,] first, int[,] second)
        {
            if (first.GetLength(1) != second.GetLength(0))
            {
                throw new ArgumentException("Число столбцов первой матрицы должно быть равно числу строк второй матрицы");
            }
            int[,] res = new int[first.GetLength(0), first.GetLength(1)];

            for (int i = 0; i < first.GetLength(0); i++)
            {
                for (int j = 0; j < first.GetLength(1); j++)
                {
                    res[i, j] = 0;
                    for (int k = 0; k < first.GetLength(1); k++)
                    {
                        res[i, j] += first[i, k] * second[k, j];
                    }
                }
            }

            return res;
        }
        static int[,] MatrixSum(int[,] first, int[,] second)
        {
            int[,] res = new int[first.GetLength(0), first.GetLength(1)];
            for (int i = 0; i < first.GetLength(0); i++)
            {
                for (int j = 0; j < first.GetLength(1); j++)
                {
                    res[i,j] = first[i,j]+second[i,j];
                }
            }
            return res;
        }
        static int[,] ReachMatrix(int[,] sum, int[,] matrix, int[,] current, Dictionary<int, char> dict)
        {
            ZeroMatrix(sum);
            sum = MatrixSum(sum, matrix);
            Console.WriteLine("Первая матрица");
            ShowMatrix(sum, dict);

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                current = MatrixMultiplie(current, matrix);
                sum = MatrixSum(current, sum);
                Console.WriteLine($"Матрица номер {i+2} ");
                ShowMatrix(sum, dict);
            }
            return sum;
        }
        static void FillDict(Dictionary<int, char> dict)
        {
            char[] values = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j' };
            for (int i = 0; i < values.Length; i++)
            {
                dict[i] = values[i];
            }
        }
        static int[,] ElementMultiply(int[,] r, int[,] strongMatrix)
        {
            NormalizeMatrix(strongMatrix);
            NormalizeMatrix(r);
            for (int i = 0; i < r.GetLength(0); i++)
            {
                for (int j = 0; j < r.GetLength(1); j++)
                {
                    strongMatrix[i,j] = strongMatrix[i, j]*r[i,j];
                }
            }

            return strongMatrix;
        }
        static int[,] StrongMatrix(int[,] r)
        {
            int rows = r.GetLength(0);
            int cols = r.GetLength(1);
            int[,] strongMatrix = new int[cols, rows];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    strongMatrix[j, i] = r[i, j];
                }
            }
            strongMatrix = ElementMultiply(r, strongMatrix);


            return strongMatrix;
        }
        static List<List<char>> GetVertex(int[,] strongMatrix, List<List<char>> result, Dictionary<int,char> dict)
        {
            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < strongMatrix.GetLength(0); i++)
            {
                if (set.Contains(i))
                {
                    continue;
                }
                List<char> step = new List<char>();
                for (int j = 0; j < strongMatrix.GetLength(0); j++)
                {
                    if (!set.Contains(j) && strongMatrix[i, j] != 0)
                    {
                        set.Add(j);
                        step.Add(dict[j]);
                    }
                    else
                    {
                        continue;
                    }
                }
                result.Add(step);
            }
            return result;
        }
        static void ShowResult(List<List<char>> result)
        {
            int count = 1;
            foreach (var symbols in result)
            {
                Console.WriteLine($"K{count++}: {string.Join(", ", symbols)}");
            }
        }
        static int[,] GetMatrix(int[,] matrix)
        {
            int countRow = 1;
            int countCol = 1;
            Console.WriteLine("Введите матрицу смежности");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.WriteLine($"Введите {countRow++} элемент, {countCol} строки ");
                    matrix[i, j] = ReadElem();
                }
                countCol++;
                countRow = 1;
            }

            return matrix;
        }
        static int ReadElem()
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

        static void Main(string[] args)
        {
            
            FillDict(dict); //Заполнение словаря с набором букв

            int[][,] matrixSet =
            [
                new int[,] { {0,1,0,0,0,}, { 0, 0, 0, 1, 0, }, { 0, 1, 0, 0, 0, }, {0,0,1,0,0,}, {1,0,1,1,0,} },
                new int[,] { {0,1,0,0,0,0}, { 1, 1, 0, 0, 0, 0}, { 0, 0, 0, 1, 0,0 }, {0,0,1,0,1,0}, { 0, 0, 0, 1, 0,0 }, { 0, 1, 1, 0, 1,1 } },
                new int[,] { {0,1,0,1,0,}, { 0, 0, 0, 0, 0, }, { 0, 1, 0, 0, 0, }, {0,0,0,0,1,}, {1,0,0,0,0,} },
                new int[,] { {0,1,0,0,0,}, { 0, 0, 1, 0, 0, }, { 0, 0, 0, 0, 1, }, {0,0,1,0,0,}, {1,0,0,1,0,} },
            ];
            int choice = 0;
            bool isFinanal = false;
            int n = 0;
            
            
            
            
            while (!isFinanal) {
                Console.WriteLine("Выберите как хотите ввести матрицу " +
                "1 - Вручную, 2 - Выбрать готовую матрицу, 3 - Выход");
                choice = ReadElem();
                int[,] matrix = null;
                int[,] current = null ;
                int[,] sum = null;
                int[,] strongMatrix = null;
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Введите размерность графа");
                        n = ReadElem();
                        matrix = new int[n, n];
                        matrix = GetMatrix(matrix);
                        current = matrix;
                        sum = new int[n, n];
                        strongMatrix = new int[n, n];
                        
                        break;
                    case 2:
                        int count = 1;
                        
                        Console.WriteLine("Выберите матрицу, исходя из ее номера");
                        foreach (var options in matrixSet) {
                            Console.WriteLine(count++);
                            ShowMatrix(options, dict);

                        }
                        int index = ReadElem();
                        if ((index - 1) < 0 || (index - 1) >= matrixSet.Length) {
                            Console.WriteLine("Выбрана несуществующая матрица");
                            continue;
                        }
                        else
                        {
                            matrix = matrixSet[index-1];
                            current = matrix;
                            sum = new int[matrix.GetLength(0), matrix.GetLength(1)];
                            strongMatrix = new int[matrix.GetLength(0), matrix.GetLength(1)];

                        }
                        break;
                    case 3:
                        isFinanal = true;
                        continue;
                    default:
                        Console.WriteLine("Повторите выбор");
                        continue;
                        
                }
                Console.WriteLine("Матрица смежности");
                ShowMatrix(matrix, dict);

                
                sum = ReachMatrix(sum, matrix, current, dict);
                Console.WriteLine("Матрица достижимости");
                ShowMatrix(sum, dict);

                strongMatrix = StrongMatrix(sum);
                Console.WriteLine("Матрица сильной связности");
                NormalizeMatrix(strongMatrix);
                ShowMatrix(strongMatrix, dict);

                List<List<char>> result = new List<List<char>>();
                GetVertex(strongMatrix, result, dict);

                ShowResult(result);

            }
            
        }
    }
}
