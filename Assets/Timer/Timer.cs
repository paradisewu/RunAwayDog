using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text mytext;
    public float TimeOver = 1f;
    public int index = 0;
    public void FixedUpdate()
    {
        //Debug.Log(Time.fixedDeltaTime);
        //TimeOver -= Time.fixedDeltaTime;
        //if (TimeOver <= 0)
        //{
        //    TimeOver = 1;
        //    index++;
        //    mytext.text = index + "";
        //}
    }

    public void Update()
    {
        TimeOver -= Time.deltaTime;
        if (TimeOver <= 0)
        {
            TimeOver = 1;
            index++;
            mytext.text = index + "";
        }
    }
}
