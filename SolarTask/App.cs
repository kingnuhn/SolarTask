﻿namespace SolarTask
{
    public class App
    {
        public App()
        {
            Menu();
        }

        void Menu()
        {
            while (true)
            {
                Console.WriteLine("Выберите пункт меню:" +
                                  "\n1. Отобразить список всех дней рождения" +
                                  "\n2. Отобразить ближайшие и сегодняшние дни рождения" +
                                  "\n3. Добавить запись" +
                                  "\n4. Удалить запись" +
                                  "\n5. Редактировать запись" +
                                  "\n0. Закрыть программу");

                int userChoice = new int();
                try
                {
                    userChoice = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Некорректное значение");
                    continue;
                }

                switch (userChoice)
                {
                    case 1:
                        SelectAllPerson();
                        break;
                    case 2:
                        DisplayNearest();
                        break;
                    case 3:
                        AddnewPerson();
                        break;
                    case 4:
                        RemovePerson();
                        break;
                    case 5:

                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Вы ввели неверный пункт меню.");
                        break;
                }
            }

        }

        void SelectAllPerson()
        {
            using BirthdayDbContext db = new BirthdayDbContext();

            var persons = db.Persons.ToList();

            foreach (var person in persons)
            {
                Console.WriteLine($"{person.Name} {person.Birthday}");
            }

        }

        void AddnewPerson()
        {
            using BirthdayDbContext db = new BirthdayDbContext();
            Console.WriteLine("Введите имя");
            var name = Console.ReadLine();
            Console.WriteLine("Введите дату");
            DateTime Birthday = DateTime.Parse(Console.ReadLine());

            var newPerson = new Person { Name = name, Birthday = Birthday };
            db.Add(newPerson);
            db.SaveChanges();

        }

        void RemovePerson()
        {
            using BirthdayDbContext db = new BirthdayDbContext();
            Console.WriteLine("Введите номер записи");
            var n = new int();
            n = int.Parse(Console.ReadLine());
            var Person = db.Persons.Find(n);
            db.Remove(Person);
            db.SaveChanges();

            Console.WriteLine("Данные удалены");

        }

        void DisplayNearest()
        {
            using BirthdayDbContext db = new BirthdayDbContext();
            var today = DateTime.Today;
            DateTime rangeEnd = today.AddDays(10);
            var nears = db.Persons.Where(b => b.Birthday.DayOfYear >= today.DayOfYear && b.Birthday.DayOfYear <= rangeEnd.DayOfYear)
                .OrderBy(d => d.Birthday.DayOfYear)
                .ToList();

            foreach (var chelovek in nears)
            {
                Console.WriteLine($"{chelovek.Name} {chelovek.Birthday}");
            }

        }




















    }








}
