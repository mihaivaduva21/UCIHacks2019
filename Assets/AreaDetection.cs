using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDetection : MonoBehaviour
{
    public Rigidbody sphere_rb;
    public bool SphereInArea;

    bool InArea(float Distance)
    {
        // new Vector3(0, 0, 0) is center of box region
        if (Vector3.Distance(sphere_rb.transform.position, new Vector3(0, 0, 0)) < Distance || Vector3.Distance(sphere_rb.transform.position, new Vector3(0, 0, 0)) == Distance)
        {
            SphereInArea = true;
        }
        else
        {
            SphereInArea = false;
        }
        return SphereInArea;
    }

    // Update is called once per frame
    void Update()
    {
        // Example call
        if (InArea(5))
        {
            // Do whatever
        }
    }
}
