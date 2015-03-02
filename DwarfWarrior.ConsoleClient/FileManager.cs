﻿namespace DwarfWarrior.ConsoleClient
{
    using System.IO;

    public static class FileManager
    {
        public static char[,] TextFileToCharMatrix(string filePath)
        {
            var reader = new StreamReader(filePath);

            using (reader)
            {
                int matrixRows = int.Parse(reader.ReadLine());
                int matrixCols = int.Parse(reader.ReadLine());

                char[,] matrix = new char[matrixRows, matrixCols];

                for (int row = 0; row < matrixRows; row++)
                {
                    string currentRow = reader.ReadLine();

                    for (int col = 0; col < matrixCols; col++)
                    {
                        matrix[row, col] = currentRow[col];
                    }
                }

                return matrix;
            }
        }
    }
}