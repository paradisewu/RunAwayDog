using UnityEngine;
using System.Collections;

public class TimerObserverOrSubject : MonoBehaviour
{

    virtual protected void OnDestroy()
    {
        if (Singleton.IsCreatedInstance("TimerController"))
        {
            (Singleton.getInstance("TimerController") as TimerController).ClearTimer(this);
        }
    }

}
