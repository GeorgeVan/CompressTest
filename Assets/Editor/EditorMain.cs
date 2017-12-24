using System.IO;
using UnityEditor;
using UnityEngine;
using GLibWin;
using GLib;

namespace Assets.Editor
{
    class EditorMain
    {
        [InitializeOnLoadMethod]
        public static void OnProjectLoadedInEditor()
        {
            Utils.Loggers += Debug.Log; 
            CompressTestCase.Init(Application.streamingAssetsPath, @"C:\temp\1");
            File.Copy(CompressTestCase.SrcDir + "/values", CompressTestCase.DstDir + "/values",true);
        }

        [MenuItem("开发测试/zip", false)]
        [CUDLR.Command("zip", "lists all the game objects in the scendde")]
        public static void zip()
        {
            CompressTestCase.zip();
        }

        [MenuItem("开发测试/bzip", false)]
        public static void bzip()
        {
            CompressTestCase.bzip();

        }

        [MenuItem("开发测试/mxz", false)]
        public static void mxz()
        {
            CompressTestCase.Tester.RunOne("mxz", 9, MiniW.MXZ, MiniW.DeMXZ);
            CompressTestCase.LogFileSize("mxz");
        }

        [MenuItem("开发测试/lzma", false)]
        public static void lzma()
        {
            CompressTestCase.Tester.RunOne("lzma", 9, Mini.LZMA, Mini.DeLZMA);
            CompressTestCase.LogFileSize("lzma");
        }

        [MenuItem("开发测试/lzma1", false)]
        public static void lzma1()
        {
            CompressTestCase.Tester.RunOne("lzma", 9, MiniW.LZMA1, null);
        }

        [MenuItem("开发测试/mszip", false)]
        public static void mszip()
        {
            CompressTestCase.mszip();

        }
    }
}
