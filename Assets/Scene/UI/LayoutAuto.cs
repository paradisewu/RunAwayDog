using UnityEngine;
using System.Collections;

public class LayoutAuto : MonoBehaviour
{
    public Transform target;
    void Start()
    {
        //RectTransformUtility.FlipLayoutAxes(GetComponent<RectTransform>(), false, false);
        //RectTransformUtility.FlipLayoutOnAxis(GetComponent<RectTransform>(), 1, true, true);
        //RectTransformUtility.PixelAdjustRect(GetComponent<RectTransform>(), GameObject.Find("Canvas").GetComponent<Canvas>());
        RectTransformUtility.PixelAdjustPoint(GetComponent<RectTransform>().localPosition, target, GameObject.Find("Canvas").GetComponent<Canvas>());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
