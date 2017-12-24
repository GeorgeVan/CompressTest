using System;
using System.IO;
using GLib;
using HanFramework.HSConfigTable.TestCase;

public static class CompressTestCase
{
    public static string SrcDir;
    public static string DstDir;

    private static byte[] _buffer = new byte[256*1024];

    public static CompressTester Tester;
    public static void Init(string srcDir, string dstDir)
    {
        SrcDir = srcDir;
        DstDir = dstDir;
        Tester = new CompressTester(DstDir + "/values", DstDir, Utils.Log);
    }

    public static void LogFileSize(string name)
    {
        Utils.Log("[{0}] {1}", new FileInfo(DstDir + "/"+ name + ".dat").Length, name+".dat");
    }


    [CUDLR.Command("zip", "lists all the game objects in the scene")]
    public static void zip()
    {
        Tester.RunOne("IonicZLib", 5, Mini.IonicZLib, Mini.DeIonicZLib);
        Tester.RunOne("IonicGZip", 5, Mini.IonicGZip, Mini.DeIonicGZip);
        Tester.RunOne("GZip", 5, Mini.GZip, Mini.DeGZip);

        LogFileSize("IonicZLib");
        LogFileSize("IonicGZip");
        LogFileSize("GZip");
    }

    [CUDLR.Command("bzip", "lists all the game objects in the scene")]
    public static void bzip()
    {
        Tester.RunOne("bzip", 9, Mini.BZip2, Mini.DeBZip2);
        LogFileSize("bzip");

        Tester.RunOne("IonicBZip2", 9, Mini.IonicBZip2, Mini.DeIonicBZip2);
        LogFileSize("IonicBZip2");
    }


    [CUDLR.Command("delzma", "lists all the game objects in the scene")]
    public static void delzma()
    {
        //手机上面lzma非常慢
        Tester.RunDeOne("lzma", Mini.DeLZMA);
    }

    [CUDLR.Command("mszip", "lists all the game objects in the scene")]
    public static void mszip()
    {
        try
        {
            Tester.RunOne("MSGZip", -1, Mini.MSGZip, Mini.DeMSGZip);
        }catch(Exception e)
        {
            Utils.Log(e.ToString());
        }
    }
}