using System;
using System.Linq;

namespace Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int comandsNumber = int.Parse(Console.ReadLine());

            int positionRow = -1;
            int positionColumn = -1;

            char[,] field = new char[matrixSize, matrixSize];

            bool isWon = false;

            for (int i = 0; i < matrixSize; i++)
            {
                string nextLine = Console.ReadLine();
                
                for (int j = 0; j < matrixSize; j++)
                {
                    char nextFieldElement = nextLine[j];
                    
                    if(nextLine[j] == 'f')
                    {
                        positionRow = i;
                        positionColumn = j;
                    }

                    field[i, j] = nextLine[j];
                }
            }

            for (int i = 1; i <= comandsNumber; i++)
            {
                string nextComand = Console.ReadLine();
                field[positionRow, positionColumn] = '-';

                switch (nextComand.ToUpper())
                {
                    case "LEFT":
                        positionColumn--;
                        if (positionColumn < 0)
                        {
                            positionColumn = matrixSize - 1;
                        }
                        if(field[positionRow, positionColumn] == 'T')
                        {
                            positionColumn++;
                        }
                        if (field[positionRow, positionColumn] == 'B')
                        {
                            positionColumn--;
                            if (positionColumn < 0)
                            {
                                positionColumn = matrixSize - 1;
                            }
                        }
                        break;

                    case "RIGHT":
                        positionColumn++;
                        if (positionColumn == matrixSize)
                        {
                            positionColumn = 0;
                        }
                        if (field[positionRow, positionColumn] == 'T')
                        {
                            positionColumn--;
                        }
                        if (field[positionRow, positionColumn] == 'B')
                        {
                            positionColumn++;
                            if (positionColumn == matrixSize)
                            {
                                positionColumn = 0;
                            }
                        }
                        break;

                    case "UP":
                        positionRow--;
                        if (positionRow < 0)
                        {
                            positionRow = matrixSize - 1;
                        }
                        if (field[positionRow, positionColumn] == 'T')
                        {
                            positionRow++;
                        }
                        if (field[positionRow, positionColumn] == 'B')
                        {
                            positionRow--;
                            if (positionRow < 0)
                            {
                                positionRow = matrixSize - 1;
                            }
                        }
                        break;

                    case "DOWN":
                        positionRow++;
                        if (positionRow == matrixSize)
                        {
                            positionRow = 0;
                        }
                        if (field[positionRow, positionColumn] == 'T')
                        {
                            positionRow--;
                        }
                        if (field[positionRow, positionColumn] == 'B')
                        {
                            positionRow++;
                            if (positionRow == matrixSize)
                            {
                                positionRow = 0;
                            }
                        }
                        break;
                    
                    default:
                        break;
                }

                if (field[positionRow, positionColumn] == 'F')
                {
                    isWon = true;
                }

                field[positionRow, positionColumn] = 'f';

                if(isWon)
                {
                    break;
                }

            }

            // print field

            if(isWon)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }


            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    Console.Write(field[i, j]);
                }

                Console.WriteLine();
            }



            //Console.WriteLine("Hello World!");
        }
    }
}
