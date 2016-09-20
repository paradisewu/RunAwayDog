using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Singleton1 : MonoBehaviour
{

    public static Singleton1 _instance;
    public static bool IsOnce;
    private List<string> strArray;
    public Singleton1()
    {
        Debug.Log("Singleton 构造函数");
    }

    void Awake()
    {
        if (IsOnce==false)
        {
            _instance = this;
        }
    }

    public void ShowLog(string data)
    {
        Debug.LogError("这是" + data);
    }

    void Start()
    {
        strArray = new List<string>();
        Debug.Log("Singleton Start");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("是否一直调用？");
    }

    internal void AddData(string p)
    {
        strArray.Add(p);
        Debug.Log(strArray.Count);
        //SceneManager.LoadScene("scene1");
        //foreach (var item in strArray)
        //{
        //    Debug.Log(item);
        //}
    }
}
