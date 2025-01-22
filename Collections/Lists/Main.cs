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
        }
    }
}
