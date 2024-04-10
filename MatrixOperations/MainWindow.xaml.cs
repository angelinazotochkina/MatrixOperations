using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace MatrixOperations
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public class MatrixViewModel
        {
            public ObservableCollection<MatrixRowViewModel> Rows { get; set; }

            public MatrixViewModel()
            {
                Rows = new ObservableCollection<MatrixRowViewModel>();
            }
        }

        public class MatrixRowViewModel
        {
            public ObservableCollection<int> Values { get; set; }

            public MatrixRowViewModel()
            {
                Values = new ObservableCollection<int>();
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            int[,] matrix1 = ParseMatrix(matrix1TextBox.Text);
            int[,] matrix2 = ParseMatrix(matrix2TextBox.Text);
            int[,] result = AddMatrices(matrix1, matrix2);
            DisplayResult(result);
        }

        private void SubtractButton_Click(object sender, RoutedEventArgs e)
        {
            int[,] matrix1 = ParseMatrix(matrix1TextBox.Text);
            int[,] matrix2 = ParseMatrix(matrix2TextBox.Text);
            int[,] result = SubtractMatrices(matrix1, matrix2);
            DisplayResult(result);
        }

        private void MultiplyButton_Click(object sender, RoutedEventArgs e)
        {
            int[,] matrix1 = ParseMatrix(matrix1TextBox.Text);
            int[,] matrix2 = ParseMatrix(matrix2TextBox.Text);
            int[,] result = MultiplyMatrices(matrix1, matrix2);
            DisplayResult(result);
        }

        private void TransposeButton_Click(object sender, RoutedEventArgs e)
        {
            int[,] matrix = ParseMatrix(matrix1TextBox.Text);
            int[,] result = TransposeMatrix(matrix);
            DisplayResult(result);
        }

        public int[,] ParseMatrix(string matrixText)
        {
            string[] rows = matrixText.Split(',');
            int size = (int)Math.Sqrt(rows.Length);
            int[,] matrix = new int[size, size];

            for (int i = 0; i < rows.Length; i++)
            {
                int row = i / size;
                int col = i % size;
                if (int.TryParse(rows[i].Trim(), out int value))
                {
                    matrix[row, col] = value;
                }
                else
                {
                    throw new ArgumentException("Invalid matrix input");
                }
            }

            return matrix;
        }
        public int[,] AddMatrices(int[,] matrix1, int[,] matrix2)
        {
            int rows = matrix1.GetLength(0);
            int cols = matrix1.GetLength(1);
            int[,] result = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }

            return result;
        }

        public int[,] SubtractMatrices(int[,] matrix1, int[,] matrix2)
        {
            int rows = matrix1.GetLength(0);
            int cols = matrix1.GetLength(1);
            int[,] result = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = matrix1[i, j] - matrix2[i, j];
                }
            }

            return result;
        }

        public int[,] MultiplyMatrices(int[,] matrix1, int[,] matrix2)
        {
            int rows1 = matrix1.GetLength(0);
            int cols1 = matrix1.GetLength(1);
            int cols2 = matrix2.GetLength(1);
            int[,] result = new int[rows1, cols2];

            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols2; j++)
                {
                    for (int k = 0; k < cols1; k++)
                    {
                        result[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }

            return result;
        }

        public int[,] TransposeMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[,] result = new int[cols, rows];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[j, i] = matrix[i, j];
                }
            }

            return result;
        }


        private void DisplayResult(int[,] result)
        {
            var viewModel = ConvertToViewModel(result);
            resultDataGrid.ItemsSource = viewModel.Rows;
        }

        public MatrixViewModel ConvertToViewModel(int[,] matrix)
        {
            MatrixViewModel viewModel = new MatrixViewModel();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                MatrixRowViewModel rowViewModel = new MatrixRowViewModel();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    rowViewModel.Values.Add(matrix[i, j]);
                }
                viewModel.Rows.Add(rowViewModel);
            }

            return viewModel;
        }

        public bool IsNonZero(int[,] matrix)
        {
         
                foreach (int element in matrix)
                {
                    if (element != 0)
                    {
                        return true; 
                    }
                }

                return false;
            
        }
    }
}