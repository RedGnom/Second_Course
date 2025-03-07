using LAB10_lib;
using System;
using System.Collections.Generic;

namespace Lab4Math
{
    internal class Program
    {
        private static Random random = new Random();
        static Dictionary<int, char> dict = new Dictionary<int, char>();

        static void FillDict(Dictionary<int, char> dict)
        {
            char[] values = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j' };
            for (int i = 0; i < values.Length; i++)
            {
                dict[i] = values[i];
            }
        }

        static void FillMatrix(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = random.Next(2);
                }
            }
        }

        static void ShowMatrix(int[,] arr, Dictionary<int, char> dict)
        {
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

        static void Dijkstra(int[,] graph, int start, int end)
        {
            int n = graph.GetLength(0);
            int[] dist = new int[n];
            bool[] visited = new bool[n];
            int[] prev = new int[n];

            for (int i = 0; i < n; i++)
            {
                dist[i] = int.MaxValue;
                prev[i] = -1;
            }
            dist[start] = 0;

            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = -1;
                for (int j = 0; j < n; j++)
                {
                    if (!visited[j] && (minIndex == -1 || dist[j] < dist[minIndex]))
                    {
                        minIndex = j;
                    }
                }

                if (dist[minIndex] == int.MaxValue)
                    break;

                visited[minIndex] = true;

                for (int j = 0; j < n; j++)
                {
                    if (graph[minIndex, j] > 0 && !visited[j])
                    {
                        int newDist = dist[minIndex] + graph[minIndex, j];
                        if (newDist < dist[j])
                        {
                            dist[j] = newDist;
                            prev[j] = minIndex;
                        }
                    }
                }
            }

            
            if (dist[end] == int.MaxValue)
            {
                Console.WriteLine($"Пути от {dict[start]} до {dict[end]} не существует.");
            }
            else
            {
                Console.WriteLine($"Кратчайший путь от {dict[start]} до {dict[end]}: {dist[end]}");
                Console.Write("Путь: ");
                PrintPath(prev, end);
                Console.WriteLine();
            }
        }

        static void PrintPath(int[] prev, int i)
        {
            if (prev[i] == -1)
            {
                Console.Write(dict[i]);
                return;
            }
            PrintPath(prev, prev[i]);
            Console.Write(" -> " + dict[i]);
        }
        static int GetVertexIndex(char vertex)
        {
            foreach (var pair in dict)
            {
                if (pair.Value == vertex)
                {
                    return pair.Key;
                }
            }
            return -1; // Вершина не найдена
        }

        static void Prim(int[,] graph)
        {
            int n = graph.GetLength(0); // Количество вершин
            bool[] selected = new bool[n]; // Выбранные вершины
            int[] minEdge = new int[n]; // Минимальные веса рёбер
            int[] parent = new int[n]; // Родительские вершины

            
            for (int i = 0; i < n; i++)
            {
                minEdge[i] = int.MaxValue;
                parent[i] = -1;
            }

           
            minEdge[0] = 0;

            for (int i = 0; i < n - 1; i++)
            {
                
                int minIndex = -1;
                for (int j = 0; j < n; j++)
                {
                    if (!selected[j] && (minIndex == -1 || minEdge[j] < minEdge[minIndex]))
                    {
                        minIndex = j;
                    }
                }

                
                selected[minIndex] = true;

                
                for (int j = 0; j < n; j++)
                {
                    if (graph[minIndex, j] > 0 && !selected[j] && graph[minIndex, j] < minEdge[j])
                    {
                        minEdge[j] = graph[minIndex, j];
                        parent[j] = minIndex;
                    }
                }
            }
            int weight = 0;
            // Выводим результат
            Console.WriteLine("Минимальное остовное дерево:");
            for (int i = 1; i < n; i++)
            {
                Console.WriteLine($"{dict[parent[i]]} - {dict[i]} : {graph[i, parent[i]]}");
                weight += graph[i, parent[i]];
            }
        }

        static void BronKerbosch(int[,] graph, List<int> R, List<int> P, List<int> X)
        {
            if (P.Count == 0 && X.Count == 0)
            {
                // Найдена максимальная клика
                Console.Write("Клика: ");
                foreach (var vertex in R)
                {
                    Console.Write(dict[vertex] + " ");
                }
                Console.WriteLine();
                return;
            }

            foreach (var v in new List<int>(P))
            {
                List<int> newR = new List<int>(R) { v };
                List<int> newP = new List<int>();
                List<int> newX = new List<int>();

                
                foreach (var neighbor in P)
                {
                    if (graph[v, neighbor] > 0)
                    {
                        newP.Add(neighbor);
                    }
                }
                foreach (var neighbor in X)
                {
                    if (graph[v, neighbor] > 0)
                    {
                        newX.Add(neighbor);
                    }
                }

                
                BronKerbosch(graph, newR, newP, newX);

                // Перемещаем вершину v из P в X
                P.Remove(v);
                X.Add(v);
            }
        }

        static void FindCliques(int[,] graph)
        {
            int n = graph.GetLength(0);
            List<int> R = new List<int>(); // Текущая клика
            List<int> P = new List<int>(); // Кандидаты
            List<int> X = new List<int>(); // Уже рассмотренные вершины

            // Инициализация P (все вершины графа)
            for (int i = 0; i < n; i++)
            {
                P.Add(i);
            }

            BronKerbosch(graph, R, P, X);
        }
        public static void Main(string[] args)
        {
            FillDict(dict);
            Console.Write("Введите количество вершин: ");
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            matrix = GetMatrix(matrix);
            ShowMatrix(matrix, dict);


            bool isFinal = false;
            int choice = 0;
            while (!isFinal) {
                Console.WriteLine("1 - Дейкстра, 2 - Прим, 3 - Клика");
                choice = Interface.ReadElem();
                switch (choice) {
                    case 1:
                        Console.Write("Введите начальную вершину (буквой): ");
                        char startVertex = Console.ReadLine()[0];
                        Console.Write("Введите конечную вершину (буквой): ");
                        char endVertex = Console.ReadLine()[0];

                        // Преобразуем вершины в индексы
                        int startIndex = GetVertexIndex(startVertex);
                        int endIndex = GetVertexIndex(endVertex);

                        // Проверяем, что вершины существуют
                        if (startIndex == -1 || endIndex == -1)
                        {
                            Console.WriteLine("Ошибка: одна из вершин не найдена.");
                            return;
                        }

                        Dijkstra(matrix, startIndex, endIndex);
                        break;
                    case 2:
                        Prim(matrix);
                        break;
                    case 3:
                        FindCliques(matrix);
                        break;
                    case 4:
                        isFinal = true;
                        break;

                    default:
                        Console.WriteLine("Ошибка");
                        break;

                }
            }
            //Console.Write("Введите начальную вершину (буквой): ");
            //char startVertex = Console.ReadLine()[0];
            //Console.Write("Введите конечную вершину (буквой): ");
            //char endVertex = Console.ReadLine()[0];

            //// Преобразуем вершины в индексы
            //int startIndex = GetVertexIndex(startVertex);
            //int endIndex = GetVertexIndex(endVertex);

            //// Проверяем, что вершины существуют
            //if (startIndex == -1 || endIndex == -1)
            //{
            //    Console.WriteLine("Ошибка: одна из вершин не найдена.");
            //    return;
            //}

            //Dijkstra(matrix, startIndex, endIndex);
            Prim(matrix);
            
        }
    }
}