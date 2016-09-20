using UnityEngine;
using System.Collections;
using System.Xml;

public class LoadXpath : MonoBehaviour
{

    void Start()
    {

        LoadXml2();
    }

    /// <summary>
    /// 获取Row属性中含有res_file_type_name 且等于三维场景
    /// </summary>
    void LoadXml()
    {
        string xpath = "/program/element_list/row[@res_file_type_name='三维场景']";
        string path = Application.dataPath + "/20160811000008.xml";
        Debug.Log(path);
        XmlDocument myXML = new XmlDocument();
        myXML.Load(path);

        XmlNodeList XmlList = myXML.SelectNodes(xpath);
        Debug.LogError(XmlList.Count);
        foreach (XmlElement item in XmlList)
        {
            Debug.LogError(item.Attributes["element_obj_ids"].Value);
        }
    }

    /// <summary>
    /// 获取XML中Name 下 含有BuiltNamezi子节点 且值等于 央视大厦
    /// </summary>
    void LoadXml2()
    {
        string xpath = "/Program/Building/Name[BuiltName='央视大厦']";
        string path = Application.dataPath + "/data.xml";
        Debug.Log(path);
        XmlDocument myXML = new XmlDocument();
        myXML.Load(path);

        XmlNodeList XmlList = myXML.SelectNodes(xpath);
        Debug.LogError(XmlList.Count);
        foreach (XmlElement item in XmlList)
        {
            Debug.LogError(item.Name);
        }
    }
}
