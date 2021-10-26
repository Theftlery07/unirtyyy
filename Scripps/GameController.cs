using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    string userInput;
    Rigidbody rb;
    Collider coll;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        VR();
    }
    void VR(){
        if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstick))
        {
            rb.velocity = new Vector2(5, 0);
        }
        if (OVRInput.GetDown(OVRInput.Touch.One))
        {
            rb.velocity = new Vector2(-5, 0);
        }
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.GetActiveController()))
        {
            rb.velocity = new Vector2(0, 5);
        }
    }
}
