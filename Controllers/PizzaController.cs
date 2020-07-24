using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP_Pizza.Models;
using TP_Pizza.Utils;

namespace TP_Pizza.Controllers
{
    public class PizzaController : Controller
    {
        // GET: Pizza
        public ActionResult Index()
        {

                       
            return View(FakeDbPizza.Instance.Pizzas);
        }

        // GET: Pizza/Details/5
        public ActionResult Details(int id)
        {
            PizzaViewModel pizza= new PizzaViewModel() ;

            pizza.Pizza = FakeDbPizza.Instance.Pizzas.FirstOrDefault(p => p.Id == id);

            if(pizza != null)
            {
                return View(pizza);
            }
            return RedirectToAction("Index");
        }

        // GET: Pizza/Create
        public ActionResult Create()
        {
            
            PizzaViewModel pizzaViewModel = new PizzaViewModel();

            if (pizzaViewModel != null)
            {

                pizzaViewModel.Pates = FakeDbPizza.Instance.Pates;
            }
            return View(pizzaViewModel);
        }

        // POST: Pizza/Create
        [HttpPost]
        public ActionResult Create(PizzaViewModel vm)
        {
            try
            {

                Pizza pizza = vm.Pizza;

                pizza.Pate = FakeDbPizza.Instance.Pates.FirstOrDefault(p => p.Id == vm.IdPate);

                pizza.Ingredients = FakeDbPizza.Instance.Ingredients.Where(i => vm.IdsIngredients.Contains(i.Id)).ToList();

                FakeDbPizza.Instance.Pizzas.Add(pizza);



                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizza/Edit/5
        public ActionResult Edit(int id)
        {

            return View();
        }

        // POST: Pizza/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizza/Delete/5
        public ActionResult Delete(int id)
        {
            Pizza pizza = FakeDbPizza.Instance.Pizzas.FirstOrDefault(p => p.Id == id);

            if(pizza != null)
            {
                return View(pizza);
            }
            else
            {
                return RedirectToAction("Index");
            }
           
        }

        // POST: Pizza/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Pizza pizza = FakeDbPizza.Instance.Pizzas.FirstOrDefault(p => p.Id == id);
                FakeDbPizza.Instance.Pizzas.Remove(pizza);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
