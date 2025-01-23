using System;
using System.Collections.Generic;
using static CSLab.CoreTypes.Interfaces.Vehicle;

namespace CSLab.Collections.Lists
{
    public class Main
    {
        public static void Run()
        {
            List<string> bookTitles = new()
            {
                "To Kill a Mockingbird",
                "War and Peace"
            };

            Console.WriteLine($"Initial capacity: {bookTitles.Capacity}, current count: {bookTitles.Count}"); // Initial capacity: 4, current count: 2

            bookTitles.Add("Brave New World");            
            bookTitles.AddRange([ "Pride and Prejudice", "The Secret Garden", "The Alchemist"]);

            Console.WriteLine($"Extended dynamic capacity: {bookTitles.Capacity}, current count: {bookTitles.Count}"); // Extended dynamic capacity: 8, current count: 6

            var slicedBooks = bookTitles.GetRange(1, 3);
            Console.WriteLine(string.Join(", ", slicedBooks)); // War and Peace, Brave New World, Pride and Prejudice

            slicedBooks.Insert(1, "The Forgotten Key"); // War and Peace, The Forgotten Key, Brave New World, Pride and Prejudice
            slicedBooks.Remove("Brave New World"); // War and Peace, The Forgotten Key, Pride and Prejudice
            slicedBooks.RemoveAt(2); // War and Peace, The Forgotten Key
            slicedBooks.InsertRange(2, ["The Great Gatsby", "Crime and Punishment"]); // War and Peace, The Forgotten Key, The Great Gatsby, Crime and Punishment
            slicedBooks.RemoveRange(1, 2); // War and Peace, Crime and Punishment

            bookTitles.RemoveAll(new Predicate<string>(book => book.Length > 16));
            Console.WriteLine(string.Join(", ", bookTitles)); // War and Peace, Brave New World, The Alchemist
            foreach(var book in bookTitles) Console.WriteLine(book.Length); // 13, 15, 13

            slicedBooks.Clear();
            Console.WriteLine(slicedBooks.Count); // 0

            slicedBooks = bookTitles.FindAll(book => book.Length < 15); // War and Peace, The Alchemist
            slicedBooks.InsertRange(2, ["A World History of War Crimes", "Dark Alchemy"]);

            Console.WriteLine(slicedBooks.IndexOf("A World History of War Crimes")); // 2

            Console.WriteLine(slicedBooks.Find(book => book.Contains("Alchem"))); // The Alchemist            
            Console.WriteLine(slicedBooks.FindIndex(book => book.Contains("Alchem"))); // 1
            Console.WriteLine(slicedBooks.FindLast(book => book.Contains("Alchem"))); // Dark Alchemy
            Console.WriteLine(slicedBooks.FindLastIndex(book => book.Contains("Alchem"))); // 3

            Console.WriteLine(slicedBooks.Exists(book => book.Contains("Alchemist"))); // True
            Console.WriteLine(slicedBooks.TrueForAll(book => book.Length > 10)); // True

            List<int> numbers = [ 1, 3, 7, 11, 5, 9 ];

            numbers.Sort(); // 1, 3, 5, 7, 9, 11
            int findNumber9Index = numbers.BinarySearch(9);
            Console.WriteLine(findNumber9Index); // 4

            int[] numbersSliced = new int[6];
            numbers.CopyTo(numbersSliced, 0);
            Console.WriteLine(string.Join(", ", numbersSliced)); // // 1, 3, 5, 7, 9, 11

            numbers.Reverse();
            Console.WriteLine(string.Join(", ", numbers)); // 11, 9, 7, 5, 3, 1

            List<double> farenheitTemps = [32, 68, 104];
            List<double> celsiusTemps = farenheitTemps.ConvertAll(temp => (temp - 32) * 5 / 9);
            Console.WriteLine(string.Join(", ", celsiusTemps)); // 0, 20, 40
        }
    }
}
