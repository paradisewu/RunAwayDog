using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StaticLoad : MonoBehaviour
{

    public static bool _IsClone = false;
    public GameObject cube;
    void Start()
    {
        if (!_IsClone)
        {
            cube = Instantiate(cube) as GameObject;
            DontDestroyOnLoad(cube);
            _IsClone = true;
        }
        Debug.Log("我是场景A");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SceneManager.LoadScene("scene2");
        }
    }
}
