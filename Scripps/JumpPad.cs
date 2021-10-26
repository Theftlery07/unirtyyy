using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    Collider coll;
    Rigidbody rb;
    public float Vspeed = 5;
    public float Hspeed = 1;
    public float JumpPadPower = 1;
    public float rotationValue = 75;
    public GameObject ball;
    GameObject ballHolder;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ball" || other.gameObject.tag == "player" || other.gameObject.tag == "canned")
        {
            if (transform.eulerAngles.y == 0)
            {
                other.attachedRigidbody.velocity = new Vector3(0,   Mathf.Sqrt((JumpPadPower*10)/Mathf.Sin((2f*rotationValue)/Mathf.Rad2Deg))*Mathf.Sin(rotationValue / Mathf.Rad2Deg)   , Mathf.Sqrt((JumpPadPower*10) / Mathf.Sin((2f * rotationValue) / Mathf.Rad2Deg)) * Mathf.Cos(rotationValue / Mathf.Rad2Deg));
            }
            else if (transform.eulerAngles.y == 90)
            {
                other.attachedRigidbody.velocity = new Vector3(Mathf.Sqrt((JumpPadPower * 10) / Mathf.Sin((2f * rotationValue) / Mathf.Rad2Deg)) * Mathf.Cos(rotationValue / Mathf.Rad2Deg), Mathf.Sqrt((JumpPadPower * 10) / Mathf.Sin((2f * rotationValue) / Mathf.Rad2Deg)) * Mathf.Sin(rotationValue / Mathf.Rad2Deg), 0);
            }
            else if (transform.eulerAngles.y == 180)
            {
                other.attachedRigidbody.velocity = new Vector3(0, Mathf.Sqrt((JumpPadPower * 10) / Mathf.Sin((2f * rotationValue) / Mathf.Rad2Deg)) * Mathf.Sin(rotationValue / Mathf.Rad2Deg), -(Mathf.Sqrt((JumpPadPower * 10) / Mathf.Sin((2f * rotationValue) / Mathf.Rad2Deg)) * Mathf.Cos(rotationValue / Mathf.Rad2Deg)));
            }
            else if (transform.eulerAngles.y == 270)
            {
                other.attachedRigidbody.velocity = new Vector3(-(Mathf.Sqrt((JumpPadPower * 10) / Mathf.Sin((2f * rotationValue) / Mathf.Rad2Deg)) * Mathf.Cos(rotationValue / Mathf.Rad2Deg)), Mathf.Sqrt((JumpPadPower * 10) / Mathf.Sin((2f * rotationValue) / Mathf.Rad2Deg)) * Mathf.Sin(rotationValue / Mathf.Rad2Deg), 0);
            }
        }
    }
    public void trail()
    {
        ballHolder = Instantiate(ball, new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z), Quaternion.identity);
    }
    public void destroyBall()
    {
        Destroy(ballHolder);
    }
}