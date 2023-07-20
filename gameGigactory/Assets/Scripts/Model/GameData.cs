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
        DataTable dt = new DataTable();

        var brute = DatabaseManager.ReturnAllValues(CommonQuery.Select("*", "SHEDS"));
        dt.Load(brute);

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            Sheds.Add
            (
                new Shed()
                {
                    ID = (int)brute["SHED_ID"],
                    BeltsCounts = (int)brute["BELTS_COUNT"],
                    RoomsCount = (int)brute["ROOMS_COUNT"],
                    FloorType = (int)brute["FLOOR_TYPE"],
                    TrucksCount = (int)brute["TRUCKS_COUNT"]
                }
            );
        }

        brute = DatabaseManager.ReturnAllValues(CommonQuery.Select("*", "ROOMS"));
        dt.Load(brute);

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            Rooms.Add
            (
                new Room()
                {
                    ID = (int)brute["ROOM_ID"],
                    ShedID = (int)brute["SHED_ID"],
                    Type = (int)brute["TYPE"]
                }
            );
        }

        brute = DatabaseManager.ReturnAllValues(CommonQuery.Select("*", "TRUCKS"));
        dt.Load(brute);

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            Trucks.Add
            (
                new Truck()
                {
                    ID = (int)brute["TRUCK_ID"],
                    ShedID = (int)brute["SHED_ID"],
                    Quality = (int)brute["QUALITY"]
                }
            );
        }

        brute = DatabaseManager.ReturnAllValues(CommonQuery.Select("*", "BELTS"));
        dt.Load(brute);

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            Belts.Add
            (
                new Belt()
                {
                    ID = (int)brute["BELT_ID"],
                    ShedID = (int)brute["SHED_ID"],
                    WorkbenchCount = (int)brute["WORKBENCH_COUNT"],
                    Quality = (int)brute["QUALITY"],
                    ResourcesBoxQuality = (int)brute["RESOURCES_BOX_QUALITY"],
                    ProductBoxQuality = (int)brute["PRODUCT_BOX_QUALITY"]
                }
            );
        }

        brute = DatabaseManager.ReturnAllValues(CommonQuery.Select("*", "WORKBENCHS"));
        dt.Load(brute);

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            Workbenches.Add
            (
                new Workbench()
                {
                    ID = (int)brute["WORKBENCH_ID"],
                    BeltID = (int)brute["BELT_ID"],
                    WorkerType = (int)brute["WORKER_TYPE"]
                }
            );
        }
    }
}
