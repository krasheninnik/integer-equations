using System;

namespace IntegerEquations
{
    class Program
    {
        /*
        2
        3
        3
        4
        0
        8
        7
        0
        5
        6
        */

        /*
         * Написать консольную программу, которая считывает систему уравнений, решает ее и выдает результат. 
         * Ввод и вывод  -- стандартные потоки ввода-вывода. Формат входного файла: в первой строке 2 целых числа N M через пробел, N < 15, M<15,
         * N -- число уравнений, M -- число неизвестных. Далее N строк по M+1 целых чисел, свободный член -- последний (уравнения вида ax+by+c=0). 
         * Формат выходного файла: в первой строке 1 целое число K -- число свободных переменных. Далее M строк по K+1 чисел, свободный член последний.
         * Если решений нет, то в единственной строке текст NO SOLUTIONS
         */
        static void Main(string[] args)
        {
            // read info
            int M = Convert.ToInt32(Console.ReadLine()); // equations amount
            int N = Convert.ToInt32(Console.ReadLine()); // unknows amount

            int[,] matrix = new int[M + N, N + 1];

            for (int row = 0; row < M; row++)
            {
                for(int column = 0; column < N + 1; column++)
                {
                    matrix[row, column] = Convert.ToInt32(Console.ReadLine());
                }
            }

            // prepare matrix (invert C)
            for (int row = 0; row < M; row++)
            {
                matrix[row, N] *= -1;
            }

            // prepare matrix (fill I)
            for (int row = 0; row < N; row++)
            {
                matrix[M + row, row] = 1;
            }

            Console.WriteLine(1);

        }
    }
}
