using UnityEngine;
using System.Collections;

public class AnimationCure : MonoBehaviour
{

    public AnimationCurve animationCurve;
    void Update()
    {
        animationCurve.postWrapMode = WrapMode.PingPong;
        float y = animationCurve.Evaluate(Time.time);
        transform.position = new Vector3(Time.time, y, 0);
    }
}
