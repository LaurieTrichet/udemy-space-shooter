using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResizer : MonoBehaviour
{

    [SerializeField] Camera targetCamera = null;

    void Start()
    {
        float ratioGame = 9.0f/16.0f;
        float ratioScreen = Screen.width / Screen.height;
        float width = ratioGame * Screen.height / ratioScreen;
        float normalizedWidth = width/Screen.width;
        float centeredX = (1.0f - normalizedWidth) / 2.0f;
        targetCamera.rect = new Rect(new Vector2(centeredX, 0.0f), new Vector2(normalizedWidth, 1.0f));
    }


}
