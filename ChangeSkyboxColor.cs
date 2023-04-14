using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkyboxColor : MonoBehaviour
{
    private Material skyboxMat;

    public Color sunDiscColor1;
    public Color sunHaloColor1;
    public Color horizonLineColor1;
    public Color skyGradientTopColor1;
    public Color skyGradientBotColor1;
    public float sunDiscMultiplier1;
    public float sunDiscExponent1;
    public float sunHaloExponent1;
    public float sunHaloContribution1;
    public float horizonLineExponent1;
    public float horizonLineContribution1;
    public float skyGradientExponent1;

    public Color sunDiscColor2;
    public Color sunHaloColor2;
    public Color horizonLineColor2;
    public Color skyGradientTopColor2;
    public Color skyGradientBotColor2;
    public float sunDiscMultiplier2;
    public float sunDiscExponent2;
    public float sunHaloExponent2;
    public float sunHaloContribution2;
    public float horizonLineExponent2;
    public float horizonLineContribution2;
    public float skyGradientExponent2;

    public Color sunDiscColor3;
    public Color sunHaloColor3;
    public Color horizonLineColor3;
    public Color skyGradientTopColor3;
    public Color skyGradientBotColor3;
    public float sunDiscMultiplier3;
    public float sunDiscExponent3;
    public float sunHaloExponent3;
    public float sunHaloContribution3;
    public float horizonLineExponent3;
    public float horizonLineContribution3;
    public float skyGradientExponent3;


    private void Awake()
    {
        skyboxMat = RenderSettings.skybox;
    }

    void Start()
    {
        UpdateSkybox(
            sunDiscColor1,
            sunHaloColor1,
            horizonLineColor1,
            skyGradientTopColor1,
            skyGradientBotColor1,
            sunDiscMultiplier1,
            sunDiscExponent1,
            sunHaloExponent1,
            sunHaloContribution1,
            horizonLineExponent1,
            horizonLineContribution1,
            skyGradientExponent1
        );
        StartCoroutine(TransitionToDusk());
    }

    void UpdateSkybox(
        Color sunDiscColor,
        Color sunHaloColor,
        Color horizonLineColor,
        Color skyGradientTopColor,
        Color skyGradientBotColor,
        float sunDiscMultiplier,
        float sunDiscExponent,
        float sunHaloExponent,
        float sunHaloContribution,
        float horizonLineExponent,
        float horizonLineContribution,
        float skyGradientExponent
        )
    { 
        skyboxMat.SetColor("_SunDiscColor", sunDiscColor);
        skyboxMat.SetColor("_SunHaloColor", sunHaloColor);
        skyboxMat.SetColor("_HorizonLineColor", horizonLineColor);
        skyboxMat.SetColor("_SkyGradientTop", skyGradientTopColor);
        skyboxMat.SetColor("_SkyGradientBottom", skyGradientBotColor);
        skyboxMat.SetFloat("_SunDiscMultiplier", sunDiscMultiplier);
        skyboxMat.SetFloat("_SunDiscExponent", sunDiscExponent);
        skyboxMat.SetFloat("_SunHaloExponent", sunHaloExponent);
        skyboxMat.SetFloat("_SunHaloContribution", sunHaloContribution);
        skyboxMat.SetFloat("_HorizonLineExponent", horizonLineExponent);
        skyboxMat.SetFloat("_HorizonLineContribution", horizonLineContribution);
        skyboxMat.SetFloat("_SkyGradientExponent", skyGradientExponent);

    }

    void Update()
    {

    }

    IEnumerator TransitionToDusk()
    {
        float startTime = Time.time;
        while (Time.time - startTime <= 30)
        {
            UpdateSkybox(
                Color.Lerp(sunDiscColor1, sunDiscColor2, (Time.time - startTime) / 30),
                Color.Lerp(sunHaloColor1, sunHaloColor2, (Time.time - startTime) / 30),
                Color.Lerp(horizonLineColor1, horizonLineColor2, (Time.time - startTime) / 30),
                Color.Lerp(skyGradientTopColor1, skyGradientTopColor2, (Time.time - startTime) / 30),
                Color.Lerp(skyGradientBotColor1, skyGradientBotColor2, (Time.time - startTime) / 30),
                Mathf.Lerp(sunDiscMultiplier1, sunDiscMultiplier2, (Time.time - startTime) / 30),
                Mathf.Lerp(sunDiscExponent1, sunDiscExponent2, (Time.time - startTime) / 30),
                Mathf.Lerp(sunHaloExponent1, sunHaloExponent2, (Time.time - startTime) / 30),
                Mathf.Lerp(sunHaloContribution1, sunHaloContribution2, (Time.time - startTime) / 30),
                Mathf.Lerp(horizonLineExponent1, horizonLineExponent2, (Time.time - startTime) / 30),
                Mathf.Lerp(horizonLineContribution1, horizonLineContribution2, (Time.time - startTime) / 30),
                Mathf.Lerp(skyGradientExponent1, skyGradientExponent2, (Time.time - startTime) / 30)
            );
            yield return null;
        }
        StartCoroutine(TransitionToNight());
    }

    IEnumerator TransitionToNight()
    {
        float startTime = Time.time;
        while (Time.time - startTime <= 30)
        {
            UpdateSkybox(
                Color.Lerp(sunDiscColor2, sunDiscColor3, (Time.time - startTime) / 30),
                Color.Lerp(sunHaloColor2, sunHaloColor3, (Time.time - startTime) / 30),
                Color.Lerp(horizonLineColor2, horizonLineColor3, (Time.time - startTime) / 30),
                Color.Lerp(skyGradientTopColor2, skyGradientTopColor3, (Time.time - startTime) / 30),
                Color.Lerp(skyGradientBotColor2, skyGradientBotColor3, (Time.time - startTime) / 30),
                Mathf.Lerp(sunDiscMultiplier2, sunDiscMultiplier3, (Time.time - startTime) / 30),
                Mathf.Lerp(sunDiscExponent2, sunDiscExponent3, (Time.time - startTime) / 30),
                Mathf.Lerp(sunHaloExponent2, sunHaloExponent3, (Time.time - startTime) / 30),
                Mathf.Lerp(sunHaloContribution2, sunHaloContribution3, (Time.time - startTime) / 30),
                Mathf.Lerp(horizonLineExponent2, horizonLineExponent3, (Time.time - startTime) / 30),
                Mathf.Lerp(horizonLineContribution2, horizonLineContribution3, (Time.time - startTime) / 30),
                Mathf.Lerp(skyGradientExponent2, skyGradientExponent3, (Time.time - startTime) / 30)
            );
            yield return null;
        }
        StartCoroutine(TransitionToDay());
    }

    IEnumerator TransitionToDay()
    {
        float startTime = Time.time;
        while (Time.time - startTime <= 30)
        {
            UpdateSkybox(
                Color.Lerp(sunDiscColor3, sunDiscColor1, (Time.time - startTime) / 30),
                Color.Lerp(sunHaloColor3, sunHaloColor1, (Time.time - startTime) / 30),
                Color.Lerp(horizonLineColor3, horizonLineColor1, (Time.time - startTime) / 30),
                Color.Lerp(skyGradientTopColor3, skyGradientTopColor1, (Time.time - startTime) / 30),
                Color.Lerp(skyGradientBotColor3, skyGradientBotColor1, (Time.time - startTime) / 30),
                Mathf.Lerp(sunDiscMultiplier3, sunDiscMultiplier1, (Time.time - startTime) / 30),
                Mathf.Lerp(sunDiscExponent3, sunDiscExponent1, (Time.time - startTime) / 30),
                Mathf.Lerp(sunHaloExponent3, sunHaloExponent1, (Time.time - startTime) / 30),
                Mathf.Lerp(sunHaloContribution3, sunHaloContribution1, (Time.time - startTime) / 30),
                Mathf.Lerp(horizonLineExponent3, horizonLineExponent1, (Time.time - startTime) / 30),
                Mathf.Lerp(horizonLineContribution3, horizonLineContribution1, (Time.time - startTime) / 30),
                Mathf.Lerp(skyGradientExponent3, skyGradientExponent1, (Time.time - startTime) / 30)
            );
            yield return null;
        }
        StartCoroutine(TransitionToDusk());
    }
}
