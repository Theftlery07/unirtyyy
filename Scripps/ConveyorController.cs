using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorController : MonoBehaviour
{
    Collider coll;
    Rigidbody rb;
    public int speed = 2;
    Collider[] colliders;
    Collider[] secondColliders;
    bool up = true;
    bool down = true;
    bool left = true;
    bool right = true;
    public int ballCounter;
    public int teir;
    public int speedTeir;
    int oldTeir;
    
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
        wait();
    }

    // Update is called once per frame
    void Update()
    {

        if (gameObject.name == "new")
        {
            doubleChungus();
        }
        if (speedTeir != oldTeir)
        {
            speed += 1;
            oldTeir = speedTeir;
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "ball")
        {
            chungus();
        }
    }
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "ball" || other.gameObject.tag == "player" )
        {
            if (transform.eulerAngles.y == 0)
            {
                other.rigidbody.velocity = new Vector3(other.rigidbody.velocity.x, 0, -speed);
            }
            else if (transform.eulerAngles.y == 90)
            {
                other.rigidbody.velocity = new Vector3(-speed, 0, other.rigidbody.velocity.z);
            }
            else if (transform.eulerAngles.y == 180)
            {
                other.rigidbody.velocity = new Vector3(other.rigidbody.velocity.x, 0, speed);
            }
            else if (transform.eulerAngles.y == 270)
            {
                other.rigidbody.velocity = new Vector3(speed, 0, other.rigidbody.velocity.z);
            }
        }
    }

    private void chungus()
    {
        if ((colliders = Physics.OverlapSphere(transform.position, .5f)).Length > 1)
        {
            foreach (var collider in colliders)
            {
                var go = collider.gameObject;
                if (go.tag == "conveyor" && (go.transform.position.x == transform.position.x || go.transform.position.z == transform.position.z))
                {
                    if (go.transform.position.x > transform.position.x && (go.transform.eulerAngles.y == 90 || transform.eulerAngles.y == 270))
                    {
                        up = false;
                    }
                    if (go.transform.position.x < transform.position.x && (go.transform.eulerAngles.y == 270 || transform.eulerAngles.y == 90))
                    {
                        down = false;
                    }
                    if (go.transform.position.z > transform.position.z && (go.transform.eulerAngles.y == 0 || transform.eulerAngles.y == 180))
                    {
                        left = false;
                    }
                    if (go.transform.position.z < transform.position.z && (go.transform.eulerAngles.y == 180 || transform.eulerAngles.y == 0))
                    {
                        right = false;
                    }
                }
                else if (go.tag == "wall")
                {
                    if (go.transform.position.x > transform.position.x)
                    {
                        up = false;
                    }
                    else if (go.transform.position.x < transform.position.x)
                    {
                        down = false;
                    }
                    else if (go.transform.position.z > transform.position.z)
                    {
                        left = false;
                    }
                    else if (go.transform.position.z < transform.position.z)
                    {
                        right = false;
                    }
                }
            }
        }
        if (up && transform.eulerAngles.y != 270)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.localScale = new Vector3(.1f, .25f, 1);
            cube.transform.position = new Vector3(transform.position.x + .45f, transform.position.y + .18f, transform.position.z);
            cube.tag = "wall";
            cube.layer = 2;
        }
        if (down && transform.eulerAngles.y != 90)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.localScale = new Vector3(.1f, .25f, 1);
            cube.transform.position = new Vector3(transform.position.x - .45f, transform.position.y + .18f, transform.position.z);
            cube.tag = "wall";
            cube.layer = 2;

        }
        if (left && transform.eulerAngles.y != 180)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.localScale = new Vector3(1, .25f, .1f);
            cube.transform.position = new Vector3(transform.position.x, transform.position.y + .18f, transform.position.z + .45f);
            cube.tag = "wall";
            cube.layer = 2;

        }
        if (right && transform.eulerAngles.y != 0)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.localScale = new Vector3(1, .25f, .1f);
            cube.transform.position = new Vector3(transform.position.x, transform.position.y + .18f, transform.position.z - .45f);
            cube.tag = "wall";
            cube.layer = 2;

        }

        up = true;
        down = true;
        left = true;
        right = true;
    }
    private void antiChungus()
    {
        if ((colliders = Physics.OverlapSphere(transform.position, .55f)).Length > 1)
        {
            foreach (var collider in colliders)
            {
                var go = collider.gameObject;
                if(go.tag == "wall")
                {
                    Destroy(go);
                }
            }
        }
    }
    IEnumerator antiChungusCoroutine()
    {
        yield return new WaitForSeconds(1);
        ballCounter = 0;
        if ((colliders = Physics.OverlapSphere(transform.position, .5f)).Length > 1)
        {
            foreach (var collider in colliders)
            {
                var go = collider.gameObject;
                if (go.tag == "ball")
                {
                    ballCounter += 1;
                }
            }
        }
        if (ballCounter == 0)
        {
            yield return new WaitForSeconds(1);

            if ((colliders = Physics.OverlapSphere(transform.position, .5f)).Length > 1)
            {
                foreach (var collider in colliders)
                {
                    var go = collider.gameObject;
                    if (go.tag == "ball")
                    {
                        ballCounter += 1;
                    }
                }
            }
            if (ballCounter == 0)
            {
                antiChungus();
            }
        }
        wait();
    }
    private void wait()
    {
        StartCoroutine(antiChungusCoroutine());
    }
    
    private void doubleChungus()
    {
        if ((secondColliders = Physics.OverlapSphere(transform.position, 1f)).Length > 1)
        {
            foreach (var collider in secondColliders)
            {
                var go = collider.gameObject;
                if (go.tag == "conveyor" && (go.transform.position.x == transform.position.x || go.transform.position.z == transform.position.z))
                {
                    if (go.transform.position.x > transform.position.x && (go.transform.eulerAngles.y == 90 || transform.eulerAngles.y == 270))
                    {
                        up = false;
                    }
                    if (go.transform.position.x < transform.position.x && (go.transform.eulerAngles.y == 270 || transform.eulerAngles.y == 90))
                    {
                        down = false;
                    }
                    if (go.transform.position.z > transform.position.z && (go.transform.eulerAngles.y == 0 || transform.eulerAngles.y == 180))
                    {
                        left = false;
                    }
                    if (go.transform.position.z < transform.position.z && (go.transform.eulerAngles.y == 180 || transform.eulerAngles.y == 0))
                    {
                        right = false;
                    }
                }
                else if (go.tag == "wall" && (go.transform.position.x == transform.position.x || go.transform.position.z == transform.position.z))
                {
                    if (go.transform.position.x > transform.position.x && !up)
                    {
                        print("done");
                        Destroy(go.gameObject);
                    }
                    else if (go.transform.position.x < transform.position.x && !down)
                    {
                        print("done");
                        Destroy(go.gameObject);
                    }
                    else if (go.transform.position.z > transform.position.z && !left)
                    {
                        print("done");
                        Destroy(go.gameObject);
                    }
                    else if (go.transform.position.z - .5f < transform.position.z && !right)
                    {
                        print("done");
                        Destroy(go.gameObject);
                    }
                    print(go.transform.position);
                    print(transform.position);
                }
            }
        }
        print(up);
        print(down);
        print(left);
        print(right);
        gameObject.name = "conveyor";
    }
}
