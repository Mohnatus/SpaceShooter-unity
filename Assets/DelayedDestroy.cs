using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedDestroy : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 2);
    }
}
