using System;

namespace IntegerEquations
{
    class Program
    {
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
            int equalsNumber = Convert.ToInt32(Console.ReadLine()); // equations amount
            int unknowsNumber = Convert.ToInt32(Console.ReadLine()); // unknows amount

            int[,] matrix = new int[equalsNumber + unknowsNumber, unknowsNumber + 1];

            for (int row = 0; row < equalsNumber; row++)
            {
                var stringColumsValue = Console.ReadLine().Split(" ");
                for (int column = 0; column < unknowsNumber + 1; column++)
                {
                    matrix[row, column] = Convert.ToInt32(stringColumsValue[column]);
                }
            }

            Solver.FormingMatrix(matrix, equalsNumber, unknowsNumber);
            bool calculated = Solver.CalculateSystem(equalsNumber, unknowsNumber, matrix);
            string result = Solver.FormingResult(calculated, matrix, equalsNumber, unknowsNumber);
            Console.WriteLine(result);           
        }

	}
}
