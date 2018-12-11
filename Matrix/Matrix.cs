using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matrix
{
    class MyMatrix
    {
        int[,] a=new int[3,3];
        
        public void Set(int i, int j, int znach)
        {
            a[i, j] = znach;
        }
        
        public static MyMatrix operator +(MyMatrix matrix1, MyMatrix matrix2)
        {
            MyMatrix NewMatrix = new MyMatrix();
            for (int i = 0; i < 3; i++)               
            {
                for (int j = 0; j < 3; j++)
                {
                    NewMatrix.a[i, j] = matrix1.a[i, j] + matrix2.a[i, j];
                }
            }
            return NewMatrix;
        }

        public string Visual(int i, int j)
        {
            return a[i, j].ToString();
        }
        
        public DataGridView FullVisual(DataGridView dt)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    dt.Rows[j].Cells[i].Value = a[i, j];
                }
            }
            return dt;
        }

        public static MyMatrix operator -(MyMatrix matrix1, MyMatrix matrix2)
        {
            MyMatrix NewMatrix = new MyMatrix();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    NewMatrix.a[i, j] = matrix1.a[i, j] - matrix2.a[i, j];
                }
            }
            return NewMatrix;
        }

        public MyMatrix Trans()
        {
            MyMatrix NewMatrix = new MyMatrix();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    NewMatrix.a[i, j] = a[j, i];
                }
            }
            return NewMatrix;
        }
        
        public static MyMatrix operator *(MyMatrix matrix1, MyMatrix matrix2)
        {
            MyMatrix NewMatrix = new MyMatrix();
            for (int i = 0; i < 3; i++)
            {
                for (int k = 0; k < 3; k++)
                {
                    //int a = 0;
                    for (int j = 0; j < 3; j++)
                    {
                        //a += matrix1.a[j,k] * matrix2.a[i, j];
                        NewMatrix.a[i, k]+= matrix1.a[j, k] * matrix2.a[i, j];
                    }
                    //NewMatrix.a[i, k] = a;
                }
            }
            return NewMatrix;
        }
        
        public void Zapoln(DataGridView grid)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    a[i, j] = Convert.ToInt32(grid.Rows[j].Cells[i].Value);
                }
            }
        }
    }
}