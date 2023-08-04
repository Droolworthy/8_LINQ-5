//Есть набор тушенки. У тушенки есть название, год производства и срок годности.
//Написать запрос для получения всех просроченных банок тушенки.
//Чтобы не заморачиваться, можете думать, что считаем только года, без месяцев.
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ5
{
    internal class Program
    {
        static void Main()
        {
            Warehouse warehouse = new Warehouse();

            warehouse.Work();
        }
    }

    class Warehouse
    {
        private List<Stew> _stews = new List<Stew>();

        public Warehouse()
        {
            AddStews();
        }

        public void Work()
        {
            bool isWork = true;

            int year = 2023;

            string commandShowExpiredStew = "1";
            string commandExit = "2";

            Console.WriteLine("ПОКАЗАТЬ ПРОСРОЧЕННУЮ ТУШЁНКУ - " + commandShowExpiredStew);
            Console.WriteLine("ВЫХОД - " + commandExit);

            while (isWork)
            {
                Console.Write("\nВвод: ");
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int number))
                {
                    if (userInput == commandShowExpiredStew)
                    {
                        _stews = _stews.Where(stew => stew.YearOfProduction + stew.ExpirationDate < year).ToList();

                        ShowFilteredStews(_stews);
                    }
                    else if (userInput == commandExit)
                    {
                        isWork = false;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка. Попробуйте ещё раз.");
                    }
                }
            }
        }

        private void AddStews()
        {
            _stews.Add(new Stew("Барс Экстра", 2021, 2));
            _stews.Add(new Stew("Березовский мясоконсервный комбинат", 2019, 4));
            _stews.Add(new Stew("Оршанский мясоконсервный комбинат", 2018, 4));
            _stews.Add(new Stew("Слоним", 2017, 5));
            _stews.Add(new Stew("Гродфуд свинина", 2018, 6));
            _stews.Add(new Stew("Совок", 2019, 4));
            _stews.Add(new Stew("Рузком Люкс", 2020, 10));
            _stews.Add(new Stew("Наша Свинина тушеная", 2021, 1));
        }

        private void ShowFilteredStews(IEnumerable<Stew> filteredStews)
        {
            foreach (var stew in filteredStews)
            {
                Console.WriteLine($"Имя - {stew.Name}, Год производства - {stew.YearOfProduction}, Срок годности - {stew.ExpirationDate} год(а)");
            }
        }
    }

    class Stew
    {
        public Stew(string appellation, int yearOfManufacture, int shelfLife)
        {
            Name = appellation;
            YearOfProduction = yearOfManufacture;
            ExpirationDate = shelfLife;
        }

        public string Name { get; private set; }
        public int YearOfProduction { get; private set; }
        public int ExpirationDate { get; private set; }
    }
}
