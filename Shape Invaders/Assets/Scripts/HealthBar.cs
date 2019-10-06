using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public RectTransform rect;
    public float smoothSpeed = 0.125f;

    private float maxValue;
    private float value;
    private float stretch;
    public void Start()
    {
        stretch = rect.localScale.x;
    }

    public void UpdateHealth(float max, float val)
    {
        maxValue = max;
        value = val;
        stretch = (value / maxValue) * rect.localScale.x;
    }

    public void Update()
    {


        Vector3 newScale = new Vector3(stretch, rect.localScale.y, rect.localScale.z);
        rect.localScale = Vector3.Lerp(rect.localScale, newScale, smoothSpeed);
    }
}
