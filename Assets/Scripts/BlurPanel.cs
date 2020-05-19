using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(CanvasGroup))]
public class BlurPanel : Image
{
    public bool animate;
    public float time = 0.5f;
    public float delay = 0.0f;

    CanvasGroup canvasGroup;

    protected override void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    protected override void OnEnable()
    {
        if(Application.isPlaying)
        {
            material.SetFloat("_Size", 0);
            canvasGroup.alpha = 0;
            DOVirtual.Float(0, 1, time, UpdateBlur);
        }
    }

    public void StartBlur(float startValue, float targetValue, float transitionTime)
    {
        material.SetFloat("_Size", startValue);
        canvasGroup.alpha = targetValue;

        DOVirtual.Float(startValue, targetValue, transitionTime, UpdateBlur);
    }

    void UpdateBlur(float value)
    {
        material.SetFloat("_Size", value * 4);
        canvasGroup.alpha = value;
    }
}
