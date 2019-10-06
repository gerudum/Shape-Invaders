using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public float smoothSpeed = 0.125f;
    public Vector3 offset = new Vector3(0, 0, -10f);
    public Transform target;

    //Cam Transform
    public Transform camTransform;

    public float minFov = 15f;
    public float maxFov = 90f;
    public float sensitivity = 10f;

    // How long the object should shake for.
    private float shakeDuration = 0f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    private float shakeAmount = 0.7f;
    private float decreaseFactor = 1.0f;

    private Vector3 originalPos;

    public void Shake(float duration, float strength)
    {
        shakeDuration = duration;
        shakeAmount = strength;
    }

    public void Update()
    {
        float fov = Camera.main.orthographicSize;
        fov += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);

        Camera.main.orthographicSize = fov;
    }

    public void FixedUpdate()
    {
        if (target == null) return;

        transform.position = Vector3.Lerp(transform.position, target.position + offset, smoothSpeed);

        originalPos = camTransform.localPosition;

        if (shakeDuration > 0)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
        }


    }
}
