

using GLib;
using System;

public class Utils
{
    public static event Action<string> Loggers;

    public static void Log(string format, params object[] objs)
    {
        Log(format.Eat(objs));
    }

    public static void Log(object obj)
    {
        Log(obj.ToString());
    }

    public static void Log(string s)
    {
        if (Loggers != null)
            Loggers.Invoke(s);
    }
}