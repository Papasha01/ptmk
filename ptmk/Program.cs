using ptmk;
using MySql.Data.MySqlClient;
using Google.Protobuf;
using System.Globalization;
using System;
using Microsoft.EntityFrameworkCore;
using EFCore.BulkExtensions;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        // args содержит параметры командной строки
        //Console.WriteLine("Количество параметров: " + args.Length);

        static int CalculateAge(DateTime birthDate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;
            if (today < birthDate.AddYears(age))
            {
                age--;
            }
            return age;
        }

        for (int i = 0; i < args.Length; i++)
        {
            switch (args[i])
            {
                case "1":
                    using (var context = new ApplicationContext())
                    {
                        context.Database.EnsureCreated();
                        Console.WriteLine("База данных и таблицы созданы.");
                    }
                    break;
                case "2":
                    User user = new User();

                    user.FIO = args[1];

                    DateTime dateTime = DateTime.ParseExact(args[2], "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    user.Birthday = dateTime;

                    if (args[3] == "Male")
                        user.Gender = true;
                    else
                        user.Gender = false;
                    using (var context = new ApplicationContext())
                    {
                        context.Add(user);
                        context.SaveChanges();
                    }
                    break;

                case "3":
                    using (var context = new ApplicationContext())
                    {
                        foreach (User customer in context.Users.OrderBy(p => p.FIO))
                            Console.WriteLine(customer.Id.ToString() + "\t"
                                + customer.FIO + "\t"
                                + customer.Birthday.ToString() + "\t"
                                + ((customer.Gender) ? "Мужчина" : "Женщина") + "\t Возвраст: "
                                + CalculateAge(customer.Birthday).ToString());
                    }
                    break;
                case "4":

                    {

                        User[] UserArray = new User[1000000];
                        User[] User100F = new User[100];
                        for (int j = 0; j < UserArray.Length; j++)
                        {
                            Random rnd = new Random();
                            if (rnd.Next(0, 2) > 0)
                            {
                                UserArray[j] = new User();
                                UserArray[j].FIO = "Ivanov Ivan Ivanovich";
                                UserArray[j].Birthday = DateTime.ParseExact("1999-05-23", "yyyy-MM-dd", CultureInfo.InvariantCulture);
                                UserArray[j].Gender = true;
                            }
                            else
                            {
                                UserArray[j] = new User();
                                UserArray[j].FIO = "Petrova Larisa Ivanovna";
                                UserArray[j].Birthday = DateTime.ParseExact("1983-02-02", "yyyy-MM-dd", CultureInfo.InvariantCulture);
                                UserArray[j].Gender = false;
                            }
                        }
                        for (int j = 0; j < User100F.Length; j++)
                        {
                            UserArray[j] = new User();
                            UserArray[j].FIO = "Farberov David Ivanovich";
                            UserArray[j].Birthday = DateTime.ParseExact("1983-02-02", "yyyy-MM-dd", CultureInfo.InvariantCulture);
                            UserArray[j].Gender = true;
                        }
                        using (var context = new ApplicationContext())
                        {
                            context.BulkInsert(UserArray);
                        }
                    }
                    break;
                case "5":
                    {
                        Stopwatch stopwatch = new Stopwatch();
                        using (var context = new ApplicationContext())
                        {
                            stopwatch.Start();
                            var ctx = context.Users.Where(g => g.FIO.StartsWith("F") && g.Gender == true).OrderBy(p => p.FIO);
                            stopwatch.Stop();
                            foreach (User customer in ctx)
                                Console.WriteLine(customer.Id.ToString() + "\t"
                                    + customer.FIO + "\t"
                                    + customer.Birthday.ToString() + "\t"
                                    + ((customer.Gender) ? "Мужчина" : "Женщина") + "\t Возвраст: "
                                    + CalculateAge(customer.Birthday).ToString());
                        }
                        Console.WriteLine("Время выполнения: " + stopwatch.ElapsedTicks.ToString() + " Ticks.");

                        break;
                    }
            }
        }
    }
}
