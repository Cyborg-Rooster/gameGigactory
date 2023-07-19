using System;
using System.Collections.Generic;
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
        var brute = DatabaseManager.ReturnAllValues(CommonQuery.Select("*", "SHEDS"));

        for(int y = 0; y < brute.GetLength(1); y++)
        {
           
        }
    }
}
