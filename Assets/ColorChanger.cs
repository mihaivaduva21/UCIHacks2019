using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Material sphere_m;
    public Rigidbody sphere_rb;

    // Start is called before the first frame update
    void Start()
    {
        sphere_m = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
       OVRInput.Update();
       if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))
        {
            if (sphere_m.color == Color.red)
            {
                sphere_m.color = Color.blue;
            }
            else if (sphere_m.color == Color.blue)
            {
                sphere_m.color = Color.green;
            }
            else if (sphere_m.color == Color.green)
            {
                sphere_m.color = Color.yellow;
            }
            else
            {
                sphere_m.color = Color.red;
            }
        }
    }
}
