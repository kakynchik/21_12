namespace _21._12
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 14, 21, 35, 40, 49, 50, 63, 70, 100 };
            
            Func<int[], int> countMultiplesOfSeven = arr => arr.Count(num => num % 7 == 0);
            
            int count = countMultiplesOfSeven(numbers);

            Console.WriteLine($"Кількість чисел, кратних семи: {count}");
        }
    }
}