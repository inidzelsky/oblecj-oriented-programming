﻿using System;
using System.Linq;
using System.Collections.Generic;


namespace ShipTransfer
{ 
    public class River
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }
        public int MaxWidth { get; set; }
        public int Tributaries { get; set; }
        
        public override string ToString()
        {
            return $"{{Назва: {Name} | Довжина: {Length} | Максимальна ширина: {MaxWidth} | Притоки: {Tributaries}}}";
        }
    }

    public class Sea
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Square { get; set; }

        public override string ToString()
        {
            return $"{{Назва: {Name} | Площа: {Square}}}";
        }
    }

    public class Ship
    {
        public int Id { get; set; }

        public int Passengers { get; set; }
        public int Year { get; set; }
        public string Name { get; set; }
        public bool SeaType { get; set; }

        public override string ToString()
        {
            return $"{{ Ім'я: {Name} | Побудований: {Year} | Морський: {SeaType} | Пасажири: {Passengers} }}";
        }
    }

    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int WaterId { get; set; }

        public override string ToString()
        {
            return $"Company name: {Name}";
        }
    }

    public class ShipOfCompany
    {
        public int ShipId { get; set; }
        public int CompanyId { get; set; }
    }

    public class TransferInfo
    {
        private List<Company> _companies = new List<Company>
        {
            new Company {Id = 1, WaterId = 1, Name = "Чорноморське морське пароплавство"},
            new Company {Id = 2, WaterId = 2, Name = "Азовське морське пароплавство"},
            new Company {Id = 3, WaterId = 3, Name = "Українське Дунайське пароплавство"},
            new Company {Id = 4, WaterId = 4, Name = "Волжське пароплавство"}
        };
        
        private List<Ship> _ships = new List<Ship>
        {
            new Ship {Id = 1, Name = "Ленінгірськ", Year = 1958, SeaType = true, Passengers = 51},
            new Ship {Id = 2, Name = "Алупка", Year = 1965, SeaType = true, Passengers = 212},
            new Ship {Id = 3, Name = "Киргизстан", Year = 1963, SeaType = true, Passengers = 316},
            new Ship {Id = 4, Name = "Михайло Калінін", Year = 1964, SeaType = true, Passengers = 333},
            new Ship {Id = 5, Name = "Астор", Year = 1986, SeaType = true, Passengers = 650},
            new Ship {Id = 6, Name = "Lev Tolstoy", Year = 1981, SeaType = true, Passengers = 710},
            new Ship {Id = 7, Name = "Нежин", Year = 1954, SeaType = true, Passengers = 54},
            new Ship {Id = 8, Name = "Адмірал Лунін", Year = 1965, SeaType = true, Passengers = 200},
            new Ship {Id = 9, Name = "Хвиля", Year = 1987, SeaType = false, Passengers = 170},
            new Ship {Id= 10, Name = "ТМІ-4", Year = 1990, SeaType = false, Passengers = 0},
            new Ship {Id = 11, Name = "RSD-44", Year = 2000, SeaType = false, Passengers = 0},
            new Ship {Id = 12, Name = "Дунайський", Year = 1980, SeaType = false, Passengers = 0}
        };
        
        private List<ShipOfCompany> _shipOfCompany = new List<ShipOfCompany>
        {
            new ShipOfCompany {ShipId = 2, CompanyId = 1},
            new ShipOfCompany {ShipId = 3, CompanyId = 1},
            new ShipOfCompany {ShipId = 4, CompanyId = 1},
            new ShipOfCompany {ShipId = 5, CompanyId = 1},
            new ShipOfCompany {ShipId = 6, CompanyId = 1},
            new ShipOfCompany {ShipId = 7, CompanyId = 1},
            new ShipOfCompany {ShipId = 7, CompanyId = 2},
            new ShipOfCompany {ShipId = 8, CompanyId = 2},
            new ShipOfCompany {ShipId = 9, CompanyId = 2},
            new ShipOfCompany {ShipId = 9, CompanyId = 3},
            new ShipOfCompany {ShipId = 10, CompanyId = 3},
            new ShipOfCompany {ShipId = 10, CompanyId = 4},
            new ShipOfCompany {ShipId = 11, CompanyId = 3},
            new ShipOfCompany {ShipId = 11, CompanyId = 4},
            new ShipOfCompany {ShipId = 12, CompanyId = 4}
        };
        
        private List<Sea> _seas = new List<Sea>
        {
            new Sea {Id = 1, Name = "Чорне море", Square = 437000},
            new Sea {Id = 2, Name = "Азовське море", Square = 39000}
        };
        
        private List<River> _rivers = new List<River>
        {
            new River {Id = 3, Name = "Дунай", Length = 2860, MaxWidth = 150, Tributaries = 17},
            new River {Id = 4, Name = "Волга", Length = 3530, MaxWidth = 40, Tributaries = 7}
        };

        // #1
        public void SelectShips()
        {
            var ships = from s in _ships
                select s;

            foreach (var ship in ships)
            {
                Console.WriteLine(ship);   
            }
        }

        public void SelectLongRivers()
        {
            var longRivers = _rivers.Where(r => r.Length > 3000);

            foreach (var river in longRivers)
            {
                Console.WriteLine(river);   
            }
        }

        // #2
        public void SelectOrderedCompanies()
        {
            var companies = _companies.OrderBy(c => c.Name);

            foreach (var company in companies)
            {
                Console.WriteLine(company);   
            }
        }

        public void SelectIsPassengerShip()
        {
            var ships = from ship in _ships
                select new {Ship = ship, isPassenger = (ship.Passengers > 0)};
            
            Console.WriteLine("Describes whether the ship is for passangers");
            foreach (var pair in ships)
            {
                Console.WriteLine($"Ship name: {pair.Ship.Name} | Is for passengers: {pair.isPassenger}");   
            }
            Console.WriteLine();
        }
        
        // #3
        public void SelectWater()
        {
            var waters = _seas.Select(sea => sea.ToString())
                                               .Union(_rivers.Select(river => river.ToString()));

            foreach (var water in waters)
            {
                Console.WriteLine(water);
            }
        }

        public void SelectGroupShipsByYear()
        {
            var ships = from ship in _ships
                group ship by ship.Year;
            
            Console.WriteLine("Ships grouped by years");

            foreach (var tuple in ships)
            {
                Console.WriteLine($"Year: {tuple.Key}");
                
                foreach (var ship in tuple)
                {
                    Console.WriteLine($"  {ship}");
                }
                
                Console.WriteLine();
            }
        }
        
        // #4 Inner join returns connected shipping and sea names
        public void SelectSeaCompanies()
        {
            var companies = from company in _companies
                join sea in _seas on company.WaterId equals sea.Id
                select new {Company = company.Name, Sea = sea.Name};
                

            foreach (var pair in companies)
            {
                Console.WriteLine($"Company: {pair.Company} | Sea: {pair.Sea}");
            }
        }
        
        // #5 Left-join
        public void SelectAllShipsWithShippings()
        {
            var allShipsWithShippings = from ship in _ships
                join link in _shipOfCompany on ship.Id equals link.ShipId into temp
                from t1 in temp.DefaultIfEmpty()
                join shipping in _companies on t1?.CompanyId equals shipping.Id into temp2
                from t2 in temp2.DefaultIfEmpty()
                select new {Ship = ship.Name, Shipping = (t2 == null) ? "null" : t2.Name};

            foreach (var tuple in allShipsWithShippings)
            {
                Console.WriteLine($"{tuple.Ship} - {tuple.Shipping}");
            }

        }

        // #6 Many-to-many connection
        public void SelectShipOfShipping()
        {
            var shipOfShipping = from ship in _ships
                join link in _shipOfCompany on ship.Id equals link.ShipId into temp
                from t in temp
                join shipping in _companies on t.CompanyId equals shipping.Id
                select new {Ship = ship, Shipping = shipping};

            foreach (var tuple in shipOfShipping)
            {
                Console.WriteLine(tuple.Ship);
                Console.WriteLine(tuple.Shipping);
                Console.WriteLine();
            }
        }

        public void SelectGroupShipsByCompanies()
        {
            var shipGroups = 
                _companies.GroupJoin(
                    _ships.Join(_shipOfCompany,
                    ship => ship.Id,
                    link => link.ShipId,
                    (ship, link) => new {Ship = ship, CompanyId = link.CompanyId}),
                company => company.Id,
                pair => pair.CompanyId,
                (company, pairs) => new {Company = company, Ships = pairs});

            Console.WriteLine("Grouped ships by companies: ");
            foreach (var pair in shipGroups)
            {
                Console.WriteLine(pair.Company);
                
                foreach (var item in pair.Ships)
                {
                    Console.WriteLine($"  {item.Ship}");
                }
                
                Console.WriteLine();
            }
        }

        public void SelectShipsUnion()
        {
            var ships = 
                (from ship in _ships
                where ship.Name.StartsWith("А")
                select ship).Union(from ship in _ships
                where ship.Name.StartsWith("Д")
                select ship);
            
            Console.WriteLine("Ships with names start with \"А\" and \"Д\"");
            foreach (var ship in ships)
            {
                Console.WriteLine(ship);
            }
            Console.WriteLine();
        }

        public void SelectAvarageShipsAge()
        {
            int averageShipsAge = Convert.ToInt32(_ships.Average(ship => ship.Year));
            
            Console.WriteLine($"Average age of ships is {averageShipsAge}");
            Console.WriteLine();
        }

        public void SelectLargestSea()
        {
            var largestSea = _seas.Where(sea => sea.Square == _seas.Max(sea => sea.Square));
            
            Console.WriteLine(largestSea.First());
            Console.WriteLine();
        }

        public void SelectIfShipsAfterWar()
        {
            bool ifShipsAfterWar = _ships.All(ship => ship.Year > 1945);
            
            if (ifShipsAfterWar)
                Console.WriteLine("All of the ships in the database are after the Civil War 2");
            else
                Console.WriteLine("Not all ships were built before 1945");
            
            Console.WriteLine();
        }

        public void SelectSkipTo()
        {
            var ships = _ships.TakeWhile(ship => ship.Name != "Lev Tolstoy");
            
            Console.WriteLine($"Takes all the ships before \"Lev Tolstoy\"");

            foreach (var ship in ships)
            {
                Console.WriteLine(ship);
            }
            
            Console.WriteLine();
        }
        
    }

    class Program
    {
        static void Main(string[] args)
        {
            var transferInfo = new TransferInfo();
            transferInfo.SelectSkipTo();
        }
    }
}