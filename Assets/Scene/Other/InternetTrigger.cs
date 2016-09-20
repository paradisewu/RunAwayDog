using UnityEngine;
using System.Collections;

public class InternetTrigger : MonoBehaviour
{

    void Update()
    {
        //无网络情况
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {

        }
        //有网络情况
        else
        {
            Debug.Log(Application.internetReachability);
        }
        
    }
}
