using System.Collections;
using System.IO;
using UnityEngine;

public class Main : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        Utils.Loggers += CUDLR.Console.Log;
        CompressTestCase.Init(Application.streamingAssetsPath, Application.persistentDataPath);
        StartCoroutine(LoadData());
        Debug.Log("TestBaseStarted start");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    public static IEnumerator LoadData()
    {
        WWW www = new WWW(CompressTestCase.SrcDir + "/values");
        yield return www;
        File.WriteAllBytes(CompressTestCase.DstDir + "/values", www.bytes);
        CompressTestCase.LogFileSize("values");

        www = new WWW(CompressTestCase.SrcDir + "/lzma.dat");
        yield return www;
        File.WriteAllBytes(CompressTestCase.DstDir + "/lzma.dat", www.bytes);
        CompressTestCase.LogFileSize("lzma");
    }

}
