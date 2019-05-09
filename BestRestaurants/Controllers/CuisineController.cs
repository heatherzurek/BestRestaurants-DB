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

    [HttpGet("/cuisine/{id}/restaurant/new")]
    public ActionResult Show()
    {
      // Restaurant newRestaurant = new Restaurant(name, address, phoneNumber, cuisineId);
      List<Cuisine> allCuisine = Cuisine.GetAll();
      return View();
    }

    // [HttpPost("/cuisine/{id}/restaurant")]
    // public ActionResult New(string name, string address, string phoneNumber, int cuisineId)
    // {
    //   Restaurant myRestaurant = new Restaurant(name, address, phoneNumber, cuisineId);
    //   return RedirectToAction("Index");
    // }

    // [HttpGet("/animals/SortByType")]
    // public ActionResult SortByType()
    // {
    //   // Animal newAnimal = new Animal();
    //   List<Animal> allSortedAnimals = Animal.SortByType();
    //   return View(allSortedAnimals);
    // }
  }
}
