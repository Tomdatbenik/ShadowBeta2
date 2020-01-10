using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionManager : MonoBehaviour
{
    public float widthAspect;
    public float heightAspect;

    // Start is called before the first frame update
    void Start()
    {
        float targetAspect = widthAspect / heightAspect;

        float windowAspect = (float) Screen.width / Screen.height;

        float scaleHeight = windowAspect / targetAspect;

        Camera camera = GetComponent<Camera>();

        if (scaleHeight < 1.0f)
        {
            Rect rect = camera.rect;
            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.y = (1.0f - scaleHeight) / 2.0f;
            camera.rect = rect;
        }
        else
        {
            float scaleWidth = 1.0f / scaleHeight;
            Rect rect = camera.rect;
            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            camera.rect = rect;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
