using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningASP.Models
{
    public interface ICakeService//skappa service till klass
    {
        // för att skappa tårta (allt inom här är krävs) fråm klass Cake
        Cake CreateCake(string name, int price, string details);

        List<Cake> AllCakes();

        Cake FindCake(int id);

        bool UpdateCake(Cake cake);
        
        bool DeleteCake(int id);// har tog bort den ja eller nej?
    }
}
