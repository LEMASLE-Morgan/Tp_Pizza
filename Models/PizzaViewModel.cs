using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_Pizza.Models
{
    public class PizzaViewModel
    {

        public Pizza pizza { get; set; }

        public List<Pate> Pates { get; } = new List<Pate>();
        
        public List<Ingredient> Ingredient {get;} = new List<Ingredient>();
        public int IdPates { get; }
        public int IdIngredient { get; }

    }
}