using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour
{
    public GameObject lazerShot;

    public void Shot()
    {
        Instantiate(lazerShot, transform.position, transform.rotation);
    }
}
