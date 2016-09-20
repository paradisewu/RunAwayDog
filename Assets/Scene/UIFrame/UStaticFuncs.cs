using UnityEngine;
using System.Collections;

public static class UStaticFuncs
{
    public static Transform FindChild(Transform tr, string childName)
    {
        for (int i = 0; i < tr.childCount; i++)
        {
            if (tr.GetChild(i).name == childName)
            {
                Transform t = tr.GetChild(i);
                if (t != null)
                {
                    return t;
                }
            }
            else
            {
                Transform t = FindChild(tr.GetChild(i), childName);
                if (t != null)
                {
                    return t;
                }
            }
        }
        return null;
    }
    public static T FindChildComponent<T>(Transform tr, string childName)
    {
        Transform t = FindChild(tr, childName);
        return t.GetComponent<T>();
    }
}