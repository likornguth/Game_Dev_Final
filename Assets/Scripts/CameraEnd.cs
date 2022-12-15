using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEnd : MonoBehaviour
{
    // Start is called before the first frame update

    //SOUND
    public AudioClip impact;
    public AudioClip Mbreak;

    bool isShaking = false;
    [SerializeField] float shakeDuration = 2;
    float shakeStartTime = 0;
    [SerializeField] float shakeScale = 0.1f;
    Vector3 originalPos;
    [SerializeField] float moveTimeScale = 20;
    [SerializeField] float shakeFrequency = 20;
    void Start()
    {
        originalPos = transform.position;
        triggerShake();
    }

    // Update is called once per frame
    void Update()
    {

        if (isShaking && Time.time < shakeStartTime + shakeDuration)
        {
            transform.position += Mathf.Sin(Time.time * shakeFrequency) * shakeScale * Vector3.up;
            transform.position += Mathf.Cos(Time.time * shakeFrequency) * shakeScale * Vector3.right;
        }
        else
        {
            isShaking = false;
            transform.position = Vector3.Lerp(transform.position, originalPos, Time.deltaTime * moveTimeScale);
        }
    }

    public void triggerShake()
    {
        originalPos = transform.position;
        isShaking = true;
        shakeStartTime = Time.time;
    }
}
