using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour

{ 

    void Update()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.x < 0.1f) pos.x = 0.1f;
        if (pos.x > 0.9f) pos.x = 0.9f;
        if (pos.y < 0.1f) pos.y = 0.1f;
        if (pos.y > 0.9f) pos.y = 0.9f;

        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }






}

