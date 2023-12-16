using System;

public class MathOperations
{
   
    public static T Add<T>(T a, T b)
    {
        dynamic dynamicA = a;
        dynamic dynamicB = b;
        return dynamicA + dynamicB;
    }

л
    public static T[] Add<T>(T[] a, T[] b)
    {
        if (a.Length != b.Length)
            throw new ArgumentException("Arrays must have the same length.");

        T[] result = new T[a.Length];
        for (int i = 0; i < a.Length; i++)
        {
            result[i] = Add(a[i], b[i]);
        }
        return result;
    }

 
    public static T[,] Add<T>(T[,] matrixA, T[,] matrixB)
    {
        int rows = matrixA.GetLength(0);
        int columns = matrixA.GetLength(1);

        if (rows != matrixB.GetLength(0) || columns != matrixB.GetLength(1))
            throw new ArgumentException("Matrices must have the same dimensions.");

        T[,] result = new T[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                result[i, j] = Add(matrixA[i, j], matrixB[i, j]);
            }
        }
        return result;
    }

   
    public static void Main()
    {
        int a = 5, b = 10;
        Console.WriteLine($"Addition of {a} and {b}: {Add(a, b)}");

        double[] arrayA = { 1.5, 2.5, 3.5 };
        double[] arrayB = { 0.5, 1.5, 2.5 };
        Console.WriteLine($"Array Addition: [{string.Join(", ", Add(arrayA, arrayB))}]");

        int[,] matrixA = { { 1, 2 }, { 3, 4 } };
        int[,] matrixB = { { 5, 6 }, { 7, 8 } };
        var resultMatrix = Add(matrixA, matrixB);

        Console.WriteLine("Matrix Addition:");
        for (int i = 0; i < resultMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < resultMatrix.GetLength(1); j++)
            {
                Console.Write(resultMatrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
