using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System.IO;
using System;

public class DatabaseManager
{
    private static IDbConnection Database;
    private static string Connection = $@"{Application.persistentDataPath}\Database\Database.sqlite";

    public static bool SetDatabase()
    {
        Directory.CreateDirectory($@"{Application.persistentDataPath}\Database\");
        Database = new SqliteConnection(new SqliteConnection("URI=file:" + Connection));
        SetDatabaseActive(true);

        bool databaseExist = int.Parse(CommonQuery.Select("COUNT(*)", "SQLITE_MASTER")) > 0;

        if (!databaseExist) DatabaseSynchManager.Synch();

        return databaseExist;
    }

    public static void RunQuery(string query)
    {
        IDbCommand cmd;

        cmd = Database.CreateCommand();
        cmd.CommandText = query;
        cmd.ExecuteReader();
    }

    public static string ReturnValue(string query)
    {
        IDbCommand cmd;
        IDataReader reader;

        cmd = Database.CreateCommand();

        cmd.CommandText = query;
        reader = cmd.ExecuteReader();

        string tmp =reader[0].ToString();

        cmd.Dispose();
        reader.Dispose();

        return tmp;
    }

    public static string[,] ReturnAllValues(string query)
    {
        IDbCommand cmd;
        IDataReader reader;

        cmd = Database.CreateCommand();

        cmd.CommandText = query;
        reader = cmd.ExecuteReader();

        DataTable dt = new DataTable();
        dt.Load(reader);

        string[,] tmp = new string[reader.FieldCount, dt.Rows.Count];

        for(int y = 0; y < dt.Rows.Count; y++)
        {
            for (int x = 0; x < reader.FieldCount; x++) tmp[x, y] = reader[x].ToString();
        }

        cmd.Dispose();
        reader.Dispose();
        
        return tmp;
    }

    public static void SetDatabaseActive(bool active)
    {
        if (active) Database.Open();
        else Database.Close();
    }
}
