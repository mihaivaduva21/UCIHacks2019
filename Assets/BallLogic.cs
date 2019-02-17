using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BallLogic : MonoBehaviour
{
    public Material sphere_m;
    protected Dictionary<Color, int> hash_types;
    public int type_id;
    public bool isPointer;
    public Rigidbody sphere_rb;
    public bool in_box;


    // Start is called before the first frame update
    void Start()
    {
        isPointer = false;
        sphere_m = GetComponent<Renderer>().material;
        sphere_m.color = Color.red;
        // Initialize hash table
        hash_types.Add(Color.red, 0);
        hash_types.Add(Color.blue, 1);
        hash_types.Add(Color.green, 2);
        hash_types.Add(Color.yellow, 3);
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
        type_id = hash_types[sphere_m.color];


    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody>() != null)
        {
            gameObject.AddComponent<FixedJoint>();
            gameObject.GetComponent<FixedJoint>().connectedBody = collision.rigidbody;

        }
        if (collision.collider.gameObject.name == "pointer")
        {
            isPointer = true;
        }
    }

    bool CheckInBox(float Distance)
    {
        if (Vector3.Distance(sphere_rb.transform.position, new Vector3(1, 0, -3)) < Distance || Vector3.Distance(sphere_rb.transform.position, new Vector3(1, 0, -3)) == Distance)
        {
            in_box = true;
        }
        else
        {
            in_box = false;
        }
        return in_box;
    }
}
