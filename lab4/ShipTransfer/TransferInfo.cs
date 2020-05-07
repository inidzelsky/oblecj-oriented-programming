using System;
using System.Collections.Generic;
using System.Linq;

namespace ShipTransfer
{
    public class TransferInfo
    {
        private List<Company> _companies = new List<Company>
        {
            new Company {Id = 1, WaterId = 1, Name = "Black sea shipping"},
            new Company {Id = 2, WaterId = 2, Name = "Azov sea shipping"},
            new Company {Id = 3, WaterId = 3, Name = "Danubian shipping of Ukraine"},
            new Company {Id = 4, WaterId = 4, Name = "Volga shipping"},
            new Company {Id = 5, WaterId = 4, Name = "Southern shipping of Russia"}
        };
        
        private List<Ship> _ships = new List<Ship>
        {
            new Ship {Id = 1, Name = "Leningorsk", Year = 1958, SeaType = true, Passengers = 51},
            new Ship {Id = 2, Name = "Alupka", Year = 1965, SeaType = true, Passengers = 212},
            new Ship {Id = 3, Name = "Kirgizstan", Year = 1963, SeaType = true, Passengers = 316},
            new Ship {Id = 4, Name = "Мichael Kalinin", Year = 1964, SeaType = true, Passengers = 333},
            new Ship {Id = 5, Name = "Astor", Year = 1986, SeaType = true, Passengers = 650},
            new Ship {Id = 6, Name = "Lev Tolstoy", Year = 1981, SeaType = true, Passengers = 710},
            new Ship {Id = 7, Name = "Nezhin", Year = 1954, SeaType = true, Passengers = 54},
            new Ship {Id = 8, Name = "Admiral Lunin", Year = 1965, SeaType = true, Passengers = 200},
            new Ship {Id = 9, Name = "Volna", Year = 1987, SeaType = false, Passengers = 170},
            new Ship {Id= 10, Name = "ТМІ-4", Year = 1990, SeaType = false, Passengers = 0},
            new Ship {Id = 11, Name = "RSD-44", Year = 2000, SeaType = false, Passengers = 0},
            new Ship {Id = 12, Name = "Danubian", Year = 1980, SeaType = false, Passengers = 0},
            new Ship {Id = 13, Name = "Pirogov", Year = 1963, SeaType = false, Passengers = 100}
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
            new Sea {Id = 1, Name = "Black sea", Square = 437000},
            new Sea {Id = 2, Name = "Azov sea", Square = 39000}
        };
        
        private List<River> _rivers = new List<River>
        {
            new River {Id = 3, Name = "Danube", Length = 2860, MaxWidth = 150, Tributaries = 17},
            new River {Id = 4, Name = "Volga", Length = 3530, MaxWidth = 40, Tributaries = 7}
        };

        // #1 Base select
        public void SelectShips()
        {
            var ships = from s in _ships
                select s;

            Console.WriteLine("All the ships: ");
            foreach (var ship in ships)
            {
                Console.WriteLine(ship);   
            }
        }

        // #2 Select with where
        public void SelectLongRivers()
        {
            var longRivers = _rivers.Where(r => r.Length > 3000);

            Console.WriteLine($"Long rivers: ");
            
            foreach (var river in longRivers)
            {
                Console.WriteLine(river);   
            }
        }

        // #3 Order by 
        public void SelectOrderedCompanies()
        {
            var companies = _companies.OrderByDescending(c => c.Name);

            Console.WriteLine($"Ordered companies by desc: ");
            foreach (var company in companies)
            {
                Console.WriteLine(company);   
            }
        }

        // #4 Creating a projection
        public void SelectIsPassengerShip()
        {
            var ships = from ship in _ships
                select new {Ship = ship, isPassenger = (ship.Passengers > 0)};
            
            Console.WriteLine("Describes whether the ship is for passengers: ");
            foreach (var pair in ships)
            {
                Console.WriteLine($"Ship name: {pair.Ship.Name} | Is for passengers: {pair.isPassenger}");   
            }
            Console.WriteLine();
        }
        
        // #5 Union over 2 selected arrays
        public void SelectWater()
        {
            var waters = _seas.Select(sea => sea.ToString())
                .Union(_rivers.Select(river => river.ToString()));

            Console.WriteLine($"All of the seas and rivers: ");
            foreach (var water in waters)
            {
                Console.WriteLine(water);
            }
        }

        // #6 Grouping
        public void SelectGroupShipsByYear()
        {
            var ships = from ship in _ships
                group ship by ship.Year;
            
            Console.WriteLine("Ships grouped by years: ");

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
        
        // #7 Inner join
        public void SelectSeaCompanies()
        {
            var companies = from company in _companies
                join sea in _seas on company.WaterId equals sea.Id
                select new {Company = company.Name, Sea = sea.Name};
                
            Console.WriteLine($"Companies and their seas: ");
            
            foreach (var pair in companies)
            {
                Console.WriteLine($"Company: {pair.Company} | Sea: {pair.Sea}");
            }
        }
        
        // #8 Left join
        public void SelectAllCompaniesWithShips()
        {
            var allCompaniesWithShips = from company in _companies
                join link in _shipOfCompany on company.Id equals link.CompanyId into temp
                from t1 in temp.DefaultIfEmpty()
                join ship in _ships on t1?.ShipId equals ship.Id into temp2
                from t2 in temp2.DefaultIfEmpty()
                select new {Company = company.Name, Ship = (t2 == null) ? "null" : t2.Name};

            Console.WriteLine($"Companies and one of their ships: ");
            
            foreach (var tuple in allCompaniesWithShips)
            {
                Console.WriteLine($"{tuple.Company} - {tuple.Ship}");
            }

        }

        // #9 Many-to-many connection
        public void SelectShipOfCompany()
        {
            var shipOfCompany = from ship in _ships
                join link in _shipOfCompany on ship.Id equals link.ShipId into temp
                from t in temp
                join shipping in _companies on t.CompanyId equals shipping.Id
                select new {Ship = ship, Company = shipping};

            Console.WriteLine($"Ships and its company: ");
            
            foreach (var tuple in shipOfCompany)
            {
                Console.WriteLine(tuple.Ship);
                Console.WriteLine(tuple.Company);
                Console.WriteLine();
            }
        }

        // #10 Group join
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

        // #11 Union after where
        public void SelectShipsUnion()
        {
            var ships = 
                (from ship in _ships
                    where ship.Name.StartsWith("A")
                    select ship).Union(from ship in _ships
                    where ship.Name.StartsWith("L")
                    select ship);
            
            Console.WriteLine("Ships with names start with \"A\" and \"L\":");
            foreach (var ship in ships)
            {
                Console.WriteLine(ship);
            }
            Console.WriteLine();
        }

        // #12 Average
        public void SelectAverageShipsAge()
        {
            int averageShipsAge = Convert.ToInt32(_ships.Average(ship => ship.Year));
            
            Console.WriteLine($"Average age of ships is {averageShipsAge}");
            Console.WriteLine();
        }

        // #13 Max
        public void SelectLargestSea()
        {
            var largestSea = _seas.Where(sea => sea.Square == _seas.Max(sea => sea.Square));
            
            Console.WriteLine($"Largest sea:");
            Console.WriteLine(largestSea.First());
            Console.WriteLine();
        }

        // #14 All
        public void SelectIfShipsAfterWar()
        {
            bool ifShipsAfterWar = _ships.All(ship => ship.Year > 1945);
            
            if (ifShipsAfterWar)
                Console.WriteLine("All of the ships in the database are after the Civil War 2");
            else
                Console.WriteLine("Not all ships were built before 1945");
            
            Console.WriteLine();
        }

        // #15 TakeWhile
        public void SelectSkipTo()
        {
            var ships = _ships.TakeWhile(ship => ship.Name != "Lev Tolstoy");
            
            Console.WriteLine($"Takes all the ships before \"Lev Tolstoy\":");

            foreach (var ship in ships)
            {
                Console.WriteLine(ship);
            }
            
            Console.WriteLine();
        }
        
    }
}