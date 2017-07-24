using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EndavaInternship.ConsoleApp
{
    internal class Program
    {
        private const string UsersDropFolder = "d:\\DropFolderComplex\\Users\\";
        private const string AddressDropFolder = "d:\\DropFolderComplex\\Address\\";

        private static readonly Random Random = new Random();

        private static void Main(string[] args)
        {
            GenerateRandomClientFiles();
        }

        private static void GenerateRandomClientFiles()
        {
            if (!Directory.Exists(UsersDropFolder))
                Directory.CreateDirectory(UsersDropFolder);

            if (!Directory.Exists(AddressDropFolder))
                Directory.CreateDirectory(AddressDropFolder);

            Parallel.For(0, 5000, i =>
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

                if (i<10)
                {
                    WriteToFileInvalidAddress(client);
                    return;
                }

                if (i >= 10 && i < 17)
                {
                    WriteToFileInvalidEmail(client);
                    return;
                }

                if (i >= 17 && i < 26)
                {
                    WriteToFileInvalidId(client);
                    return;
                }

                if (i >= 26 && i < 30)
                {
                    WriteToFileInvalidDate(client);
                    return;
                }

                WriteToFile(client);
                CreateAddressFile(client);
            });
        }

        private static void CreateAddressFile(Client client)
        {
            var file = new StreamWriter(AddressDropFolder + client.AddressId);
            file.WriteLine(RandomString(100));
            file.Close();
        }

        private static void WriteToFileInvalidDate(Client client)
        {
            var file = new StreamWriter(UsersDropFolder + client.Id);

            file.WriteLine(client.Name);
            file.WriteLine(client.Email);
            file.WriteLine(client.BirthDate.Year + " " + client.BirthDate.Month + " " );
            file.WriteLine(client.AddressId);
            file.WriteLine(client.Description);

            file.Close();
        }

        private static void WriteToFileInvalidId(Client client)
        {
            var file = new StreamWriter(UsersDropFolder + client.Id + "1");

            file.WriteLine(client.Name);
            file.WriteLine(client.Email);
            file.WriteLine(client.BirthDate.Year + " " + client.BirthDate.Month + " " + client.BirthDate.Day);
            file.WriteLine(client.AddressId);
            file.WriteLine(client.Description);

            file.Close();
        }

        private static void WriteToFileInvalidEmail(Client client)
        {
            var file = new StreamWriter(UsersDropFolder + client.Id);

            file.WriteLine(client.Name);
            file.WriteLine();
            file.WriteLine(client.BirthDate.Year + " " + client.BirthDate.Month + " " + client.BirthDate.Day);
            file.WriteLine(client.AddressId);
            file.WriteLine(client.Description);

            file.Close();
        }

        private static void WriteToFileInvalidAddress(Client client)
        {
            var file = new StreamWriter(UsersDropFolder + client.Id);

            file.WriteLine(client.Name);
            file.WriteLine(client.Email);
            file.WriteLine(client.BirthDate.Year + " " + client.BirthDate.Month + " " + client.BirthDate.Day);
            file.WriteLine(client.AddressId + "123");
            file.WriteLine(client.Description);

            file.Close();
        }

        private static void WriteToFile(Client client)
        {
            var file = new StreamWriter(UsersDropFolder + client.Id);

            file.WriteLine(client.Name);
            file.WriteLine(client.Email);
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
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";

            var randomString = new string(Enumerable.Repeat(chars, length)
                .Select(s => s[Random.Next(s.Length)]).ToArray());

            if (string.IsNullOrEmpty(randomString))
                return string.Empty;

            return char.ToUpper(randomString[0]) + randomString.Substring(1).ToLower();
        }
    }
}