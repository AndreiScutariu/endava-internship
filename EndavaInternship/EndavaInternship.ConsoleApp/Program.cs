using System;
using System.IO;
using System.Linq;

namespace EndavaInternship.ConsoleApp
{
    internal class Program
    {
        private static readonly Random Random = new Random();

        private static void Main(string[] args)
        {
            GenerateRandomClientFiles();
        }

        private static void GenerateRandomClientFiles()
        {
            if (!Directory.Exists("d:\\UsersDropFolder"))
                Directory.CreateDirectory("d:\\UsersDropFolder");

            for (var i = 0; i < 10; i++)
            {
                var client = new Client
                {
                    Id = Guid.NewGuid().ToString(),
                    AddressId = Guid.NewGuid().ToString(),
                    Description = RandomString(30),
                    Email = RandomString(25),
                    Name = RandomString(20),
                    BirthDate = RandomDay()
                };

                WriteToFile(client);

                Console.WriteLine(i);
            }
        }

        private static void WriteToFile(Client client)
        {
            var file = new StreamWriter("d:\\UsersDropFolder\\" + client.Id);

            file.WriteLine(client.Name);
            file.WriteLine();
            file.WriteLine(client.BirthDate.Year + " " + client.BirthDate.Month + " " + client.BirthDate.Day);
            file.WriteLine(client.AddressId);
            file.WriteLine(client.Description);

            file.Close();
        }

        private static DateTime RandomDay()
        {
            var start = new DateTime(1995, 1, 1);
            var gen = new Random();
            var range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }

        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            var randomString = new string(Enumerable.Repeat(chars, length)
                .Select(s => s[Random.Next(s.Length)]).ToArray());

            if (string.IsNullOrEmpty(randomString))
                return string.Empty;

            return char.ToUpper(randomString[0]) + randomString.Substring(1).ToLower();
        }
    }
}