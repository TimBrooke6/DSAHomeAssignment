//Use the code in this class to prove that the SplitMix64 PRNG implemented is 
//indeed correct and intractable as described in Task 2 of the Assignment Brief

using System;
using System.Collections.Generic;
using System.Diagnostics;
using DSA___A2___Part_Soution;

class Program
{
    static void Main(string[] args)
    {
        SplitMix64 rng = new SplitMix64();
        List<ulong> randomNumbers = new List<ulong>();

        for (int i = 0; i < 100; i++)
        {
            randomNumbers.Add(rng.Next(1, 1000));
        }

        Console.WriteLine("Generated Random Numbers:");
        foreach (var number in randomNumbers)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine("\n");

        bool inRange = true;
        foreach (var number in randomNumbers)
        {
            if (number < 1 || number > 1000)
            {
                inRange = false;
                break;
            }
        }

        bool ascending = true;
        for (int i = 1; i < randomNumbers.Count; i++)
        {
            if (randomNumbers[i] < randomNumbers[i - 1])
            {
                ascending = false;
                break;
            }
        }

        bool descending = true;
        for (int i = 1; i < randomNumbers.Count; i++)
        {
            if (randomNumbers[i] > randomNumbers[i - 1])
            {
                descending = false;
                break;
            }
        }

        Console.WriteLine("Validation Results:");
        Console.WriteLine($"- All numbers in range 1–1000: {inRange}");
        Console.WriteLine($"- Not sorted in ascending order: {!ascending}");
        Console.WriteLine($"- Not sorted in descending order: {!descending}");

        int[] sizes = { 1000, 10000, 100000, 1000000 };
        foreach (int size in sizes)
        {
            List<ulong> testNumbers = new List<ulong>();
            Stopwatch sw = new Stopwatch();

            sw.Start();
            for (int i = 0; i < size; i++)
            {
                testNumbers.Add(rng.Next(1, 1000));
            }
            sw.Stop();

            Console.WriteLine($"Generated {size} numbers in {sw.ElapsedMilliseconds} ms");
        }
    }
}
