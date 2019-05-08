using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace BestRestaurant.Models
{
  public class Restaurant
  {
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public int cuisineId { get; set; }
    public int Id { get; set; }


    public static List<Restaurant> restList = new List<Restaurant> {};

    public Restaurant (string name, string address, string phoneNumber, int cuisineId, int id = 0)
    {
      Name = name;
      Address = address;
      PhoneNumber = phoneNumber;
      CuisineId = cuisineId;
      Id = id;
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM restaurants;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public override bool Equals(System.Object otherRestaurant)
    {
      if (!(otherRestaurant is Restaurant))
      {
        return false;
      }
      else
      {
        Restaurant newRestaurant = (Restaurant) otherRestaurant;
        bool idEquality = this.Id == newRestaurant.Id;
        bool descriptionEquality = (this.Name == newRestaurant.Name);
        bool categoryEquality = this.CuisineId == newItem.CuisineId;
        return (idEquality && descriptionEquality && categoryEquality);
      }
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO restaurants (name, address, phoneNumber) VALUES (@RestaurantsName, @RestaurantsAddress, @RestaurantsPhoneNumber, @RestaurantsCuisineId);";

      cmd.Parameters.AddWithValue("@RestaurantsName", Name);
      cmd.Parameters.AddWithValue("@RestaurantsAddress", Address);
      cmd.Parameters.AddWithValue("@RestaurantsPhoneNumber", PhoneNumber);
      cmd.Parameters.AddWithValue("@RestaurantsCuisineId", PhoneNumber);
      cmd.ExecuteNonQuery();
      // more logic will go here
      Id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<Restaurant> GetAll()
    {
      List<Restaurant> allRest = new List<Restaurant> {};


      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM restaurants;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

      while (rdr.Read())
      {
        string name = rdr.GetString(0);
        string address = rdr.GetString(1);
        string phoneNumber = rdr.GetString(2);
        int cuisineId = rdr.GetInt32(4);
        int id = rdr.GetInt32(3);

        Restaurant newRest = new Restaurant(name, address, phoneNumber, cuisineId, id);
        allRest.Add(newRest);
      }

      conn.Close();

      if (conn != null)
      {
        conn.Dispose();
      }

      return allRest;

    }

    public static Restaurant Find(int cuisineId)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM restaurants WHERE id = (@searchId);";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = id;
      cmd.Parameters.Add(searchId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int itemId = 0;
      string itemName = "";
      int cuisineId = 0;
      while(rdr.Read())
      {
        string name = rdr.GetString(0);
        string address = rdr.GetString(1);
        string phoneNumber = rdr.GetString(2);
        int cuisineId = rdr.GetInt32(4);
        int id = rdr.GetInt32(3);
      }

      Restaurant newRestaurant = new Restaurant(name, address, phoneNumber, cuisineId, id);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return newRestaurant;
    }

 }
}
