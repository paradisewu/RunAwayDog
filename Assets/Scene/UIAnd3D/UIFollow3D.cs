using UnityEngine;
using System.Collections;

public class UIFollow3D : MonoBehaviour
{

    public Canvas canvas;

    public GameObject CubeObj;
    void Update()
    {
        //UGUI的物体贴在世界物体上
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Camera.main.WorldToScreenPoint(CubeObj.transform.position), canvas.worldCamera, out pos);
        RectTransform rect = transform.transform as RectTransform;
        rect.anchoredPosition = pos;

        //世界物体跟随UGUI物体
        Vector3 scr = RectTransformUtility.WorldToScreenPoint(canvas.worldCamera, transform.position);
        //scr.z = 0;
        scr.z = Mathf.Abs(Camera.main.transform.position.z - transform.position.z);
        CubeObj.transform.position = Camera.main.ScreenToWorldPoint(scr);
    }
}
