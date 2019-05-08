using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace BestRestaurant.Models
{
  public class Cuisine
  {
    public string Type { get; set; }
    public int Id { get; set; }


    public static List<Cuisine> cuisineList = new List<Cuisine> {};

    public Cuisine (string type, int id = 0)
    {
      Type = type;
      Id = id;
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

    // public override bool Equals(System.Object otherCuisine)
    // {
    //   if (!(otherCuisine is Cuisine))
    //   {
    //     return false;
    //   }
    //   else
    //   {
    //     Cuisine newCuisine = (Cuisine) otherCuisine;
    //     bool descriptionEquality = (this.Type == newCuisine.Type);
    //     return (descriptionEquality);
    //   }
    // }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO cuisine (type) VALUES (@CuisinesType);";
      // MySqlParameter name = new MySqlParameter();
      // name.ParameterType = ;
      // name.Value = this.Type;
      //
      // MySqlParameter address = new MySqlParameter();
      // address.ParameterType = ;
      // address.Value = this.Address;
      //
      // MySqlParameter phoneNumber = new MySqlParameter();
      // phoneNumber.ParameterType = "@CuisinesPhoneNumber";
      // phoneNumber.Value = this.phoneNumber;

      // cmd.Parameters.AddWithValue("@");
      cmd.Parameters.AddWithValue("@CuisinesType", Type);
      cmd.ExecuteNonQuery();
      // more logic will go here
      Id = (int) cmd.LastInsertedId;
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
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

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
 }
}
