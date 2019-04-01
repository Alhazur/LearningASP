using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningASP.Models
{
    public class MockCakeService : ICakeService//allt fråm ICakeService 
    {
        private List<Cake> cakes = new List<Cake>();
        private int idCount = 1;// Måste skappa idcount

        public MockCakeService()//konsktuktor
        {
            cakes.Add(new Cake() {Name = "Klubnika tårt", Price = 100, Details = "Prosto tårt"});
            cakes.Add(new Cake() { Name = "Kakojta tårt", Price = 14040, Details = "Prosto tårt" });
            cakes.Add(new Cake() { Name = "Prosto tårt", Price = 1040, Details = "Prosto tårt" });
        }

        public List<Cake> AllCakes()
        {
            return cakes;
        }

        public Cake CreateCake(string name, int price, string details)
        {
            Cake cake = new Cake() { Id = idCount, Name = name, Price = price, Details = details };
            idCount++;
            cakes.Add(cake);//läggt till lista cakes
            return cake;//visa tårta
        }

        public bool DeleteCake(int id)
        {
            bool wasRemoved = false;

            foreach (Cake item in cakes)//fråm klass Cake, list cakes
            {
                if (item.Id == id)
                {
                    cakes.Remove(item);
                    wasRemoved = true;
                    break;//efter ta bort break att inte kraka
                }
            }

            return wasRemoved;
        }

        public Cake FindCake(int id)
        {
            foreach (Cake item in cakes)//för att go genom alla grejer
            {
                if (item.Id == id)
                {
                    return item;
                }
            }

            return null;
        }

        public bool UpdateCake(Cake cake)
        {
            bool wasUpdate = false;

            foreach (Cake original in cakes)
            {
                if (original.Id == cake.Id)//updatera cake fråm lista
                {
                    original.Name = cake.Name;// på alla namn
                    original.Price = cake.Price;
                    original.Details = cake.Details;

                    wasUpdate = true;
                    break;
                }
            }

            return wasUpdate;
        }
    }
}
