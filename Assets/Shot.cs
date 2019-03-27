using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public float speed;

    void Start()
    {
        float yRotation = -(transform.rotation.eulerAngles.y + 90) * Mathf.PI / 180;

        GetComponent<Rigidbody>().velocity = new Vector3(
            -Mathf.Cos(yRotation) * speed, 
            0,
            -Mathf.Sin(yRotation) * speed
        );
    }
}
