using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class DatabaseInitializerManager
{
    public static void Init()
    {
        Debug.Log(DatabaseManager.SetDatabase());
        GameData.Load();
        GameData.Teste();
    }
}
