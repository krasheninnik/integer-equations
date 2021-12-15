using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using IntegerEquations;

namespace IntegerEquationsTest
{
    [TestClass]
    public class UnitTest1
    {
        const string newLine = "\r\n";
        const string noSolution = "No solution";

/*   
2 3
3 4 0 8
7 0 5 6
*/
        [TestMethod]
        public void TestFromExploring()
        {
            // read info
            int equalsNumber = 2; // equations amount
            int unknowsNumber = 3; // unknows amount
            int[,] matrix = new int[equalsNumber + unknowsNumber, unknowsNumber + 1];

            matrix[0, 0] = 3;
            matrix[0, 1] = 4;
            matrix[0, 2] = 0;
            matrix[0, 3] = 8;

            matrix[1, 0] = 7;
            matrix[1, 1] = 0;
            matrix[1, 2] = 5;
            matrix[1, 3] = 6;

            Solver.FormingMatrix(matrix, equalsNumber, unknowsNumber);
            bool calculated = Solver.CalculateSystem(equalsNumber, unknowsNumber, matrix);
            string result = Solver.FormingResult(calculated, matrix, equalsNumber, unknowsNumber);

            string expectedResult = "1" + newLine +
                "-20 488" + newLine +
                "15 -364" + newLine +
                "28 -682" + newLine;

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestFromExploringNonSolving()
        {
            // read info
            int equalsNumber = 2; // equations amount
            int unknowsNumber = 3; // unknows amount
            int[,] matrix = new int[equalsNumber + unknowsNumber, unknowsNumber + 1];

            matrix[0, 0] = 3;
            matrix[0, 1] = 6;
            matrix[0, 2] = 0;
            matrix[0, 3] = 8;

            matrix[1, 0] = 7;
            matrix[1, 1] = 0;
            matrix[1, 2] = 5;
            matrix[1, 3] = 6;

            Solver.FormingMatrix(matrix, equalsNumber, unknowsNumber);
            bool calculated = Solver.CalculateSystem(equalsNumber, unknowsNumber, matrix);
            string result = Solver.FormingResult(calculated, matrix, equalsNumber, unknowsNumber);

            string expectedResult = noSolution;
            Assert.AreEqual(expectedResult, result);
        }

        /*
3 3
1 0 0 1
0 2 0 2
0 0 3 3
        */
        [TestMethod]
        public void Test1()
        {
            // read info
            int equalsNumber = 3; // equations amount
            int unknowsNumber = 3; // unknows amount
            int[,] matrix = new int[equalsNumber + unknowsNumber, unknowsNumber + 1];

            matrix[0, 0] = 1;
            matrix[0, 1] = 0;
            matrix[0, 2] = 0;
            matrix[0, 3] = 1;

            matrix[1, 0] = 0;
            matrix[1, 1] = 2;
            matrix[1, 2] = 0;
            matrix[1, 3] = 2;

            matrix[2, 0] = 0;
            matrix[2, 1] = 0;
            matrix[2, 2] = 3;
            matrix[2, 3] = 3;

            Solver.FormingMatrix(matrix, equalsNumber, unknowsNumber);
            bool calculated = Solver.CalculateSystem(equalsNumber, unknowsNumber, matrix);
            string result = Solver.FormingResult(calculated, matrix, equalsNumber, unknowsNumber);

            string expectedResult = "0" + newLine +
                "1" + newLine +
                "1" + newLine +
                "1" + newLine;

            Assert.AreEqual(expectedResult, result);
        }

/*
3 3
0 0 3 3
0 2 0 2
1 0 0 1
*/
        [TestMethod]
        public void Test1_1()
        {
            // read info
            int equalsNumber = 3; // equations amount
            int unknowsNumber = 3; // unknows amount
            int[,] matrix = new int[equalsNumber + unknowsNumber, unknowsNumber + 1];

            matrix[0, 0] = 0;
            matrix[0, 1] = 0;
            matrix[0, 2] = 3;
            matrix[0, 3] = 3;

            matrix[1, 0] = 0;
            matrix[1, 1] = 2;
            matrix[1, 2] = 0;
            matrix[1, 3] = 2;

            matrix[2, 0] = 1;
            matrix[2, 1] = 0;
            matrix[2, 2] = 0;
            matrix[2, 3] = 1;

            Solver.FormingMatrix(matrix, equalsNumber, unknowsNumber);
            bool calculated = Solver.CalculateSystem(equalsNumber, unknowsNumber, matrix);
            string result = Solver.FormingResult(calculated, matrix, equalsNumber, unknowsNumber);

            string expectedResult = "0" + newLine +
                "1" + newLine +
                "1" + newLine +
                "1" + newLine;

            Assert.AreEqual(expectedResult, result);
        }

/*
3 3
1 0 1 1
0 1 0 2
1 0 1 3
        */
        [TestMethod]
        public void Test2()
        {
            // read info
            int equalsNumber = 3; // equations amount
            int unknowsNumber = 3; // unknows amount
            int[,] matrix = new int[equalsNumber + unknowsNumber, unknowsNumber + 1];

            matrix[0, 0] = 1;
            matrix[0, 1] = 0;
            matrix[0, 2] = 1;
            matrix[0, 3] = 1;

            matrix[1, 0] = 0;
            matrix[1, 1] = 1;
            matrix[1, 2] = 0;
            matrix[1, 3] = 2;

            matrix[2, 0] = 1;
            matrix[2, 1] = 0;
            matrix[2, 2] = 1;
            matrix[2, 3] = 3;

            Solver.FormingMatrix(matrix, equalsNumber, unknowsNumber);
            bool calculated = Solver.CalculateSystem(equalsNumber, unknowsNumber, matrix);
            string result = Solver.FormingResult(calculated, matrix, equalsNumber, unknowsNumber);

            string expectedResult = noSolution;

            Assert.AreEqual(expectedResult, result);
        }

/*
3 3
1 0 1 1
0 1 0 2
2 0 2 2
*/
        [TestMethod]
        public void Test3()
        {
            // read info
            int equalsNumber = 3; // equations amount
            int unknowsNumber = 3; // unknows amount
            int[,] matrix = new int[equalsNumber + unknowsNumber, unknowsNumber + 1];

            matrix[0, 0] = 1;
            matrix[0, 1] = 0;
            matrix[0, 2] = 1;
            matrix[0, 3] = 1;

            matrix[1, 0] = 0;
            matrix[1, 1] = 1;
            matrix[1, 2] = 0;
            matrix[1, 3] = 2;

            matrix[2, 0] = 2;
            matrix[2, 1] = 0;
            matrix[2, 2] = 2;
            matrix[2, 3] = 2;

            Solver.FormingMatrix(matrix, equalsNumber, unknowsNumber);
            bool calculated = Solver.CalculateSystem(equalsNumber, unknowsNumber, matrix);
            string result = Solver.FormingResult(calculated, matrix, equalsNumber, unknowsNumber);

            string expectedResult = "1" + newLine +
                 "-1 1" + newLine +
                 "0 2" + newLine +
                 "1 0" + newLine;

            Assert.AreEqual(expectedResult, result);
        }

        /*
2 3
1 0 1 1
0 1 0 2
        */
        [TestMethod]
        public void Test4()
        {
            // read info
            int equalsNumber = 2; // equations amount
            int unknowsNumber = 3; // unknows amount
            int[,] matrix = new int[equalsNumber + unknowsNumber, unknowsNumber + 1];

            matrix[0, 0] = 1;
            matrix[0, 1] = 0;
            matrix[0, 2] = 1;
            matrix[0, 3] = 1;

            matrix[1, 0] = 0;
            matrix[1, 1] = 1;
            matrix[1, 2] = 0;
            matrix[1, 3] = 2;

            Solver.FormingMatrix(matrix, equalsNumber, unknowsNumber);
            bool calculated = Solver.CalculateSystem(equalsNumber, unknowsNumber, matrix);
            string result = Solver.FormingResult(calculated, matrix, equalsNumber, unknowsNumber);

            string expectedResult = "1" + newLine +
                 "-1 1" + newLine +
                 "0 2" + newLine +
                 "1 0" + newLine;

            Assert.AreEqual(expectedResult, result);
        }

/*
2 3
1 0 1 1
0 1 -1 2
*/
        [TestMethod]
        public void Test5()
        {
            // read info
            int equalsNumber = 2; // equations amount
            int unknowsNumber = 3; // unknows amount
            int[,] matrix = new int[equalsNumber + unknowsNumber, unknowsNumber + 1];

            matrix[0, 0] = 1;
            matrix[0, 1] = 0;
            matrix[0, 2] = 1;
            matrix[0, 3] = 1;

            matrix[1, 0] = 0;
            matrix[1, 1] = 1;
            matrix[1, 2] = -1;
            matrix[1, 3] = 2;

            Solver.FormingMatrix(matrix, equalsNumber, unknowsNumber);
            bool calculated = Solver.CalculateSystem(equalsNumber, unknowsNumber, matrix);
            string result = Solver.FormingResult(calculated, matrix, equalsNumber, unknowsNumber);

            string expectedResult = "1" + newLine +
                 "-1 1" + newLine +
                 "1 2" + newLine +
                 "1 0" + newLine;

            Assert.AreEqual(expectedResult, result);
        }

/*
2 3
1 1 1 1
2 2 2 4
*/
        [TestMethod]
        public void Test6()
        {
            // read info
            int equalsNumber = 2; // equations amount
            int unknowsNumber = 3; // unknows amount
            int[,] matrix = new int[equalsNumber + unknowsNumber, unknowsNumber + 1];

            matrix[0, 0] = 1;
            matrix[0, 1] = 1;
            matrix[0, 2] = 1;
            matrix[0, 3] = 1;

            matrix[1, 0] = 2;
            matrix[1, 1] = 2;
            matrix[1, 2] = 2;
            matrix[1, 3] = 4;

            Solver.FormingMatrix(matrix, equalsNumber, unknowsNumber);
            bool calculated = Solver.CalculateSystem(equalsNumber, unknowsNumber, matrix);
            string result = Solver.FormingResult(calculated, matrix, equalsNumber, unknowsNumber);

            string expectedResult = noSolution;

            Assert.AreEqual(expectedResult, result);
        }

        /*
2 3
1 1 10 2
2 2 10 4
*/
        [TestMethod]
        public void TestCase1()
        {
            // read info
            int equalsNumber = 2; // equations amount
            int unknowsNumber = 3; // unknows amount
            int[,] matrix = new int[equalsNumber + unknowsNumber, unknowsNumber + 1];

            matrix[0, 0] = 1;
            matrix[0, 1] = 1;
            matrix[0, 2] = 10;
            matrix[0, 3] = 2;

            matrix[1, 0] = 2;
            matrix[1, 1] = 2;
            matrix[1, 2] = 10;
            matrix[1, 3] = 4;

            Solver.FormingMatrix(matrix, equalsNumber, unknowsNumber);
            bool calculated = Solver.CalculateSystem(equalsNumber, unknowsNumber, matrix);
            string result = Solver.FormingResult(calculated, matrix, equalsNumber, unknowsNumber);

            string expectedResult = "1" + newLine +
                 "-1 2" + newLine +
                 "1 0" + newLine +
                 "0 0" + newLine;

            Assert.AreEqual(expectedResult, result);
        }


/*
5 3
1 1 10 2
2 2 10 4
3 3 10 6
4 4 10 8
5 5 10 10
*/
        [TestMethod]
        public void TestCase1_moreEquals()
        {
            // read info
            int equalsNumber = 5; // equations amount
            int unknowsNumber = 3; // unknows amount
            int[,] matrix = new int[equalsNumber + unknowsNumber, unknowsNumber + 1];

            matrix[0, 0] = 1;
            matrix[0, 1] = 1;
            matrix[0, 2] = 10;
            matrix[0, 3] = 2;

            matrix[1, 0] = 2;
            matrix[1, 1] = 2;
            matrix[1, 2] = 10;
            matrix[1, 3] = 4;

            matrix[2, 0] = 3;
            matrix[2, 1] = 3;
            matrix[2, 2] = 10;
            matrix[2, 3] = 6;

            matrix[3, 0] = 4;
            matrix[3, 1] = 4;
            matrix[3, 2] = 10;
            matrix[3, 3] = 8;

            matrix[4, 0] = 5;
            matrix[4, 1] = 5;
            matrix[4, 2] = 10;
            matrix[4, 3] = 10;


            Solver.FormingMatrix(matrix, equalsNumber, unknowsNumber);
            bool calculated = Solver.CalculateSystem(equalsNumber, unknowsNumber, matrix);
            string result = Solver.FormingResult(calculated, matrix, equalsNumber, unknowsNumber);

            string expectedResult = "1" + newLine +
                 "-1 2" + newLine +
                 "1 0" + newLine +
                 "0 0" + newLine;

            Assert.AreEqual(expectedResult, result);
        }

/*
1 1
1 5
*/
        [TestMethod]
        public void TestCase2_trivialCase()
        {
            // read info
            int equalsNumber = 1; // equations amount
            int unknowsNumber = 1; // unknows amount
            int[,] matrix = new int[equalsNumber + unknowsNumber, unknowsNumber + 1];

            matrix[0, 0] = 1;
            matrix[0, 1] = 5;

            Solver.FormingMatrix(matrix, equalsNumber, unknowsNumber);
            bool calculated = Solver.CalculateSystem(equalsNumber, unknowsNumber, matrix);
            string result = Solver.FormingResult(calculated, matrix, equalsNumber, unknowsNumber);

            string expectedResult = "0" + newLine +
                 "5" + newLine;

            Assert.AreEqual(expectedResult, result);
        }

/*
3 3
0 0 0 0
0 0 0 0
0 0 0 0
*/
        [TestMethod]
        public void TestCase2_somethingStrange()
        {
            // read info
            int equalsNumber = 3; // equations amount
            int unknowsNumber = 3; // unknows amount
            int[,] matrix = new int[equalsNumber + unknowsNumber, unknowsNumber + 1];

            matrix[0, 0] = 0;
            matrix[0, 1] = 0;
            matrix[0, 2] = 0;
            matrix[0, 3] = 0;

            matrix[1, 0] = 0;
            matrix[1, 1] = 0;
            matrix[1, 2] = 0;
            matrix[1, 3] = 0;

            matrix[2, 0] = 0;
            matrix[2, 1] = 0;
            matrix[2, 2] = 0;
            matrix[2, 3] = 0;


            Solver.FormingMatrix(matrix, equalsNumber, unknowsNumber);
            bool calculated = Solver.CalculateSystem(equalsNumber, unknowsNumber, matrix);
            string result = Solver.FormingResult(calculated, matrix, equalsNumber, unknowsNumber);

            string expectedResult = "3" + newLine +
                 "1 0 0 0" + newLine +
                 "0 1 0 0" + newLine +
                 "0 0 1 0" + newLine;

            Assert.AreEqual(expectedResult, result);
        }
    }
}
