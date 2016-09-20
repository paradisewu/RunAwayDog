using UnityEngine;
using System.Collections;

public class Line2DTo3D : MonoBehaviour
{
    //场景中的3D物体
    public Transform Gameobject3D;  

    //场景中的UI
    public RectTransform Gameobject2D;

    //场景Canvas
    public Canvas canvas;

    public LineRenderer line;
   
    void Update()
    {
        line.SetPosition(0, Gameobject3D.transform.position);

        //将UI坐标转换成3D坐标
        Vector3 scr = RectTransformUtility.WorldToScreenPoint(canvas.worldCamera, Gameobject2D.position);
        scr.z = Mathf.Abs(Camera.main.transform.position.z - Gameobject2D.position.z);
        Vector3 localpoint = Camera.main.ScreenToWorldPoint(scr);


        line.SetPosition(1, localpoint);
    }
}
