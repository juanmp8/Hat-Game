using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    void Start()
    {
        SpriteRenderer sprite = GetComponentInChildren<SpriteRenderer>();
        Vector3 scaleTemp = GetComponentInChildren<Transform>().transform.localScale;

        float width = sprite.bounds.size.x;
        float height = sprite.bounds.size.y;
        float heightCamera = Camera.main.orthographicSize * 2.0f;
        float widhtWorld = heightCamera / Screen.height * Screen.width;

        scaleTemp.x = widhtWorld / width;
        scaleTemp.y = heightCamera / height;

        transform.localScale = scaleTemp;
    }

}
