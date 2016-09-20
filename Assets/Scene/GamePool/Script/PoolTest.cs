using UnityEngine;
using System.Collections;

public class PoolTest : MonoBehaviour
{

    void Start()
    {
        //1  
        PoolManager.Instance.Cache(PoolInfo.Cube, 5000, true);
        Profiler.BeginSample("Pool      Test");
        for (int i = 0; i < 5000; i++)
        {
            PoolManager.Instance.GetPoolObject(PoolInfo.Cube);
        }
        Profiler.EndSample();  

        //2  
        //Profiler.BeginSample("PoolTest");
        //for (int i = 0; i < 5000; i++)
        //{
        //    Instantiate(Resources.Load<GameObject>(PoolInfo.Cube));
        //}
        //Profiler.EndSample();
    }

}