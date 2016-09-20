using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreateUIAuto : MonoBehaviour
{
    public Transform Parrents;
    void Start()
    {
        GameObject go = new GameObject("image");
        go.transform.parent = Parrents.transform;

        go.AddComponent<RawImage>();
        RectTransform rectTransform = go.GetComponent<RectTransform>();

        #region rectTransform.anchorMax 等于 rectTransform.anchorMin
        //anchorMax和anchorMin确定锚框，相等时即为相对与锚点位移

        rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        rectTransform.anchorMin = new Vector2(0.5f, 0.5f);

        rectTransform.localScale = Vector3.one;
        rectTransform.sizeDelta = new Vector2(500, 300);
        rectTransform.localPosition = new Vector3(50, 0, 0);
        #endregion


        #region rectTransform.anchorMax  不等于 rectTransform.anchorMin
        //anchorMax和anchorMin确定锚框，不相等时即为相对与锚点拉伸
        //rectTransform.anchorMax = Vector3.one;
        //rectTransform.anchorMin = Vector2.zero;

        //rectTransform.localScale = Vector3.one;
        ////rectTransform.offsetMax = Vector2.zero;
        ////rectTransform.offsetMin = Vector2.zero;

        //rectTransform.sizeDelta = new Vector2(0, 0);
        //rectTransform.localPosition = new Vector2(100, 0);

        #endregion



        rectTransform.SetSiblingIndex(0);        //设置相对层级关系

        rectTransform.pivot = new Vector2(0.5f, 0.5f);   //设置Rect的中心点
        Debug.LogError("rectTransform.localPosition" + rectTransform.localPosition);
        Debug.LogError("rectTransform.position" + rectTransform.position);
        Debug.LogError("rectTransform.anchoredPosition" + rectTransform.anchoredPosition);
        Debug.Log("rectTransform.rect.size：" + rectTransform.rect.size);
        Debug.Log("rectTransform.sizeDelta:" + rectTransform.sizeDelta);
        Debug.Log(rectTransform.rect.x + "," + rectTransform.rect.y);
        Debug.Log(rectTransform.rect.min + "," + rectTransform.rect.max);
        Debug.Log(rectTransform.rect.xMax + "," + rectTransform.rect.xMin);
        Debug.Log(rectTransform.rect.yMax + "," + rectTransform.rect.yMin);
        Debug.Log("rectTransform.rect.center:" + rectTransform.rect.center);
        Debug.Log("rectTransform.rect.top:" + rectTransform.rect.top);
        Debug.Log("rectTransform.rect.bottom:" + rectTransform.rect.bottom);
        Debug.Log("rectTransform.rect.height:" + rectTransform.rect.height);
        Debug.Log("rectTransform.rect.width:" + rectTransform.rect.width);
        Debug.Log("rectTransform.rect.left:" + rectTransform.rect.left);
        Debug.Log("rectTransform.rect.right:" + rectTransform.rect.right);


        #region 设置大小
        //rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 0, 0);
        //rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, 0);
        //rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Right, 0, 0);
        //rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, 0);
        #endregion


        //rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 0);
        //rectTransform.sizeDelta = Vector2.zero;
        // rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 0);
        // rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 0);
        //rectTransform.sizeDelta = new Vector2(400, 400);

        //rectTransform.rect.Set(-633, 256, 400, 500);

        //rectTransform.rect(0, 0, 0, 0);
        Debug.Log(rectTransform.rect.size);

    }

    void Update()
    {

    }
}
