using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class ResizeUI : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    public Vector2 minSize = new Vector2(100, 100);
    public Vector2 maxSize = new Vector2(400, 400);
    RectTransform parent;
    Vector2 nowSize;
    Vector2 Point;
    void Start()
    {
        parent = transform.parent.GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (parent == null)
        {
            return;
        }
        Vector2 nowpoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parent, eventData.position, eventData.pressEventCamera, out nowpoint);

        Vector2 offset = nowpoint - Point;

        Vector2 sizenow = nowSize + new Vector2(offset.x, -offset.y);

        //sizenow = new Vector2(
        //    Mathf.Clamp(sizenow.x, minSize.x, maxSize.x),
        //    Mathf.Clamp(sizenow.y, minSize.y, maxSize.y)
        //);
        parent.sizeDelta = sizenow;
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        nowSize = parent.sizeDelta;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(parent, eventData.position, eventData.pressEventCamera, out Point);

    }

}
