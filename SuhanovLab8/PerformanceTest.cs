using System;
using System.IO;
using System.Linq;
using System.Diagnostics;

public class NumberProcessor
{
    public void ProcessNumbers(string inputFilePath, string outputFilePath)
    {
        try
        {
            // Замер времени и начального объема памяти
            var stopwatch = Stopwatch.StartNew();
            long initialMemory = GC.GetTotalMemory(true); // Память до выполнения

            // Обработка чисел: чтение, фильтрация, сортировка
            var numbers = File.ReadAllLines(inputFilePath)
                              .Select(int.Parse)
                              .Distinct()
                              .OrderBy(n => n)
                              .ToList();

            // Запись результата в файл
            File.WriteAllLines(outputFilePath, numbers.Select(n => n.ToString()));

            // Замеры после выполнения
            stopwatch.Stop();
            long finalMemory = GC.GetTotalMemory(true); // Память после выполнения

            // Вывод результатов в консоль
            Console.WriteLine($"Processing complete. Results saved to {outputFilePath}");
            Console.WriteLine($"Time taken: {stopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine($"Memory used: {(finalMemory - initialMemory) / 1024 / 1024} MB");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}