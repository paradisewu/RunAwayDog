using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PoolManager : MonoBehaviour
{
    private static PoolManager instance;

    public static PoolManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("PoolManager").AddComponent<PoolManager>();
            }
            return instance;
        }
    }

    //path -- go  
    public Dictionary<string, List<GameObject>> dic = new Dictionary<string, List<GameObject>>();

    //把对象放到对象池中  
    public void SetPoolObject(string path, GameObject go)
    {
        if (!dic.ContainsKey(path))
        {
            List<GameObject> list = new List<GameObject>();
            list.Add(go);
            dic.Add(path, list);
        }
        else
        {
            dic[path].Add(go);
        }
        go.SetActive(false);
    }

    //从对象池中取出对象  
    //isNewGo为true,表示返回新的go,否则表示返回缓存池中的go  
    public GameObject GetPoolObject(string path, bool isNewGo = false)
    {
        //Resources.Load: 重复Load同样的资源只会指向同一段内存，不会增加开销  
        if (isNewGo)
        {
            GameObject go = MonoBehaviour.Instantiate(Resources.Load<GameObject>(path));
            return go;
        }

        if (!dic.ContainsKey(path))
        {
            GameObject go = MonoBehaviour.Instantiate(Resources.Load<GameObject>(path));
            return go;
        }
        else
        {
            if (dic[path].Count > 0)//还未取完  
            {
                GameObject go = dic[path][0];
                go.SetActive(true);
                dic[path].Remove(go);
                return go;
            }
            else//已经取完  
            {
                GameObject go = MonoBehaviour.Instantiate(Resources.Load<GameObject>(path));
                return go;
            }
        }
    }

    public void Cache(string path, int amount = 1, bool isNewGo = true)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject go = GetPoolObject(path, isNewGo);
            SetPoolObject(path, go);
        }
        Debug.LogError((dic[path]).Count);
    }

}