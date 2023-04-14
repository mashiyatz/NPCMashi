using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSizeAndColor : MonoBehaviour
{
    private float minSize;
    private float maxSize;
    private float scale;
    private Renderer rend;

    private void Awake()
    {
        minSize = 0.02f;
        maxSize = 0.1f;
        rend = GetComponent<Renderer>();
    }

    void Start()
    {
        rend.material.color = Random.ColorHSV(0, 1, 0, 1, 0, 1);
        scale = Random.Range(minSize, maxSize);
        transform.localScale = new Vector3(scale, scale, scale);
    }
}
