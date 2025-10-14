using System;

namespace matris_çarpımı_lokasyonu
{
    internal class Program
    {
      
        static int[,] MatrisCarpımı(int[,] A, int[,] B, int N)
        {
            int[,] C = new int[N, N];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    C[i, j] = 0;
                    for (int k = 0; k < N; k++)
                    {
                        C[i, j] += A[i, k] * B[k, j];
                    }
                }
            }
            return C;
        }

     
        static void YazdirMatris(int[,] matris, int N)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(matris[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        static void Main()
        {
            int N = 3;
            int[,] A = {
                { 2, 4, 6 },
                { 8, 10, 12 },
                { 14, 16, 18 }
            };

            int[,] B = {
                { 17, 15, 13 },
                { 11, 9, 7 },
                { 5, 3, 1 }
            };

            int[,] C = MatrisCarpımı(A, B, N);

            Console.WriteLine("A * B Matrisi:");
            YazdirMatris(C, N);
        }
    }
}
