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


    }
    static void ProcessFile(string fileName, List<int> validProducts, List<string> noFiles, List<string> badDataFiles, List<string> overflowFiles)
    {
        try
        {
            string[] lines = File.ReadAllLines(fileName);
            int firstNumber, secondNumber;

            if (!int.TryParse(lines[0], out firstNumber) || !int.TryParse(lines[1], out secondNumber))
            {
                badDataFiles.Add(fileName);
                return;
            }

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
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка при обробці файлу {fileName}: {ex.Message}");
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


}