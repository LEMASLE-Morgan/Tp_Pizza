using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_Pizza.Models
{
    public class PizzaViewModel
    {

        public Pizza Pizza { get; set; }

        public List<Pate> Pates { get; set; } = new List<Pate>();
        
        public List<Ingredient> Ingredient { get; set; } = new List<Ingredient>();
        public int? IdPate { get; set; }
        public List<int> IdsIngredients { get; set; } = new List<int>();

    }
}