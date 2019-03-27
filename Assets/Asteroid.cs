using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float rotationSpeed;
    public float minSpeed;
    public float maxSpeed;

    void Start()
    {
        Rigidbody asteroid = GetComponent<Rigidbody>();
        asteroid.angularVelocity = Random.insideUnitSphere * rotationSpeed;
        asteroid.velocity = Vector3.back * Random.Range(minSpeed, maxSpeed);
    }

}
