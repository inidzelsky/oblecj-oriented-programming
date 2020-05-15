using System;
using System.IO;
using System.Xml.Linq;
using System.Linq;

namespace ShipTransfer2
{
    public class TransferInfo
    {
        private string _path;

        public TransferInfo(string path)
        {
            _path = path;
        }

        public string ReadXml()
        {
            return File.ReadAllText(_path);
        }
        
        // #1
        public void OrderedShips()
        {
            XElement xRoot = XDocument.Load(_path).Root;
            
            var ships = xRoot.Element("ships").Elements("ship")
                .OrderBy(s => s.Element("name").Value)
                .Select(s => XmlToObject.CreateShip(s));

            Console.WriteLine("Ordered ships:\n");
            foreach (var ship in ships)
            {
                Console.WriteLine(ship);
            }

            Console.WriteLine();
        }

        // #2
        public void ShipsAndCompanies()
        {
            XElement xRoot = XDocument.Load(_path).Root;
            
            var shipsAndCompanies = from c in xRoot.Element("companies").Elements("company")
                join l in xRoot.Element("links").Elements("link") on c.Attribute("id").Value equals l
                    .Element("companyid").Value into temp
                from t in temp
                join s in xRoot.Element("ships").Elements("ship") on t.Element("shipid").Value equals s.Attribute("id")
                    .Value
                select new {Company = c.Element("name").Value, Ship = s.Element("name").Value};

            Console.WriteLine("Inner Join\n");
            foreach (var sc in shipsAndCompanies)
            {
                Console.WriteLine($"Company: {sc.Company} - Ship: {sc.Ship}");
            }

            Console.WriteLine();
        }

        // #3 Union of 2 query methods
        public void Waters()
        {
            XElement xRoot = XDocument.Load(_path).Root;
            
            var waters = (from s in xRoot.Element("seas").Elements("sea")
                    select new {Id = s.Attribute("id").Value, Name = s.Element("name").Value, Type = "Sea"})
                .Union
                (xRoot.Element("rivers").Elements("river")
                    .Select(r => new {Id = r.Attribute("id").Value, Name = r.Element("name").Value, Type = "River"}));

            Console.WriteLine("All waters:\n");
            foreach (var water in waters)
            {
                Console.WriteLine($"Id: {water.Id} - Name: {water.Name} - Type: {water.Type}");
            }

            Console.WriteLine();
        }

        // #4 Left join
        public void CompaniesAndSeas()
        {
            XElement xRoot = XDocument.Load(_path).Root;
            
            var companiesAndSeas = from c in xRoot.Element("companies").Elements("company")
                join s in xRoot.Element("seas").Elements("sea") on c.Element("waterid").Value equals s.Attribute("id")
                    .Value into temp
                from t in temp.DefaultIfEmpty()
                select new {Company = c.Element("name").Value, Sea = (t == null) ? "null" : t.Element("name").Value};


            Console.WriteLine("Companies and its seas\n");
            foreach (var pair in companiesAndSeas)
            {
                Console.WriteLine($"Company: {pair.Company} - Sea: {pair.Sea}");
            }

            Console.WriteLine();
        }

        // #5
        public void AverageYear()
        {
            XElement xRoot = XDocument.Load(_path).Root;
            
            int average = (int) xRoot.Element("ships").Elements("ship")
                .Average(s => Double.Parse(s.Element("year").Value));
            Console.WriteLine($"Average ship year = {average}\n");
        }

        // #6
        public void ShipsWhile()
        {
            XElement xRoot = XDocument.Load(_path).Root;
            
            var ships = xRoot.Element("ships").Elements("ship")
                .TakeWhile(s => s.Element("name").Value != "Admiral Lunin")
                .Select(s => XmlToObject.CreateShip(s));

            Console.WriteLine("Ships before \"Admiral Lunin\":");
            foreach (var ship in ships)
            {
                Console.WriteLine(ship);
            }

            Console.WriteLine();
        }

        // #7 Group companies by waters id
        public void GroupCompanies()
        {
            XElement xRoot = XDocument.Load(_path).Root;
            
            var companies = from company in xRoot.Element("companies").Elements("company")
                group company by company.Element("waterid").Value into g
                select new {Key = g.Key, Companies = g.Select(c => XmlToObject.CreateCompany(c))};

            Console.WriteLine("Grouped companies by waters id:\n");
            foreach (var pair in companies)
            {
                Console.WriteLine(pair.Key);
                foreach (var c in pair.Companies)
                {
                    Console.WriteLine(c);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        // #8 Group join ships by companies
        public void GroupJoinShips()
        {
            XElement xRoot = XDocument.Load(_path).Root;
            
            var ships = xRoot.Element("companies").Elements("company")
                .GroupJoin(xRoot.Element("links").Elements("link"),
                    c => c.Attribute("id").Value,
                    link => link.Element("companyid").Value,
                    (c, links) =>
                        new
                        {
                            Company = XmlToObject.CreateCompany(c),
                            Ships = links.Join(xRoot.Element("ships").Elements("ship"),
                                l => l.Element("shipid").Value,
                                s => s.Attribute("id").Value,
                                (l, s) => XmlToObject.CreateShip(s))
                        });
                

            foreach (var pair in ships)
            {
                Console.WriteLine($"{pair.Company}:");
                foreach (var ship in pair.Ships)
                {
                    Console.WriteLine(ship);
                }
                Console.WriteLine();
            }
        }
        
        // #9 Intersection
        public void IntersectShips()
        {
            XElement xRoot = XDocument.Load(_path).Root;
            
            var ships =
                (from s in xRoot.Element("ships").Elements("ship")
                    where s.Element("name").Value.StartsWith("A") || s.Element("name").Value.StartsWith("V")
                    select s)
                .Intersect(from s in xRoot.Element("ships").Elements("ship")
                    where s.Element("name").Value.StartsWith("L") || s.Element("name").Value.StartsWith("A")
                select s)
                .Select(s => XmlToObject.CreateShip(s));

            Console.WriteLine("Ships which names starts with \'A\':");
            foreach (var ship in ships)
            {
                Console.WriteLine(ship);
            }
            Console.WriteLine();
        }
        
        // #10 
        public void AllShips()
        {
            XElement xRoot = XDocument.Load(_path).Root;
            
            bool areAfterWar = xRoot.Element("ships").Elements("ship").All(s => Int32.Parse(s.Element("year").Value) > 1945);
            
            if (areAfterWar)
                Console.WriteLine("All ships were built after the World War 2");
            else 
                Console.WriteLine("Not all ships were build atfer the World War 2");
            
            Console.WriteLine();
        }
        
    }
}