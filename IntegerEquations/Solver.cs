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

        private static bool IsNeedColumnSwap(ref int nonZeroAmount, int row, int[,] matrix)
        {
            bool isNeedColumnSwap = true;
            nonZeroAmount = CalculateNonZerosInRow(row, matrix);

            // ANOTHER CHECK FOR isNeedColumnSwap !!
            // find another non zero element
            int nonZeroElemColumnIndex = -1;
            for (int column = row + 1; column < matrix.GetLength(1); column++)
            {
                if (matrix[row, column] != 0)
                {
                    nonZeroElemColumnIndex = column;
                    break;
                }
            }

            if (nonZeroElemColumnIndex == -1)
            {
                isNeedColumnSwap = false;
            }
            else
            {
                isNeedColumnSwap = true;
            }

            return isNeedColumnSwap;
        }

        public static bool CalculateSystem(int n, int m, int[,] matrix)
        {
            int nonZeroAmount = 0;
            bool isNeedColumnSwap = true;

            for (int row = 0; row < n; row++)
            {
                nonZeroAmount = CalculateNonZerosInRow(row, matrix);

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

                    // find ANOTHER (not the min) non zero element
                    for (int column = row; column < matrix.GetLength(1); column++)
                    {
                        if (column != minElemColumnIndex && matrix[row, column] != 0)
                        {
                            nonZeroElemColumnIndex = column;
                            break;
                        }
                    }

                    // if nonZeroElemColumnIndex haven't been finded --> everything is good
                    // but nonZero may be Min elem, so there is need to recalculate ColumnsSwap flag
                    if (nonZeroElemColumnIndex == -1)
                    {
                        isNeedColumnSwap = IsNeedColumnSwap(ref nonZeroAmount, row, matrix);
                        break;
                    }

                    int q = matrix[row, nonZeroElemColumnIndex] / matrix[row, minElemColumnIndex]; // integer part
                    int r = matrix[row, nonZeroElemColumnIndex] % matrix[row, minElemColumnIndex]; // residual

                    // if we found J == M, and it divided to min column with 0 coef -> "no solutions"
                    if ((nonZeroElemColumnIndex == m && r != 0))
                        return false;

                    for (int rowIndex = 0; rowIndex < matrix.GetLength(0); rowIndex++)
                    {
                        matrix[rowIndex, nonZeroElemColumnIndex] -= matrix[rowIndex, minElemColumnIndex] * q;
                    }

                    isNeedColumnSwap = IsNeedColumnSwap(ref nonZeroAmount, row, matrix);

                }
                while (nonZeroAmount > (row + 1) || matrix[row, m] != 0);

                if (isNeedColumnSwap)
                {
                    var nonZeroElemIndex = -1;

                    // find first non-zero column in l- line
                    for (int columnIter = row + 1; columnIter < m; columnIter++)
                        if (matrix[row, columnIter] != 0)
                        {
                            nonZeroElemIndex = columnIter;
                            break;
                        }

                    if (nonZeroElemIndex == -1)
                    {
                        row--;
                        continue;
                    }

                    // swap two columns (with nonzer item and with row-item)
                    for (int rowIter = 0; rowIter < matrix.GetLength(0); rowIter++) Swap(ref matrix[rowIter, nonZeroElemIndex], ref matrix[rowIter, row]);
                    row--;

                    isNeedColumnSwap = false;
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
