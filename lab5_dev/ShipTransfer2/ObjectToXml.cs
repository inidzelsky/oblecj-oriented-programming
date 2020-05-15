using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace ShipTransfer2
{
    public class ObjectToXml
    {
        public static void AddShip(string shipsPath, Ship ship)
        {
            XDocument xDoc = File.Exists(shipsPath) ? XDocument.Load(shipsPath) : new XDocument(new XElement("ships"));

            XElement xShip = new XElement("ship",
                new XAttribute("id", ship.Id),
                new XElement("name", ship.Name),
                new XElement("year", ship.Year),
                new XElement("passengers", ship.Passengers),
                new XElement("seatype", ship.SeaType));
            
            xDoc.Root.Add(xShip);
            
            xDoc.Save(shipsPath);
        }
        
        public static void AddCompany(string companiesPath, Company company)
        {
            XDocument xDoc = File.Exists(companiesPath) ? XDocument.Load(companiesPath) : new XDocument(new XElement("companies"));

            XElement xCompany = new XElement("ship",
                new XAttribute("id", company.Id),
                new XElement("name", company.Name),
                new XElement("waterid", company.WaterId));
            
            xDoc.Root.Add(xCompany);
            
            xDoc.Save(companiesPath);
        }
        
        public static void AddRiver(string riversPath, River river)
        {
            XDocument xDoc = File.Exists(riversPath) ? XDocument.Load(riversPath) : new XDocument(new XElement("rivers"));

            XElement xRiver = new XElement("river",
                new XAttribute("id", river.Id),
                new XElement("name", river.Name),
                new XElement("length", river.Length),
                new XElement("maxwidth", river.MaxWidth),
                new XElement("tributaries", river.Tributaries));
            
            xDoc.Root.Add(xRiver);
            
            xDoc.Save(riversPath);
        }
        
        public static void AddSea(string seasPath, Sea sea)
        {
            XDocument xDoc = File.Exists(seasPath) ? XDocument.Load(seasPath) : new XDocument(new XElement("seas"));

            XElement xSea = new XElement("sea",
                new XAttribute("id", sea.Id),
                new XElement("name", sea.Name),
                new XElement("square", sea.Square));

            xDoc.Root.Add(xSea);
            
            xDoc.Save(seasPath);
        }

        public static void AddLink(string linksPath, Link link)
        {
            XDocument xDoc = File.Exists(linksPath) ? XDocument.Load(linksPath) : new XDocument(new XElement("links"));

            XElement xLink = new XElement("link",
                new XElement("shipid", link.ShipId),
                new XElement("companyid", link.CompanyId));

            xDoc.Root.Add(xLink);
            
            xDoc.Save(linksPath);
        }
    }
}