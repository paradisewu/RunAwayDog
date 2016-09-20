using UnityEngine;
using System.Collections;

public class changeRect : MonoBehaviour
{

    void Start()
    {
        RectTransform rect = GetComponent<RectTransform>();

        rect.localPosition = new Vector2(100, 0);
    }

    
}
