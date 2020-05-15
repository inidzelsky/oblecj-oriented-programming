using System;
using System.Xml.Linq;

namespace ShipTransfer2
{
    public class XmlToObject
    {
        public static Ship CreateShip(XElement node)
        {
            Ship ship = new Ship();

            ship.Id = Int32.Parse(node.Attribute("id").Value);
            ship.Name = node.Element("name").Value;
            ship.Year = Int32.Parse(node.Element("year").Value);
            ship.Passengers = Int32.Parse(node.Element("passengers").Value);
            ship.SeaType = Boolean.Parse(node.Element("seatype").Value);
            
            return ship;
        }    
        
        public static Company CreateCompany(XElement node)
        {
            Company company = new Company();

            company.Id = Int32.Parse(node.Attribute("id").Value);
            company.Name = node.Element("name").Value;
            company.WaterId = Int32.Parse(node.Element("waterid").Value);

            return company;
        }
        
        public static River CreateRiver(XElement node)
        {
            River river = new River();

            river.Id = Int32.Parse(node.Attribute("id").Value);
            river.Name = node.Element("name").Value;
            river.Length = Int32.Parse(node.Element("length").Value);
            river.MaxWidth = Int32.Parse(node.Element("maxwidth").Value);
            river.Tributaries = Int32.Parse(node.Element("tributaries").Value);
            
            return river;
        }    
        
        public static Sea CreateSea(XElement node)
        {
            Sea sea = new Sea();

            sea.Id = Int32.Parse(node.Attribute("id").Value);
            sea.Name = node.Element("name").Value;
            sea.Square = Int32.Parse(node.Element("square").Value);

            return sea;
        }

        public static Link CreateLink(XElement node)
        {
            Link link = new Link();

            link.CompanyId = Int32.Parse(node.Element("companyid").Value);
            link.ShipId = Int32.Parse(node.Element("shipid").Value);

            return link;
        }
    }
}