using Microsoft.AspNetCore.Mvc;
using BestRestaurant.Models;
using System.Collections.Generic;
using System;

namespace BestRestaurant.Controllers
{
  public class RestaurantController : Controller
  {

    [HttpGet("/restaurant/")]
    public ActionResult Index()
    {
      // Animal newAnimal = new Animal();
      List<Restaurant> allRest = Restaurant.GetAll();
      return View(allRest);
    }

    [HttpGet("/restaurant/{id}/new")]
    public ActionResult New(int id)
    {
      return View(Cuisine.Find(id));
    }


    [HttpPost("/restaurant")]
    public ActionResult Create(string name, string address, string phoneNumber, int cuisineId)
    {
      Restaurant myRestaurant = new Restaurant(name, address, phoneNumber, cuisineId);
      myRestaurant.Save();
      return RedirectToAction("Index");
    }

    [HttpGet("/cuisine/{cuisineId}/restaurant/{restaurantId}")]
    public ActionResult Show(int cuisineId, int restaurantId)
    {
        Restaurant restaurant = Restaurant.Find(restaurantId);
        Dictionary<string, object> model = new Dictionary<string, object>();
        Cuisine cuisine = Cuisine.Find(cuisineId);
        model.Add("restaurant", restaurant);
        model.Add("cuisine", cuisine);
        return View(model);
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
