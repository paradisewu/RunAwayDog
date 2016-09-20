using UnityEngine;
using System.Collections;

public class ClickKey : MonoBehaviour {

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            loadscene.instance.Dothing();
        }
	}
}
