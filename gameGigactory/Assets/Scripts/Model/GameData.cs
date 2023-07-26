using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class GameData
{
    public static List<Shed> Sheds = new List<Shed>();
    public static List<Room> Rooms = new List<Room>();
    public static List<Truck> Trucks = new List<Truck>();
    public static List<Belt> Belts = new List<Belt>();
    public static List<Workbench> Workbenches = new List<Workbench>();

    public static void Load()
    {
        try
        {            var brute = DatabaseManager.ReturnAllValues(CommonQuery.Select("*", "SHEDS"));
            while(brute.Read())
            {
                Sheds.Add
                (
                    new Shed()
                    {
                        ID = brute.GetInt32(0),
                        BeltsCounts = brute.GetInt32(1),
                        RoomsCount = brute.GetInt32(2),
                        FloorType = brute.GetInt32(3),
                        TrucksCount = brute.GetInt32(4)
                    }
                );
            }

            brute = DatabaseManager.ReturnAllValues(CommonQuery.Select("*", "ROOMS"));
            while (brute.Read())
            {
                Rooms.Add
                (
                    new Room()
                    {
                        ID = brute.GetInt32(0),
                        ShedID = brute.GetInt32(1),
                        Type = brute.GetInt32(2)
                    }
                );
            }

            brute = DatabaseManager.ReturnAllValues(CommonQuery.Select("*", "TRUCKS"));
            while (brute.Read())
            {
                Trucks.Add
                (
                    new Truck()
                    {
                        ID = brute.GetInt32(0),
                        ShedID = brute.GetInt32(1),
                        Quality = brute.GetInt32(2)
                    }
                );
            }

            brute = DatabaseManager.ReturnAllValues(CommonQuery.Select("*", "BELTS"));
            while (brute.Read())
            {
                Belts.Add
                (
                    new Belt()
                    {
                        ID = brute.GetInt32(0),
                        ShedID = brute.GetInt32(1),
                        WorkbenchCount = brute.GetInt32(2),
                        Quality = brute.GetInt32(3),
                        ResourcesBoxQuality = brute.GetInt32(4),
                        ProductBoxQuality = brute.GetInt32(5)
                    }
                );
            }

            brute = DatabaseManager.ReturnAllValues(CommonQuery.Select("*", "WORKBENCHS"));
            while (brute.Read())
            {
                Workbenches.Add
                (
                    new Workbench()
                    {
                        ID = brute.GetInt32(0),
                        BeltID = brute.GetInt32(1),
                        WorkerType = brute.GetInt32(2)
                    }
                );
            }
        }
        catch (Exception ex)
        {
            Debug.LogError(ex.StackTrace);
        }
    }

    public static void Teste()
    {
        Debug.Log(Sheds.Count);
        Debug.Log(Rooms.Count);
        Debug.Log(Trucks.Count);
        Debug.Log(Belts.Count);
        Debug.Log(Workbenches.Count);
    }
}
