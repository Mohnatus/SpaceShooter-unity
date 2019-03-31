using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerShip : MonoBehaviour
{

    public float speed;
    public float tilt; // наклон
    public Boundary boundary;

    public GameObject[] mainGuns;
    public GameObject[] secondaryGuns;

    public float shotDelay;

    private float nextShotMain; 
    private float nextShotSecondary; 

    void Update()
    {
        bool canShootMain = Time.time > nextShotMain;
        bool canShootSecondary = Time.time > nextShotSecondary;

        if (Input.GetButton("Fire1") && canShootMain)
        {
            nextShotMain = Time.time + shotDelay;
            for (int i = 0; i < mainGuns.Length; i++)
            {
                mainGuns[i].GetComponent<LaserGun>().Shot();
            }
        }

        if (Input.GetButton("Fire2") && canShootSecondary)
        {
            nextShotSecondary = Time.time + shotDelay / 2;
            for (int i = 0; i < secondaryGuns.Length; i++)
            {
                secondaryGuns[i].GetComponent<LaserGun>().Shot();
            }
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
