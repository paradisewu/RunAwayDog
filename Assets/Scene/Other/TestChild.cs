using UnityEngine;
using System.Collections;

public class TestChild : TestParent
{

    void Start()
    {
        Debug.LogError("这是子类Start");
    }
    void Update()
    {

    }
}
