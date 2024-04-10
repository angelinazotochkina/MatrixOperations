using MatrixOperations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MatrixOperationsTests
{
    [TestClass]
    public class MatrixOperations
    {
        [TestMethod]
        public void Test_AddMatrices()
        {
            var mainWindow = new MainWindow();
            int[,] matrix1 = { { 1, 2 }, { 3, 4 } };
            int[,] matrix2 = { { 2, 2 }, { 1, 1 } };
            int[,] expected = { { 3, 4 }, { 4, 5 } };

          
            int[,] result = mainWindow.AddMatrices(matrix1, matrix2);

         
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test_SubtractMatrices()
        {
            var mainWindow = new MainWindow();
            int[,] matrix1 = { { 1, 2 }, { 3, 4 } };
            int[,] matrix2 = { { 2, 2 }, { 1, 1 } };
            int[,] expected = { { -1, 0 }, { 2, 3 } };

         
            int[,] result = mainWindow.SubtractMatrices(matrix1, matrix2);

          
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test_MultiplyMatrice()
        {
            var mainWindow = new MainWindow();
            int[,] matrix1 = { { 1, 2 }, { 3, 4 } };
            int[,] matrix2 = { { 2, 0 }, { 1, 2 } };
            int[,] expected = { { 4, 4 }, { 10, 8 } };

           
            int[,] result = mainWindow.MultiplyMatrices(matrix1, matrix2);

          
            CollectionAssert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Test_ParseMatrix_ValidInput()
        {
           
            var mainWindow = new MainWindow();
            string matrixText = "1, 2, 3, 4";
            int[,] expected = { { 1, 2 }, { 3, 4 } };

            
            int[,] result = mainWindow.ParseMatrix(matrixText);

        
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test_ParseMatrix_InvalidInput()
        {
          
            var mainWindow = new MainWindow();
            string matrixText = "1, 2, x, 4";

            Assert.ThrowsException<ArgumentException>(() => mainWindow.ParseMatrix(matrixText));
        }

        [TestMethod]
        public void Test_TransposeMatrix()
        {
            var mainWindow = new MainWindow();
            int[,] matrix = { { 1, 2, 3 }, { 4, 5, 6 } };
            int[,] expected = { { 1, 4 }, { 2, 5 }, { 3, 6 } };

            
            int[,] result = mainWindow.TransposeMatrix(matrix);

           
            CollectionAssert.AreEqual(expected, result);
        }
        [TestMethod]

        public void Test_Matrix()
        {

            var mainWindow = new MainWindow();
           string matrixText = "0, 0, 0, 0";
            int[,] matrix = mainWindow.ParseMatrix(matrixText);
            Assert.IsFalse(mainWindow.IsNonZero(matrix));
           // Assert.ThrowsException<IndexOutOfRangeException>(() => mainWindow.ParseMatrix(matrixText));
        }





    }
}
