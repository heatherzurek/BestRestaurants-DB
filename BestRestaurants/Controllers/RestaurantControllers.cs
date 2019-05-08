using Microsoft.AspNetCore.Mvc;
using BestRestaurant.Models;
using System.Collections.Generic;
using System;

namespace BestRestaurant.Controllers
{
  public class RestaurantController : Controller
  {

    [HttpGet("/restaurant")]
    public ActionResult Index()
    {
      // Animal newAnimal = new Animal();
      List<Restaurant> allRest = Restaurant.GetAll();
      return View(allRest);
    }

    [HttpGet("/restaurant/new")]
    public ActionResult New()
    {
      return View();
    }


    [HttpPost("/restaurant")]
    public ActionResult Create(string name, string address, string phoneNumber, int cuisineId)
    {
      Restaurant myRestaurant = new Restaurant(name, address, phoneNumber, cuisineId);
      myRestaurant.Save();
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
