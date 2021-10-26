using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    int speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        movement3();
    }
    private void movement3()
    {
        if (Input.GetKey("w"))
        {
            if (transform.eulerAngles.y < 90 && transform.eulerAngles.y >= 0)
            {
                rb.velocity = new Vector3((transform.eulerAngles.y / 90) * speed, rb.velocity.y, (1 - transform.eulerAngles.y / 90) * speed);
            }
            else if (transform.eulerAngles.y >= 90 && transform.eulerAngles.y < 180)
            {
                rb.velocity = new Vector3((1 - (transform.eulerAngles.y - 90) / 90) * speed, rb.velocity.y, -((transform.eulerAngles.y - 90) / 90) * speed);
            }


            else if (transform.eulerAngles.y >= 270 && transform.eulerAngles.y < 360)
            {
                rb.velocity = new Vector3(-(1 - (transform.eulerAngles.y - 270) / 90) * speed, rb.velocity.y, ((transform.eulerAngles.y - 270) / 90) * speed);
            }

            else if (transform.eulerAngles.y >= 180 && transform.eulerAngles.y < 270)
            {
                rb.velocity = new Vector3(-((transform.eulerAngles.y - 180) / 90) * speed, rb.velocity.y, -(1 - (transform.eulerAngles.y - 180) / 90) * speed);
            }

        }
        else if (Input.GetKey("s"))
        {
            if (transform.eulerAngles.y < 90 && transform.eulerAngles.y >= 0)
            {
                rb.velocity = new Vector3((transform.eulerAngles.y / 90) * -speed, rb.velocity.y, (1 - transform.eulerAngles.y / 90) * -speed);
            }
            else if (transform.eulerAngles.y >= 90 && transform.eulerAngles.y < 180)
            {
                rb.velocity = new Vector3((1 - (transform.eulerAngles.y - 90) / 90) * -speed, rb.velocity.y, -((transform.eulerAngles.y - 90) / 90) * -speed);
            }


            else if (transform.eulerAngles.y >= 270 && transform.eulerAngles.y < 360)
            {
                rb.velocity = new Vector3(-(1 - (transform.eulerAngles.y - 270) / 90) * -speed, rb.velocity.y, ((transform.eulerAngles.y - 270) / 90) * -speed);
            }

            else if (transform.eulerAngles.y >= 180 && transform.eulerAngles.y < 270)
            {
                rb.velocity = new Vector3(-((transform.eulerAngles.y - 180) / 90) * -speed, rb.velocity.y, -(1 - (transform.eulerAngles.y - 180) / 90) * -speed);
            }
        }
        else if (Input.GetKey("a"))
        {
            if (transform.eulerAngles.y < 90 && transform.eulerAngles.y >= 0)
            {
                rb.velocity = new Vector3(-(1 - transform.eulerAngles.y / 90) * speed, rb.velocity.y, (transform.eulerAngles.y / 90) * speed);
            }
            else if (transform.eulerAngles.y >= 90 && transform.eulerAngles.y < 180)
            {
                rb.velocity = new Vector3(((transform.eulerAngles.y - 90) / 90) * speed, rb.velocity.y, (1 - (transform.eulerAngles.y - 90) / 90) * speed);
            }


            else if (transform.eulerAngles.y >= 270 && transform.eulerAngles.y < 360)
            {
                rb.velocity = new Vector3(-((transform.eulerAngles.y - 270) / 90) * speed, rb.velocity.y, -(1 - (transform.eulerAngles.y - 270) / 90) * speed);
            }

            else if (transform.eulerAngles.y >= 180 && transform.eulerAngles.y < 270)
            {
                rb.velocity = new Vector3((1 - (transform.eulerAngles.y - 180) / 90) * speed, rb.velocity.y, -((transform.eulerAngles.y - 180) / 90) * speed);
            }
        }
        else if (Input.GetKey("d"))
        {
            if (transform.eulerAngles.y < 90 && transform.eulerAngles.y >= 0)
            {
                rb.velocity = new Vector3(-(1 - transform.eulerAngles.y / 90) * -speed, rb.velocity.y, (transform.eulerAngles.y / 90) * -speed);
            }
            else if (transform.eulerAngles.y >= 90 && transform.eulerAngles.y < 180)
            {
                rb.velocity = new Vector3(((transform.eulerAngles.y - 90) / 90) * -speed, rb.velocity.y, (1 - (transform.eulerAngles.y - 90) / 90) * -speed);
            }


            else if (transform.eulerAngles.y >= 270 && transform.eulerAngles.y < 360)
            {
                rb.velocity = new Vector3(-((transform.eulerAngles.y - 270) / 90) * -speed, rb.velocity.y, -(1 - (transform.eulerAngles.y - 270) / 90) * -speed);
            }

            else if (transform.eulerAngles.y >= 180 && transform.eulerAngles.y < 270)
            {
                rb.velocity = new Vector3((1 - (transform.eulerAngles.y - 180) / 90) * -speed, rb.velocity.y, -((transform.eulerAngles.y - 180) / 90) * -speed);
            }
        }

        if (Input.GetKeyDown("space"))
        {
            rb.velocity = new Vector3(rb.velocity.x, 3, rb.velocity.z);
        }
    }
}
