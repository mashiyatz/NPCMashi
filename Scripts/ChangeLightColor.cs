using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLightColor : MonoBehaviour
{
    public Color dayColor;
    public Color nightColor;
    public float colorChangeTime;
    public float transitionTime;

    private Light lightComponent;
    private float startTime;
    private bool isDay;

    // private Material skyboxMaterial;

    private void Awake()
    {
        lightComponent = GetComponent<Light>();
        // skyboxMaterial = RenderSettings.skybox;
    }

    void Start()
    {
        // skyboxMaterial.SetColor("_SunDiscColor", Color.black);

        lightComponent.color = dayColor;
        isDay = true;
        startTime = Time.time;
    }

    void Update()
    {
        if (Time.time - startTime >= colorChangeTime) {
            StartCoroutine(TransitionColor());
            startTime = Time.time;
        }
    }

    IEnumerator TransitionColor()
    {
        float transitionStartTime = Time.time;
        while (Time.time - transitionStartTime <= transitionTime)
        {
            if (isDay) lightComponent.color = Color.Lerp(dayColor, nightColor, (Time.time - transitionStartTime) / transitionTime);
            else lightComponent.color = Color.Lerp(nightColor, dayColor, (Time.time - transitionStartTime) / transitionTime);
            yield return null;
        }
        isDay = !isDay;
    }
}
