using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningASP.Models//Databas
{
    public class CakeService : ICakeService//vse iz ICakeService 
    {
        readonly CakeDbContext _cakeDbContext;

        public CakeService(CakeDbContext cakeDbContext)//klass Databas 
        {
            _cakeDbContext = cakeDbContext;
        }

        public List<Cake> AllCakes()
        {
            return _cakeDbContext.Cakes.ToList();//iz lista till Databas 
        }

        public Cake CreateCake(string name, int price, string details)
        {
            Cake cake = new Cake() { Name = name, Price = price, Details = details };

            _cakeDbContext.Cakes.Add(cake);//läggt till lista cakes
            _cakeDbContext.SaveChanges();
            return cake;
        }

        public bool DeleteCake(int id)
        {
            bool wasRemoved = false;

            Cake cake = _cakeDbContext.Cakes.SingleOrDefault(cakes => cakes.Id == id);//Najti i ydalit

            if (cake == null)
            {
                return wasRemoved;
            }

            _cakeDbContext.Cakes.Remove(cake);//izmenenie
            _cakeDbContext.SaveChanges();//sohranit izmenenie

            return wasRemoved;
        }

        public Cake FindCake(int id)
        {            
            return _cakeDbContext.Cakes.SingleOrDefault(cakes => cakes.Id == id);//Najti 
        }

        public bool UpdateCake(Cake cake)
        {
            bool wasUpdate = false;

            Cake original = _cakeDbContext.Cakes.SingleOrDefault(cakes => cakes.Id == cake.Id);
            {
                if (original == null)//updatera cake fråm lista
                {
                    original.Name = cake.Name;// på alla namn
                    original.Price = cake.Price;
                    original.Details = cake.Details;

                    _cakeDbContext.SaveChanges();
                    wasUpdate = true;
                }
            }
            return wasUpdate;
        }
    }
}
