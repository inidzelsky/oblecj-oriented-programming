using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace ShipTransfer2
{
    public class Writer
    {
        private string _filePath;
        
        private readonly List<Ship> _ships = new List<Ship>
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
        
        private readonly List<Company> _companies = new List<Company>
        {
            new Company {Id = 1, WaterId = 1, Name = "Black sea shipping"},
            new Company {Id = 2, WaterId = 2, Name = "Azov sea shipping"},
            new Company {Id = 3, WaterId = 3, Name = "Danubian shipping of Ukraine"},
            new Company {Id = 4, WaterId = 4, Name = "Volga shipping"},
            new Company {Id = 5, WaterId = 4, Name = "Southern shipping of Russia"}
        };
        
        private readonly List<River> _rivers = new List<River>
        {
            new River {Id = 3, Name = "Danube", Length = 2860, MaxWidth = 150, Tributaries = 17},
            new River {Id = 4, Name = "Volga", Length = 3530, MaxWidth = 40, Tributaries = 7}
        };
        
        private readonly List<Sea> _seas = new List<Sea>
        {
            new Sea {Id = 1, Name = "Black sea", Square = 437000},
            new Sea {Id = 2, Name = "Azov sea", Square = 39000}
        };
        
        private readonly List<Link> _links = new List<Link>
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
        };

        public Writer(string filePath)
        {
            _filePath = filePath;
        }

        public void Write()
        {
            var settings = new XmlWriterSettings {Indent = true};
            using var xmlWriter = XmlWriter.Create(_filePath, settings);
            
            xmlWriter.WriteStartElement("info");

            xmlWriter.WriteStartElement("ships");
            foreach (var ship in _ships)
            {
                xmlWriter.WriteStartElement("ship");
                xmlWriter.WriteAttributeString("id", ship.Id.ToString());
                xmlWriter.WriteElementString("name", ship.Name);
                xmlWriter.WriteElementString("year", ship.Year.ToString());
                xmlWriter.WriteElementString("passengers", ship.Passengers.ToString());
                xmlWriter.WriteElementString("seatype", ship.SeaType.ToString());
                xmlWriter.WriteEndElement();
            }
            xmlWriter.WriteEndElement();
                
            xmlWriter.WriteStartElement("companies");
            foreach (var company in _companies)
            {
                xmlWriter.WriteStartElement("company");
                xmlWriter.WriteAttributeString("id", company.Id.ToString());
                xmlWriter.WriteElementString("name", company.Name);
                xmlWriter.WriteElementString("waterid", company.WaterId.ToString());
                xmlWriter.WriteEndElement();
            }
            xmlWriter.WriteEndElement();
                
            xmlWriter.WriteStartElement("links");
            foreach (var link in _links)
            {
                xmlWriter.WriteStartElement("link");
                xmlWriter.WriteElementString("shipid", link.ShipId.ToString());
                xmlWriter.WriteElementString("companyid", link.CompanyId.ToString());
                xmlWriter.WriteEndElement();
            }
            xmlWriter.WriteEndElement();
                
            xmlWriter.WriteStartElement("rivers");
            foreach (var river in _rivers)
            {
                xmlWriter.WriteStartElement("river");
                xmlWriter.WriteAttributeString("id", river.Id.ToString());
                xmlWriter.WriteElementString("name", river.Name);
                xmlWriter.WriteElementString("length", river.Length.ToString());
                xmlWriter.WriteElementString("maxwidth", river.MaxWidth.ToString());
                xmlWriter.WriteElementString("tributaries", river.Tributaries.ToString());
                xmlWriter.WriteEndElement();
            }
            xmlWriter.WriteEndElement();
                
            xmlWriter.WriteStartElement("seas");
            foreach (var sea in _seas)
            {
                xmlWriter.WriteStartElement("sea");
                xmlWriter.WriteAttributeString("id", sea.Id.ToString());
                xmlWriter.WriteElementString("name", sea.Name);
                xmlWriter.WriteElementString("square", sea.Square.ToString());
                xmlWriter.WriteEndElement();
            }
                
            xmlWriter.WriteEndElement();
        }
        
        public void AddShip(int id, string name, int year, int passengers, bool seaType)
        {
            _ships.Add(new Ship {Id = id, Name = name, Passengers = passengers, Year = year, SeaType = seaType});
        }
        
        public void AddCompany(int id, string name, int waterId)
        {
            _companies.Add(new Company {Id = id, Name = name, WaterId = waterId});
        }
        
        public void AddRiver(int id, string name, int length, int maxWidth, int tributaries)
        {
            _rivers.Add(new River {Id =id, Name = name, Length = length, MaxWidth = maxWidth, Tributaries = tributaries});
        }

        public void AddSea(int id, string name, int square)
        {
            _seas.Add(new Sea {Id = id, Name = name, Square = square});
        }

        public void AddLink(int shipId, int companyId)
        {
            _links.Add(new Link {ShipId = shipId, CompanyId = companyId});
        }
        
    }
}