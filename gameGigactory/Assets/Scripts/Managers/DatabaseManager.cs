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

        return ReturnValueAsInt(CommonQuery.Select("COUNT(*)", "SQLITE_MASTER")) > 0;

        //if (!databaseExist) DatabaseSynchronizer.Synch();

        //return databaseExist;
    }

    public static void RunQuery(string query)
    {
        IDbCommand cmd;

        cmd = Database.CreateCommand();
        cmd.CommandText = query;
        cmd.ExecuteReader();
    }

    public static string ReturnValueAsString(string query)
    {
        IDbCommand cmd;
        IDataReader reader;

        cmd = Database.CreateCommand();

        cmd.CommandText = query;
        reader = cmd.ExecuteReader();

        return reader[0].ToString();
    }

    public static int ReturnValueAsInt(string query)
    {
        IDbCommand cmd;
        IDataReader reader;

        cmd = Database.CreateCommand();

        cmd.CommandText = query;
        reader = cmd.ExecuteReader();

        return Convert.ToInt32(reader[0]);
    }

    public static void SetDatabaseActive(bool active)
    {
        if (active) Database.Open();
        else Database.Close();
    }
}
