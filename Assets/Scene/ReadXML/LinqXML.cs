using UnityEngine;
using System.Collections;
using System.IO;
using System.Xml.Linq;
using System.Linq;
using System;
public class Test : MonoBehaviour
{

    void Start()
    {
        //ReadDic();
        CreateCategories();
    }

    void Update()
    {


    }

    void ReadDic()
    {
        string[] dayas = Directory.GetFiles(Application.dataPath + "/RoomXML/", "*.xml");
        foreach (string item in dayas)
        {
            Debug.Log(item);
        }
        //DirectoryInfo info = new DirectoryInfo(Application.dataPath + "/RoomXML/");
        //FileInfo[] infos = info.GetFiles();
        //foreach (FileInfo item in infos)
        //{
        //    Debug.Log(item.FullName);
        //}
    }
    public static void CreateCategories()
    {
        string path = Application.dataPath + "/1.xml";
        XElement root = new XElement("Categories",
            new XElement("Category",
                 new XAttribute("CategoryID", Guid.NewGuid()),
                new XElement("CategoryName", "Condiment")
                ),
            new XElement("Category",
                new XElement("CategoryID", Guid.NewGuid()),
                new XElement("CategoryName", "Condiments")
                ),
            new XElement("Category",
                new XElement("CategoryID", Guid.NewGuid()),
                new XElement("CategoryName", "Confections")
                )
           );
        root.Save(path);


        XElement rssXDoc = XElement.Load(path);
        var query = from item in rssXDoc.Element("Categories").Elements()
                    select new
                    {
                        TypeName = item.Attribute("CategoryID") == null ? (string)null : item.Attribute("CategoryID").Value,
                        Saying = item.Value,
                    };

        foreach (var item in query)
        {
            Debug.Log(item.TypeName);
            Debug.Log(item.Saying);
        }
    }

}
