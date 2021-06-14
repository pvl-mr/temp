using FileImplement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace FileImplement
{
    public class FileDataListSingleton
    {
        private static FileDataListSingleton instance;
        private readonly string GameFileName = "Game.xml";
        private readonly string PlayerFileName = "Player.xml";
        public List<Game> Games { get; set; }
        public List<Player> Players { get; set; }  
        private FileDataListSingleton()
        {
            Games = LoadGames();
            Players = LoadPlayers();
        }

        public static FileDataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new FileDataListSingleton();
            }
            return instance;
        }
        ~FileDataListSingleton()
        {
            SaveGames();
            SavePlayers();
        }


        private List<Player> LoadPlayers()
        {
            var list = new List<Player>();
            if (File.Exists(PlayerFileName))
            {
                XDocument xDocument = XDocument.Load(PlayerFileName);
                var xElements = xDocument.Root.Elements("Player").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Player
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        GameId = Convert.ToInt32(elem.Element("GameId").Value),
                        ClientId = Convert.ToInt32(elem.Element("ClientId").Value),
                        ImplementerId = Convert.ToInt32(elem.Element("ImplementerId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value),
                        Sum = Convert.ToDecimal(elem.Element("Sum").Value),
                        Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), elem.Element("Status").Value),
                        DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value),
                        DateImplement = string.IsNullOrEmpty(elem.Element("DateImplement").Value) ? (DateTime?)null :
                        Convert.ToDateTime(elem.Element("DateImplement").Value),
                    });
                }
            }
            return list;
        }

        private List<Game> LoadGames()
        {
            var list = new List<Game>();
            if (File.Exists(FlowerFileName))
            {
                XDocument xDocument = XDocument.Load(FlowerFileName);
                var xElements = xDocument.Root.Elements("Flower").ToList();
                foreach (var elem in xElements)
                {
                    var flowerComp = new Dictionary<int, int>();
                    foreach (var component in elem.Element("FlowerComponents").Elements("FlowerComponent").ToList())
                    {
                        flowerComp.Add(Convert.ToInt32(component.Element("Key").Value), Convert.ToInt32(component.Element("Value").Value));
                    }
                    list.Add(new Game
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        FlowerName = elem.Element("FlowerName").Value,
                        Price = Convert.ToDecimal(elem.Element("Price").Value),
                        FlowerComponents = flowerComp
                    });
                }
            }
            return list;
        }

 
        private void SavePlayers()
        {
            if (Players != null)
            {
                var xElement = new XElement("Orders");
                foreach (var order in Players)
                {
                    xElement.Add(new XElement("Order",
                    new XAttribute("Id", order.Id),
                    new XElement("FlowerId", order.FlowerId),
                    new XElement("ClientId", order.ClientId),
                    new XElement("ImplementerId", order.ImplementerId),
                    new XElement("Count", order.Count),
                    new XElement("Sum", order.Sum),
                    new XElement("Status", order.Status),
                    new XElement("DateCreate", order.DateCreate),
                    new XElement("DateImplement", order.DateImplement)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(PlayerFileName);
            }
        }
        private void SaveGames()
        {
            if (Flowers != null)
            {
                var xElement = new XElement("Flowers");
                foreach (var flower in Flowers)
                {
                    var compElement = new XElement("FlowerComponents");
                    foreach (var component in flower.FlowerComponents)
                    {
                        compElement.Add(new XElement("FlowerComponent",
                        new XElement("Key", component.Key),
                        new XElement("Value", component.Value)));
                    }
                    xElement.Add(new XElement("Flower",
                    new XAttribute("Id", flower.Id),
                    new XElement("FlowerName", flower.FlowerName),
                    new XElement("Price", flower.Price),
                    compElement));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(FlowerFileName);
            }
        }
 
    }
}
