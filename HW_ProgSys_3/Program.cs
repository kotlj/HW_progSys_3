using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskStack
{
    class Task1
    {
        public static async Task totalTask()
        {
            string check = "";
            int start = 0;
            int end = 0;
            Console.WriteLine("Enter start of count:\n");
            check = Console.ReadLine();
            int.TryParse(check, out start);
            Console.WriteLine("Enter end of count(0 to endless):\n");
            check = Console.ReadLine();
            int.TryParse(check, out end);
            Thread thread3;
            Thread thread2;
            Thread thread1;
            if (end == 0)
            {
                int number = start;
                thread1 = new Thread(delegate ()
                {
                    while (true)
                    {
                        int count = 0;
                        if (number != 0)
                        {
                            for (int i = 2; i < number; i++)
                            {
                                if (i != number && number % i == 0)
                                {
                                    count++;
                                    break;
                                }
                            }
                        }
                        if (count == 0)
                        {
                            Console.WriteLine($"Prime: {number}");
                        }
                        number++;
                        Thread.Sleep(400);
                    }
                });
                thread1.Start();
            }
            else
            {
                thread2 = new Thread(delegate ()
                {
                    int number = start;
                    int endNum = end;
                    while (number < end)
                    {
                        int count = 0;
                        if (number != 0)
                        {
                            for (int i = 2; i < number; i++)
                            {
                                if (i != number && number % i == 0)
                                {
                                    count++;
                                    break;
                                }
                            }
                        }
                        if (count == 0)
                        {
                            Console.WriteLine($"Prime: {number}");
                        }
                        number++;
                        Thread.Sleep(400);
                    }
                });
                thread2.Start();
            }
            char choise = '0';
            Console.WriteLine("Choose thread for fib:\n1 - rewrite endless prime numbs\n2 - rewrite prime numb\n3 - empty thread");
            choise = (Console.ReadLine())[0];
            if (choise == '1')
            {
                thread1 = new Thread(fib);
                thread1.Start();
            }
            else if (choise == '2')
            {
                thread2 = new Thread(fib);
                thread2.Start();
            }
            else if (choise == '3')
            {
                thread3 = new Thread(fib);
                thread3.Start();
            }
            else
            {
                Console.WriteLine("Error: unkonwn option");
            }    
        }

        //Можно было-бы сделать в трёх функциях, где две для цыклов и одна для пользователя, а после все потоки 
        //сделать с параметрами, но... Это просто дольше. Даже не сложней - дольше. Потому идём по пути наименьшего сопротивления.

        //А ещё у меня отключили интернет за неуплату на этой дз... Весело жить... Придётся утром бежать пополнять, а после уже сдавать.

        private static void fib()
        {
            long N_zero = 0;
            long N_one = 1;
            while(true)
            {
                Console.WriteLine($"fib: {N_zero}, {N_one}");
                N_zero = N_zero + N_one;
                N_one = N_one + N_zero;
                Thread.Sleep(400);
            }
        }
    }
}

namespace HW_ProgSys_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TaskStack.Task1.totalTask();
        }
    }
}
