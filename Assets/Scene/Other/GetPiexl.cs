using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetPiexl : MonoBehaviour
{
    public Canvas _canvas;
    public RectTransform rect;
    public GameObject _uiObject;
    public Image _resultImage;

    public Rect GetSpaceRect(Canvas canvas, RectTransform rect, Camera camera)
    {
        Rect spaceRect = rect.rect;
        Vector3 spacePos = GetSpacePos(rect, canvas, camera);
        //lossyScale
        spaceRect.x = spaceRect.x * rect.lossyScale.x + spacePos.x;
        spaceRect.y = spaceRect.y * rect.lossyScale.y + spacePos.y;
        spaceRect.width = spaceRect.width * rect.lossyScale.x;
        spaceRect.height = spaceRect.height * rect.lossyScale.y;
        return spaceRect;
    }

    public bool RectContainsScreenPoint(Vector3 point, Canvas canvas, RectTransform rect, Camera camera)
    {
        if (canvas.renderMode != RenderMode.ScreenSpaceOverlay)
        {
            return RectTransformUtility.RectangleContainsScreenPoint(rect, point, camera);
        }

        return GetSpaceRect(canvas, rect, camera).Contains(point);
    }

    // Update is called once per frame
    void Update()
    {
        if (RectContainsScreenPoint(Input.mousePosition, _canvas, rect, GetComponent<Camera>()))
        {
            Image image = _uiObject.GetComponent<Image>();
            var spaceRect = GetSpaceRect(_canvas, rect, GetComponent<Camera>());
            var localPos = Input.mousePosition - new Vector3(spaceRect.x, spaceRect.y);
            var realPos = new Vector2(localPos.x, localPos.y);
            var imageToTextre = new Vector2(image.sprite.textureRect.width / spaceRect.width,
                image.sprite.textureRect.height / spaceRect.height);
            _resultImage.color = _uiObject.GetComponent<Image>().sprite.texture.GetPixel((int)(realPos.x * imageToTextre.x), (int)(realPos.y * imageToTextre.y));
        }
    }
    private Vector3 GetSpacePos(RectTransform rect, Canvas canvas, Camera camera)
    {
        if (canvas.renderMode == RenderMode.ScreenSpaceOverlay)
        {
            return rect.position;
        }
        return camera.WorldToScreenPoint(rect.position);
    }
}
