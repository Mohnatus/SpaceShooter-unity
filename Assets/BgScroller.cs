using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScroller : MonoBehaviour
{
    public float speed; // скорость прокрутки фона

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * speed, transform.localScale.y);
        transform.position = startPosition + Vector3.back * newPosition;
    }
}
