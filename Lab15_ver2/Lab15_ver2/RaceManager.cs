using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab15_ver2
{
    public class RaceManager
    {
        private int[] positions = { 0, 0, 0 }; // Позиции кнопок
        private Thread[] threads = new Thread[3]; 
        private readonly object lockObject = new object(); // Объект для блокировки
        private int finishLine = 1800; // Граница финиша
        //private bool raceOver = false; // Флаг завершения гонки
        private CancellationTokenSource cts;

        public event Action<int> PositionUpdated;

        public void StartRace()
        {
            

            
            cts = new CancellationTokenSource();

            for (int i = 0; i < 3; i++)
            {
                if (threads[i] == null || !threads[i].IsAlive)
                {
                    int index = i;
                    threads[i] = new Thread(() => MoveParticipant(index, cts.Token))
                    {
                        IsBackground = true
                    };
                    threads[i].Priority = ThreadPriority.Normal;
                    threads[i].Start();
                }
            }
        }

        private void MoveParticipant(int index, CancellationToken token)
        {
            try
            {
                while (!token.IsCancellationRequested && positions[index] < finishLine)
                {
                    lock (lockObject)
                    {
                        positions[index]++;
                        int x = positions[index];

                        PositionUpdated?.Invoke(index); // Уведомляем о новой позиции
                    }
                    Thread.Sleep(1);
                    //SimulateWork();
                }
            }
            catch (OperationCanceledException)
            {
                // Поток был отменен
            }
        }

        private void SimulateWork()
        {
            double result = 0;
            for (int i = 0; i < 1_000_000; i++)
            {
                result += Math.Sqrt(i);
            }
        }

        public void UpdatePriority(int index, int value)
        {
            if (index >= 0 && index < threads.Length && threads[index] != null && threads[index].IsAlive)
            {
                switch (value)
                {
                    case 1:
                    case 2:
                    case 3:
                        threads[index].Priority = ThreadPriority.Lowest;
                        break;
                    case 4:
                    case 5:
                    case 6:
                        threads[index].Priority = ThreadPriority.Normal;
                        break;
                    case 7:
                    case 8:
                    case 9:
                    case 10:
                        threads[index].Priority = ThreadPriority.Highest;
                        break;
                }
            }
        }

        public void ResetRace()
        {
            cts.Cancel();
            Array.Clear(positions, 0, positions.Length);
            Array.Clear(threads, 0, threads.Length);
            
        }

        public int GetPosition(int index) => positions[index];
    }
}
