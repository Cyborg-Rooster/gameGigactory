using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

class DatabaseSynchManager
{
    public static readonly int Version = 1;

    public static void Synch()
    {
        #region Create
        DatabaseManager.RunQuery(CommonQuery.Create("DATABASE", "VERSION INTEGER"));
        DatabaseManager.RunQuery
        (
            CommonQuery.Create
            (
                "SHEDS",
                "SHED_ID INTEGER PRIMARY KEY AUTOINCREMENT, BELTS_COUNT INTEGER, " +
                "ROOMS_COUNT INTEGER, FLOOR_TYPE INTEGER, TRUCKS_COUNT INTEGER"
            )
        );
        DatabaseManager.RunQuery
        (
            CommonQuery.Create
            (
                "TRUCKS",
                "TRUCK_ID INTEGER PRIMARY KEY AUTOINCREMENT, SHED_ID INTEGER, QUALITY INTEGER"
            )
        );
        DatabaseManager.RunQuery
        (
            CommonQuery.Create
            (
                "ROOMS", "ROOM_ID INTEGER PRIMARY KEY AUTOINCREMENT, SHED_ID INTEGER, TYPE INTEGER"
            )
        );
        DatabaseManager.RunQuery
        (
            CommonQuery.Create
            (
                "BELTS",
                "BELT_ID INTEGER PRIMARY KEY AUTOINCREMENT, SHED_ID INTEGER, WORKBENCH_COUNT INTEGER, " +
                "QUALITY, RESOURCES_BOX_QUALITY INTEGER, PRODUCT_BOX_QUALITY INTEGER"
            )
        );
        DatabaseManager.RunQuery
        (
            CommonQuery.Create
            (
                "WORKBENCHS", "WORKBENCH_ID INTEGER PRIMARY KEY AUTOINCREMENT, BELT_ID INTEGER, WORKER_TYPE INTEGER"
            )
        );
        #endregion

        #region Add
        DatabaseManager.RunQuery
        (
            CommonQuery.Add
            (
                "SHEDS",
                "BELTS_COUNT, ROOMS_COUNT, FLOOR_TYPE, TRUCKS_COUNT",
                "0, 0, 1, 1"
            )
        );
        #endregion
    }
}
