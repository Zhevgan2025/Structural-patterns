using System;
using ProxyForTheIbook;

namespace Task3_AccessControlProxy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var guest = new User("Guest", isRegistered: false, hasBookAcces: false);

            var student = new User("Student", isRegistered: true, hasBookAcces: true);

            Ibook guestBook = new BookProxy(guest, "Clean Code");
            Ibook studentBook = new BookProxy(student, "Clean Code");

            Console.WriteLine("=== Guest Access ===");
            Console.WriteLine(guestBook.GetContent());
            Console.WriteLine();

            Console.WriteLine("=== Student Access ===");
            Console.WriteLine(studentBook.GetContent());
            Console.WriteLine();

            Console.WriteLine("=== Repeated request from Student === ");
            Console.WriteLine(studentBook.GetContent());
            Console.WriteLine();

            Console.WriteLine("Done. Press any key...");
            Console.ReadKey();
        }
    }
}

