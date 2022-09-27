/*
Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2
*/

int rows = 0, columns = 0;
Random random = new Random();

if (!InputControl("Задайте размерность двумерного массива (m n)", ref rows, ref columns))
    return;

int[,] array = InitArray(rows, columns);
PrintArray(array);

DoWorkArray(array);

Console.WriteLine();

PrintArray(array);

# region methods

bool InputControl(string caption, ref int m, ref int n)
{
    int tryCount = 3;
    string inputStr = string.Empty;
    bool resultInputCheck = false;

    while (!resultInputCheck)
    {
        Console.WriteLine($"\r\n{caption} (количество попыток: {tryCount}):");
        inputStr = Console.ReadLine() ?? string.Empty;

        string[] inputStringArray = inputStr.Split(new char[] { ' ', ';' });

        resultInputCheck =
            inputStringArray.Length == 2 &&
            int.TryParse(inputStringArray[0], out m) &&
            m > 0 &&
            int.TryParse(inputStringArray[1], out n) &&
            n > 0;

        if (!resultInputCheck)
        {
            tryCount--;

            if (tryCount == 0)
            {
                Console.WriteLine("\r\nВы исчерпали все попытки.\r\nВыполнение программы будет остановлено.");
                return false;
            }
        }
    }

    return true;
}

int[,] InitArray(int m, int n)
{
    int[,] array = new int[m, n];

    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            array[i, j] = random.Next(0, 20);
        }
    }

    return array;
}

void DoWorkArray(int[,] array)
{            
    for (int row = 0; row < array.GetLength(0); row++)
    {
        for (int i = 0; i < array.GetLength(1); i++)
        {
            for (int j = 0; j < array.GetLength(1) - 1; j++)
            {
                if (array[row, j] < array[row, j + 1])
                {
                    int tmp = array[row, j + 1];
                    array[row, j + 1] = array[row, j];
                    array[row, j] = tmp;
                }
            }
        }
    } 
}

void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]}\t");
        }

        Console.WriteLine();
    }
}

# endregion
