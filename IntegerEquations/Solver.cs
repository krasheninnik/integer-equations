using System;
using System.Collections.Generic;
using System.Text;

namespace IntegerEquations
{
    public class Solver
    {
        public static void FormingMatrix(int [,] matrix, int equalsNumber, int unknowsNumber)
        {
            // prepare matrix (invert C)
            for (int row = 0; row < equalsNumber; row++)
            {
                matrix[row, unknowsNumber] *= -1;
            }

            // prepare matrix (fill I)
            for (int row = 0; row < unknowsNumber; row++)
            {
                matrix[equalsNumber + row, row] = 1;
            }

        }

        static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        public static int CalculateNonZerosInRow(int row, int[,] matrix)
        {
            int result = 0;
            for (int i = 0; i < matrix.GetLength(1); i++)
                if (matrix[row, i] != 0) result++;
            return result;
        }

        // True, если в row строке, начиная с колонки row + 1, есть не нулевые элементы. 
        //  т.к. мы должны их обнулить
        private static bool IsNeedColumnSwap(int row, int[,] matrix)
        {
            int nonZeroElemColumnIndex = -1;
            for (int column = row + 1; column < matrix.GetLength(1); column++)
            {
                if (matrix[row, column] != 0)
                {
                    nonZeroElemColumnIndex = column;
                    break;
                }
            }

            return nonZeroElemColumnIndex == -1 ? false : true;
        }

        public static bool CalculateSystem(int n, int m, int[,] matrix)
        {
            int nonZeroAmount = 0;
            bool isNeedColumnSwap = true;

            for (int row = 0; row < n; row++)
            {
                do
                {
                    int minElemColumnIndex = -1;
                    int nonZeroElemColumnIndex = -1;

                    // find abs min elem in row (wihtout C coef)
                    int minElem = int.MaxValue;
                    for (int column = row; column < matrix.GetLength(1) - 1; column++)
                    {
                        if (matrix[row, column] != 0 && Math.Abs(matrix[row, column]) < Math.Abs(minElem))
                        {
                            minElemColumnIndex = column;
                            minElem = matrix[row, column];
                        }
                    }

                    if (minElemColumnIndex == -1 && matrix[row, m] != 0)
                        return false;

                    // find ANOTHER (not the min) non zero element in the row
                    for (int column = row; column < matrix.GetLength(1); column++)
                    {
                        if (column != minElemColumnIndex && matrix[row, column] != 0)
                        {
                            nonZeroElemColumnIndex = column;
                            break;
                        }
                    }

                    // if nonZeroElemColumnIndex haven't been finded --> everything is good
                    // but nonZero may be Min elem, so there is need to recalculate isNeedColumnSwap flag
                    if (nonZeroElemColumnIndex == -1)
                    {
                        isNeedColumnSwap = IsNeedColumnSwap(row, matrix);
                        break;
                    }

                    int q = matrix[row, nonZeroElemColumnIndex] / matrix[row, minElemColumnIndex]; // integer part
                    int r = matrix[row, nonZeroElemColumnIndex] % matrix[row, minElemColumnIndex]; // residual

                    // if we found nonZeroElemColumnIndex == M, and it divided to min column with resudual != 0 -> "no solutions"
                    if ((nonZeroElemColumnIndex == m && r != 0))
                        return false;

                    for (int rowIndex = 0; rowIndex < matrix.GetLength(0); rowIndex++)
                    {
                        matrix[rowIndex, nonZeroElemColumnIndex] -= matrix[rowIndex, minElemColumnIndex] * q;
                    }

                    nonZeroAmount = CalculateNonZerosInRow(row, matrix);
                    isNeedColumnSwap = IsNeedColumnSwap(row, matrix);
                }
                while (nonZeroAmount > (row + 1) || matrix[row, m] != 0);

                if (isNeedColumnSwap)
                {
                    var nonZeroElemIndex = -1;

                    // find first non-zero column in l-line
                    for (int columnIter = row + 1; columnIter < m; columnIter++)
                        if (matrix[row, columnIter] != 0)
                        {
                            nonZeroElemIndex = columnIter;
                            break;
                        }

                    // swap two columns (with nonzero item and with row-item)
                    for (int rowIter = 0; rowIter < matrix.GetLength(0); rowIter++) Swap(ref matrix[rowIter, nonZeroElemIndex], ref matrix[rowIter, row]);

                    // decrease row to check it again
                    row--;
                }
            }

            return true;
        }

        public static int CalculateFreeVariablesAmount(int[,] matrix, int equalsNumber, int unknowsNumber)
        {
            int minMaxZeros = unknowsNumber + 1;

            for (int row = equalsNumber - 1; row >= 0; row--)
            {
                int maxZeros = 0;

                for (int column = unknowsNumber - 1; column >= 0; column--)
                {
                    if (matrix[row, column] == 0) maxZeros++;
                    else break;
                }

                if (maxZeros < minMaxZeros) minMaxZeros = maxZeros;
            }

            return minMaxZeros;
        }

        // Just for test purposes
        public static string FormingResult(bool calculated, int[,] matrix, int equalsNumber, int unknowsNumber)
        {
            if (calculated)
            {
                var result = new StringBuilder();
                var freeVariableAmount = Solver.CalculateFreeVariablesAmount(matrix, equalsNumber, unknowsNumber);
                result.AppendLine(freeVariableAmount.ToString()); // number of free variables
                for (int i = equalsNumber; i < equalsNumber + unknowsNumber; i++)
                {
                    for (int j = unknowsNumber - freeVariableAmount; j < unknowsNumber + 1; j++)
                    {
                        var space = j == unknowsNumber ? "" : " ";
                        result.Append($"{matrix[i, j]}{space}");
                    }
                    result.AppendLine();
                }
                return result.ToString();
            }
            else
            {
                return "No solution";
            }
        }
    }
}
