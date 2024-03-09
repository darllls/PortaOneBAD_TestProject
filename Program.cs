using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        string filePath = "D:\\Мої документи\\edu\\PortaOneBAD_TestProject\\10m.txt";

        if (File.Exists(filePath))
        {
            List<int> numbers = File.ReadLines(filePath).Select(int.Parse).ToList();


            FindStatistics(numbers);

            FindIncreasingSequence(numbers);
            FindDecreasingSequence(numbers);
        }
        else
        {
            Console.WriteLine("Файл не існує.");
        }
    }

    static void FindStatistics(List<int> numbers)
    {
        Parallel.ForEach(numbers, num => { });

        int maxNumber = FindMax(numbers);
        int minNumber = FindMin(numbers);
        double median = FindMedian(numbers);
        double average = FindAverage(numbers);

        Console.WriteLine($"Максимальне число: {maxNumber}");
        Console.WriteLine($"Мінімальне число: {minNumber}");
        Console.WriteLine($"Медіана: {median}");
        Console.WriteLine($"Середнє арифметичне: {average}");
    }

    static int FindMax(List<int> numbers)
    {
        int max = numbers[0];
        foreach (int num in numbers)
        {
            if (num > max)
            {
                max = num;
            }
        }
        return max;
    }

    static int FindMin(List<int> numbers)
    {
        int min = numbers[0];
        foreach (int num in numbers)
        {
            if (num < min)
            {
                min = num;
            }
        }
        return min;
    }

    static double FindMedian(List<int> numbers)
    {
        int length = numbers.Count;
        List<int> sortedNumbers = numbers.OrderBy(n => n).ToList();

        if (length % 2 == 0)
        {
            int middle1 = sortedNumbers[length / 2 - 1];
            int middle2 = sortedNumbers[length / 2];
            return (middle1 + middle2) / 2.0;
        }
        else
        {
            return sortedNumbers[length / 2];
        }
    }

    static double FindAverage(List<int> numbers)
    {
        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }
        return (double)sum / numbers.Count;
    }

    static void FindIncreasingSequence(List<int> numbers)
    {
        List<int> currentSequence = new List<int>();
        List<int> maxSequence = new List<int>();

        for (int i = 0; i < numbers.Count - 1; i++)
        {
            if (numbers[i] < numbers[i + 1])
            {
                currentSequence.Add(numbers[i]);
            }
            else
            {
                currentSequence.Add(numbers[i]);

                if (currentSequence.Count > maxSequence.Count)
                {
                    maxSequence = new List<int>(currentSequence);
                }

                currentSequence.Clear();
            }
        }

        Console.WriteLine("Найбільша послідовність чисел, яка збільшується: " + string.Join(", ", maxSequence));
    }

    static void FindDecreasingSequence(List<int> numbers)
    {
        List<int> currentSequence = new List<int>();
        List<int> maxSequence = new List<int>();

        for (int i = 0; i < numbers.Count - 1; i++)
        {
            if (numbers[i] > numbers[i + 1])
            {
                currentSequence.Add(numbers[i]);
            }
            else
            {
                currentSequence.Add(numbers[i]);

                if (currentSequence.Count > maxSequence.Count)
                {
                    maxSequence = new List<int>(currentSequence);
                }

                currentSequence.Clear();
            }
        }

        Console.WriteLine("Найбільша послідовність чисел, яка зменшується: " + string.Join(", ", maxSequence));
    }
}
