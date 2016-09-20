using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class loadscene : MonoBehaviour
{
    public static loadscene instance;
    static loadscene()
    {
        //GameObject go = (GameObject)Instantiate(Resources.Load<GameObject>("Loadmangager"));
        GameObject go = new GameObject("Loadmangager");
        DontDestroyOnLoad(go);
        instance = go.AddComponent<loadscene>();
    }
    void Start()
    {
        Debug.Log("我是scene1");
        //DontDestroyOnLoad(this);
    }

    public void Dothing()
    {

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SceneManager.LoadScene("scene2");
        }
    }
}
