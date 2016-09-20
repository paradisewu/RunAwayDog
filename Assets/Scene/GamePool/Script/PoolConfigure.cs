using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.IO;

//生成配置信息，供对象池使用  
public class PoolConfigure
{

    private static List<string> allFiles;

    //右键菜单    
    [MenuItem("Assets/Build Pool Configure")]
    static void Build()
    {
        string path = AssetDatabase.GetAssetPath(Selection.objects[0]);
        if (!path.Contains("Resources"))
        {
            Debug.Log("请选中Resources文件夹");
            return;
        }

        path = Application.dataPath + path;
        path = path.Replace("AssetsAssets", "Assets");
        Debug.Log(path);

        allFiles = new List<string>();
        GetAllFiles(path);
        allFiles.RemoveAll((s) => { return s.Contains("meta"); });
        //for (int i = 0; i < allFiles.Count; i++)  
        //{  
        //    Debug.Log(allFiles[i]);  
        //}  

        //对路径进行处理，使其可以直接通过Resources.Load进行加载  
        for (int i = 0; i < allFiles.Count; i++)
        {
            allFiles[i] = allFiles[i].Replace("\\", "/");
            allFiles[i] = allFiles[i].Substring(allFiles[i].IndexOf("Resources/") + 10);
            allFiles[i] = allFiles[i].Replace(".prefab", "");
            Debug.Log(allFiles[i]);
        }

        //生成配置文件  
        string outputPath = Application.dataPath + "/Script/ObjectPool/PoolInfo.cs";

        ClassTemplate.Start(outputPath);

        ClassTemplate.WriteClass("");
        for (int i = 0; i < allFiles.Count; i++)
        {
            string name = allFiles[i].Substring(allFiles[i].LastIndexOf('/') + 1);
            ClassTemplate.WriteField("string", name, "public const", "\"" + allFiles[i] + "\"");
        }

        ClassTemplate.End();
        AssetDatabase.Refresh();
    }

    //获取一个根目录下的所有文件  
    public static void GetAllFiles(string dir)
    {
        string[] files = Directory.GetFiles(dir);
        foreach (var item in files)
        {
            allFiles.Add(item);
        }

        string[] dirs = Directory.GetDirectories(dir);
        foreach (var item in dirs)
        {
            GetAllFiles(item);
        }
    }

}