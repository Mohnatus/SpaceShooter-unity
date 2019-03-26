﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerShipScript : MonoBehaviour
{

    public float speed;
    public float tilt; // наклон
    public Boundary boundary;

    public GameObject lazerShot;
    public GameObject lazerGun;
    public float shotDelay;

    private float nextShot; // время следующего выстрела
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool canShoot = Time.time > nextShot;

        if (Input.GetButton("Fire1") && canShoot)
        {
            nextShot = Time.time + shotDelay;
            Instantiate(lazerShot, lazerGun.transform.position, Quaternion.identity);
        }
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Rigidbody ship = GetComponent<Rigidbody>();

        ship.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;
        ship.rotation = Quaternion.Euler(ship.velocity.z * tilt, 0, -ship.velocity.x * tilt);

        float xPosition = Mathf.Clamp(ship.position.x, boundary.xMin, boundary.xMax);
        float zPosition = Mathf.Clamp(ship.position.z, boundary.zMin, boundary.zMax);

        ship.position = new Vector3(xPosition, 0, zPosition);
    }
}
