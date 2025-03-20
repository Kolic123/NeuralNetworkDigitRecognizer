using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkDigitRecognizer
{
    public class Matrix
    {
        public int rows, cols;
        public double[,] matrix;



        public Matrix(int rows_, int cols_)
        {
            rows = rows_;
            cols = cols_;
            matrix = new double[rows, cols];
        }

        public Matrix(double[] x)
        {
            rows = x.Length;
            cols = 1;
            matrix = new double[x.Length, 1];
            for (int i = 0; i < x.Length; i++)
            {
                matrix[i, 0] = x[i];
            }

        }

        public double[] ToFloatArray()
        {
            int x = 0, y = 0;
            double[] res = new double[cols * rows];

            for (int i = 0; i < rows * cols; i++)
            {
                res[i] = matrix[x, y];
                
                y++;
                if (y == cols)
                {
                    y = 0;     
                    x++;       
                }
            }

            return res;
        }

        public void map(Func<double, double> f)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = f(matrix[i, j]);
                }
            }
        }

        public Matrix Transpose()
        {
            var res = new Matrix(cols, rows);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    res.matrix[j, i] = matrix[i, j];
                }
            }


            return res;

        }

        public static Matrix Dot(Matrix x, Matrix y)
        {
            
            var res = new Matrix(y.rows, x.cols);
            
            if (y.cols == x.rows)
            {


                for (int i = 0; i < y.rows; i++)
                {
                    for (int j = 0; j < x.cols; j++)
                    {
                        double sum = 0;
                        for (int k = 0; k < y.cols; k++)
                        {
                            sum += y.matrix[i, k] * x.matrix[k, j];
                        }

                        res.matrix[i, j] = sum;
                    }
                }


            }
            else
            {

                return res;
            }
            return res;

        }

        public void Fill()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = 1.0F;
                }
            }
        }

        public void Scale(double x)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] *= x;
                }
            }
        }

        public static Matrix Map(Matrix x, Func<double, double> f)
        {
            var ans = new Matrix(x.rows, x.cols);
            for (int i = 0; i < x.rows; i++)
            {
                for (int j = 0; j < x.cols; j++)
                {
                    ans.matrix[i, j] = f(x.matrix[i, j]);
                }
            }

            return ans;

        }

        public void Add(double x)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] += x;
                }
            }
        }
        public void AddMatrixByElementBia(Matrix x)
        {
            
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] += x.matrix[i, 0];
                }
            }

        }

        public void Randomize()
        {
            Random r = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = (r.NextDouble() * 2 - 1);
                }
            }
        }

        public void AddMatrixByElement(Matrix x)
        {
            if (x.cols != cols || x.rows != rows)
            {
                return;
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] += x.matrix[i, j];
                }
            }
        }

        public void ScaleMatrixByElement(Matrix x)
        {
            if (x.cols != cols || x.rows != rows)
            { 
                return;
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] *= x.matrix[i, j];
                }
            }
        }

        public static Matrix Subtract(double[] x1, double[] y1)
        {
            var x = new Matrix(x1);
            var y = new Matrix(y1);
            var res = new Matrix(x.rows, x.cols);
            for (int i = 0; i < x.rows; i++)
            {
                for (int j = 0; j < x.cols; j++)
                {
                    res.matrix[i, j] = x.matrix[i, j] - y.matrix[i, j];
                }
            }

            return res;



        }
        public static Matrix Subtract(Matrix x, Matrix y)
        {

            var res = new Matrix(x.rows, x.cols);
            for (int i = 0; i < x.rows; i++)
            {
                for (int j = 0; j < x.cols; j++)
                {
                    res.matrix[i, j] = x.matrix[i, j] - y.matrix[i, j];
                }
            }

            return res;



        }

        public static Matrix Subtract(double[] x1, Matrix y)
        {
            var x = new Matrix(x1);
           
            var res = new Matrix(x.rows, x.cols);
            for (int i = 0; i < x.rows; i++)
            {
                for (int j = 0; j < x.cols; j++)
                {
                    res.matrix[i, j] = x.matrix[i, j] - y.matrix[i, j];
                }
            }

            return res;



        }


        public void Ispis()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(" {0}", matrix[i, j]);
                }
                Console.WriteLine("\n");
            }
        }
    }
}
