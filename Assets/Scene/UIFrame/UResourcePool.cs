using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UResourcePool
{
    private static UResourcePool s_instance;
    private static GameObject poolParent;
    public static UResourcePool Instance
    {
        get
        {
            if (s_instance == null)
            {
                s_instance = new UResourcePool();

                poolParent = new GameObject();
                poolParent.name = "PoolParent";
                poolParent.SetActive(false);
            }
            return s_instance;
        }
    }

    private Dictionary<string, List<GameObject>> dPool = new Dictionary<string, List<GameObject>>();
    public GameObject OnGetResource(string sResource, string path)
    {
        if (!path.Contains("/"))
        {
            path = path + "/";
        }
        if (!dPool.ContainsKey(sResource) || dPool[sResource].Count == 0)
        {
            GameObject go = Resources.Load<GameObject>(path + sResource);
            if (go == null)
            {
                Debug.LogError("Cannot find resourece " + path + sResource);
            }
            GameObject result = GameObject.Instantiate(go) as GameObject;
            result.name = sResource;
            return result;
        }
        else
        {
            GameObject result = dPool[sResource][0];
            dPool[sResource].RemoveAt(0);
            result.transform.localPosition = Vector3.zero;
            result.transform.localRotation = Quaternion.Euler(Vector3.zero);
            if (result.transform.parent != poolParent.transform)
            {
                Debug.LogError("get resource out of pool");
            }
            return result;
        }
    }
    public T OnGetResource<T>(string sResource, string path)
            where T : Object
    {
        if (!path.Contains("/"))
        {
            path = path + "/";
        }
        if (!dPool.ContainsKey(sResource) || dPool[sResource].Count == 0)
        {
            T go = Resources.Load<T>(path + sResource);
            if (go == null)
            {
                Debug.LogError("Cannot find resourece " + path + sResource);
            }
            T result = GameObject.Instantiate(go) as T;
            result.name = sResource;
            return result;
        }
        return null;
    }
    public void OnReturnResource(GameObject go)
    {
        if (go.transform.parent == poolParent.transform)
        {
            return;
        }
        if (!dPool.ContainsKey(go.name))
        {
            dPool.Add(go.name, new List<GameObject>());
        }
        go.transform.parent = poolParent.transform;
        dPool[go.name].Add(go);
    }

    public void DoDestroy()
    {
        dPool.Clear();
        s_instance = null;
        GameObject.Destroy(poolParent.gameObject);
    }
}