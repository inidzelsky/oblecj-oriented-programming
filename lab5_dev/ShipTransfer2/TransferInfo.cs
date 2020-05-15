using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Linq;

namespace ShipTransfer2
{
    public class TransferInfo
    {
        // Dictionary with file names of the tables
        private Dictionary<string, string> _pathes = new Dictionary<string, string>
        {
            {"shipsPath", "ships.xml"},
            {"companiesPath", "companies.xml"},
            {"linksPath", "links.xml"},
            {"seasPath", "seas.xml"},
            {"riversPath", "rivers.xml"}
        };

        // Lists which implement tables
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
        
        private List<Link> _links = new List<Link>
        {
            new Link {ShipId = 2, CompanyId = 1},
            new Link {ShipId = 3, CompanyId = 1},
            new Link {ShipId = 4, CompanyId = 1},
            new Link {ShipId = 5, CompanyId = 1},
            new Link {ShipId = 6, CompanyId = 1},
            new Link {ShipId = 7, CompanyId = 1},
            new Link {ShipId = 7, CompanyId = 2},
            new Link {ShipId = 8, CompanyId = 2},
            new Link {ShipId = 9, CompanyId = 2},
            new Link {ShipId = 9, CompanyId = 3},
            new Link {ShipId = 10, CompanyId = 3},
            new Link {ShipId = 10, CompanyId = 4},
            new Link {ShipId = 11, CompanyId = 3},
            new Link {ShipId = 11, CompanyId = 4},
            new Link {ShipId = 12, CompanyId = 4}
        }

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

        // Clearing .xml files and filling with the tables data
        public void Initialize()
        {
            foreach (var path in _pathes.Values)
            {
                if (File.Exists(path))
                {
                    XDocument xDoc = XDocument.Load(path);
                    xDoc.Root.RemoveAll();
                    xDoc.Save(path);
                }
            }
            
            foreach (var company in _companies)
            {
                ObjectToXml.AddCompany(_pathes["companiesPath"], company);
            }

            foreach (var ship in _ships)
            {
                ObjectToXml.AddShip(_pathes["shipsPath"], ship);
            }

            foreach (var link in _links)
            {
                ObjectToXml.AddLink(_pathes["linksPath"], link);
            }

            foreach (var river in _rivers)
            {
                ObjectToXml.AddRiver(_pathes["riversPath"], river);
            }

            foreach (var sea in _seas)
            {
                ObjectToXml.AddSea(_pathes["seasPath"], sea);
            }
        }

        public void Select1()
        {
            var ships = from shipXml in XDocument.Load(_pathes["shipsPath"]).Root.Elements("ship")
                orderby shipXml.Element("name").Value
                select XmlToObject.CreateShip(shipXml);

            foreach (var ship in ships)
            {
                Console.WriteLine(ship);
            }

        }
    }
}