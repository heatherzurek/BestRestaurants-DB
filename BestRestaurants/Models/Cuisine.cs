using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace BestRestaurant.Models
{
  public class Cuisine
  {
    public string Type { get; set; }
    public int Id { get; set; }
    public List<Restaurant> Restaurants { get; set; }

    public static List<Cuisine> cuisineList = new List<Cuisine> {};

    public Cuisine (string type, int id = 0)
    {
      Type = type;
      Id = id;
      Restaurants = new List<Restaurant> {};
    }

    public override bool Equals(System.Object otherCuisine)
    {
      if (!(otherCuisine is Cuisine))
      {
        return false;
      }
      else
      {
        Cuisine newCuisine = (Cuisine) otherCuisine;
        bool idEquality = this.Id.Equals(newCuisine.Id);
        bool nameEquality = this.Type.Equals(newCuisine.Type);
        return (idEquality && nameEquality);
      }
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO cuisine (type) VALUES (@type);";
      MySqlParameter type = new MySqlParameter();
      type.ParameterName = "@type";
      type.Value = this.Type;
      cmd.Parameters.Add(type);
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM cuisine;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<Cuisine> GetAll()
    {
      List<Cuisine> allCuisine = new List<Cuisine> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM cuisine;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;

      while (rdr.Read())
      {
        string type = rdr.GetString(0);
        int id = rdr.GetInt32(1);
        Cuisine newCuisine = new Cuisine(type, id);
        allCuisine.Add(newCuisine);
      }

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allCuisine;
    }

    public static Cuisine Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM categories WHERE id = (@searchId);";

      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = id;
      cmd.Parameters.Add(searchId);

      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int CuisineId = 0;
      string CuisineType = "";

      while(rdr.Read())
      {
        CuisineType = rdr.GetString(0);
        CuisineId = rdr.GetInt32(1);
      }
      Cuisine newCuisine = new Cuisine(CuisineType, CuisineId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return newCuisine;
    }

    public static void DeleteAll()
    {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"DELETE FROM cuisine;";
        cmd.ExecuteNonQuery();
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
    }
 }
}
