using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;


class Program 
{
    static void Main() 
    {
        // Списки для збереження результатів
        List<int> validProducts = new List<int>();
        List<string> noFiles = new List<string>();
        List<string> badDataFiles = new List<string>();
        List<string> overflowFiles = new List<string>();

        for (int i = 10; i < 30; i++)
        {
            string fileName = $"{i}.txt";
            ProcessFile(fileName, validProducts, noFiles, badDataFiles, overflowFiles);

        }
        SaveResults(noFiles, badDataFiles, overflowFiles);
        DisplayResults(noFiles, badDataFiles, overflowFiles, validProducts);
    }
    static void ProcessFile(string fileName, List<int> validProducts, List<string> noFiles, List<string> badDataFiles, List<string> overflowFiles)
    {
        try
        {
            string[] lines = File.ReadAllLines(fileName);

            int firstNumber = int.Parse(lines[0]);
            int secondNumber = int.Parse(lines[1]);

            try
            {
                checked
                {
                    int product = firstNumber * secondNumber;
                    validProducts.Add(product);
                }
            }
            catch (OverflowException)
            {
                overflowFiles.Add(fileName);
            }
        }
        catch (FileNotFoundException)
        {
            noFiles.Add(fileName);
        }
        catch (FormatException)
        {
            badDataFiles.Add(fileName);
        }
    }
    static void SaveResults(List<string> noFiles, List<string> badDataFiles, List<string> overflowFiles)
    {
        try
        {
            File.WriteAllLines("no_file.txt", noFiles);
            File.WriteAllLines("bad_data.txt", badDataFiles);
            File.WriteAllLines("overflow.txt", overflowFiles);
        }
        catch (IOException ioEx)
        {
            Console.WriteLine($"Помилка запису файлу: {ioEx.Message}");
        }
    }
    static void DisplayResults(List<string> noFiles, List<string> badDataFiles, List<string> overflowFiles, List<int> validProducts)
    {
        Console.WriteLine(noFiles.Count > 0 ? "Файли, яких не існує:" : "Усі файли знайдено.");
        noFiles.ForEach(Console.WriteLine);

        Console.WriteLine(badDataFiles.Count > 0 ? "Файли з некоректними даними:" : "Некоректних даних не знайдено.");
        badDataFiles.ForEach(Console.WriteLine);

        Console.WriteLine(overflowFiles.Count > 0 ? "Файли з переповненням при множенні:" : "Переповнень не виявлено.");
        overflowFiles.ForEach(Console.WriteLine);

        try
        {
            double average = validProducts.Average();
            Console.WriteLine($"Середнє арифметичне коректних добутків: {average}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Жодного коректного добутку не знайдено.");
        }
    }



}