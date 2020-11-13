using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProj
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] Input = new int[4,4] { { 7, 3, 1, 9 },{ 3, 4, 6, 9 },{ 6, 9, 6, 6 },{ 9, 5, 8, 5 } };
            var ans = DiagonalSum_1572(Input);
            Console.Write("hello，{0}", ans);
            Console.ReadKey();
        }

        static int DiagonalSum_1572(int[,] mat)
        {
            //Given a square matrix mat, return the sum of the matrix diagonals.
            //Only include the sum of all the elements on the primary diagonal and all the elements on the  
            //secondary diagonal that are not part of the primary diagonal.

            var Lsum = 0;var Rsum=0;
            var Total = 0;
            for (int i =0;i <mat.GetLength(1);i++)
            {
                Lsum += mat[i, i];
                Rsum += mat[i, mat.GetLength(1)-1 - i];
            }

            if (mat.GetLength(1) %2==1)
            {
                Total = Lsum + Rsum - mat[mat.GetLength(1) % 2, mat.GetLength(1) % 2];
            }
            else
            {
                Total = Lsum + Rsum;
            }

            return Total;
        }
    }
}
