using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_Pizza.Utils
{
    public class FakeDbPizza
    {
        private static FakeDbPizza _instance;
        static readonly object instanceLock = new object();

        private FakeDbPizza()
        {
            pizza = this.GetPizzas();
        }

        public static FakeDbPizza Instance
        {
            get
            {
                if (_instance == null) 
                {
                    lock (instanceLock)
                    {
                        if (_instance == null) 
                            _instance = new FakeDbPizza();
                    }
                }
                return _instance;
            }
        }

        
        private List<Pizza> pizza;

        public List<Pizza> Pizzas
        {
            get { return pizza; }
        }

        public List<Ingredient> Ingredients { get;  } = new List<Ingredient>
        {

                new Ingredient{Id=1,Nom="Mozzarella"},
            new Ingredient{Id=2,Nom="Jambon"},
            new Ingredient{Id=3,Nom="Tomate"},
            new Ingredient{Id=4,Nom="Oignon"},
            new Ingredient{Id=5,Nom="Cheddar"},
            new Ingredient{Id=6,Nom="Saumon"},
            new Ingredient{Id=7,Nom="Champignon"},
            new Ingredient{Id=8,Nom="Poulet"}

        };

        public List<Pate> Pates { get;  } = new List<Pate>()
        {

            new Pate{ Id=1,Nom="Pate fine, base crême"},
            new Pate{ Id=2,Nom="Pate fine, base tomate"},
            new Pate{ Id=3,Nom="Pate épaisse, base crême"},
            new Pate{ Id=4,Nom="Pate épaisse, base tomate"}

        };

        private List<Pizza> GetPizzas()
        {
            return new List<Pizza>() {
                new Pizza{ Id = 1, Nom = "Margherita", Pate = this.Pates.FirstOrDefault(p => p.Id == 1), Ingredients = this.Ingredients.Where(i => i.Id < 3).ToList() },
                new Pizza{ Id = 1, Nom = "Calzone", Pate = this.Pates.FirstOrDefault(p => p.Id == 2), Ingredients = this.Ingredients.Where(i => i.Id == 2).ToList() },
                new Pizza{ Id = 1, Nom = "Salmone", Pate = this.Pates.FirstOrDefault(p => p.Id == 1), Ingredients = this.Ingredients.Where(i => i.Id < 5).ToList() }
            }; }

      
    }

}