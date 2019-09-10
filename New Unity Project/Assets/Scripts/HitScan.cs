using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScan : MonoBehaviour
{

    public Transform gunBarrel;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int layerMask = 1 << 8;

        layerMask = ~layerMask;

        RaycastHit hit;
        if (Physics.Raycast(gunBarrel.position, gunBarrel.forward, out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(gunBarrel.position, gunBarrel.forward * hit.distance, Color.magenta);
        }
        else
        {
            Debug.DrawRay(gunBarrel.position, gunBarrel.forward * 1000, Color.red);
        }
    }
}


