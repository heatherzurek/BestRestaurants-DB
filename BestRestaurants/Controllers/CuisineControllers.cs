using Microsoft.AspNetCore.Mvc;
using BestRestaurant.Models;
using System.Collections.Generic;
using System;

namespace BestRestaurant.Controllers
{
  public class CuisineController : Controller
  {

    [HttpGet("/cuisine")]
    public ActionResult Index()
    {
      // Animal newAnimal = new Animal();
      List<Cuisine> allCuisine = Cuisine.GetAll();
      return View(allCuisine);
    }

    [HttpGet("/cuisine/new")]
    public ActionResult New()
    {
      return View();
    }


    [HttpPost("/cuisine")]
    public ActionResult Create(string type)
    {
      Cuisine myCuisine = new Cuisine(type);
      myCuisine.Save();
      return RedirectToAction("Index");
    }

    // [HttpGet("/animals/SortByType")]
    // public ActionResult SortByType()
    // {
    //   // Animal newAnimal = new Animal();
    //   List<Animal> allSortedAnimals = Animal.SortByType();
    //   return View(allSortedAnimals);
    // }
  }
}
