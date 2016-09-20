using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class load : MonoBehaviour
{

    void Start()
    {
        Debug.Log("我是场景B");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            SceneManager.LoadScene("scene1");
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            Singleton1._instance.ShowLog("可以调用？");
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            Singleton1._instance.AddData("可以调用？");
        }
    }
}
