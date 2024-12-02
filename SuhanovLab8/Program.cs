using System.Diagnostics;

public class Program
{
    public static void Main(string[] args)
    {
        // Параметры для тестирования
        string testFile10K = "input_10k.txt";
        string testFile1M = "input_1m.txt";
        string outputFile = "output.txt";

        // Генерация тестовых файлов
        GenerateTestFile(testFile10K, 10000);
        GenerateTestFile(testFile1M, 1000000);

        // Создание объекта NumberProcessor
        var processor = new NumberProcessor();

        // Тест с 10,000 чисел
        Console.WriteLine("Testing with 10,000 numbers...");
        processor.ProcessNumbers(testFile10K, outputFile);

        // Тест с 1,000,000 чисел
        Console.WriteLine("Testing with 1,000,000 numbers...");
        processor.ProcessNumbers(testFile1M, outputFile);
    }

    private static void GenerateTestFile(string filePath, int count)
    {
        var random = new Random();
        var numbers = Enumerable.Range(1, count).Select(_ => random.Next(1, 1000000));
        File.WriteAllLines(filePath, numbers.Select(n => n.ToString()));
        Console.WriteLine($"Test file '{filePath}' with {count} numbers created.");
    }
}