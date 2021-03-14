using System;

namespace Generic
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var intArray = new GenericArray<int>();

            intArray.Add(5);
            intArray.Add(1);
            intArray.Add(5);
            intArray.Add(13);
            intArray.Add(4);
            intArray.Add(10);
            intArray.Sort();
            intArray[1] += 3;
            ConsoleLog(intArray, "Get sorted array");

            intArray.RemoveAt(1);
            ConsoleLog(intArray, "Remove item by index");

            intArray.Remove(10);
            intArray.Remove(13);
            ConsoleLog(intArray, "Remove item by value");

            intArray.AddRange(new[] { 5, 10, 6, 7, 68, 89, 365 });
            ConsoleLog(intArray, "Add range of array");

            var array = new GenericArray<int>(165, 15, 212, 488);
            intArray.AddRange(array);
            intArray.Sort();
            ConsoleLog(intArray, "Add range of collection");

            Console.ReadLine();
        }

        public static void ConsoleLog<T>(GenericArray<T> array, string title)
        {
            Console.WriteLine(title);
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
        }
    }
}
