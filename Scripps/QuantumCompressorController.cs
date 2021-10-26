using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuantumCompressorController : MonoBehaviour
{
    public int[] totalEatenCubes;
    GameObject TheMainCamera;
    bool ready;
    // Start is called before the first frame update
    void Start()
    {
        TheMainCamera = GameObject.Find("Main Camera");

        totalEatenCubes = new int[8];
    }

    // Update is called once per frame
    void Update()
    {
        cubeCruncher();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ball")
        {
            if (totalEatenCubes[int.Parse(other.name)] < 1000)
            {
                totalEatenCubes[int.Parse(other.name)] += 1;
                Destroy(other.gameObject);
            }
            else
            {
                other.transform.position = new Vector3(transform.position.x, transform.position.y - 2, transform.position.z + 4);
                other.attachedRigidbody.velocity = new Vector3(0,0,0);
            }
        }
    }

    private void cubeCruncher()
    {
        ready = true;
        for(int i = 1; i < 7; i++)
        {
            if(totalEatenCubes[i] != 1000)
            {
                ready = false;
            }
        }
        if (ready)
        {
            totalEatenCubes = new int[8];
            Instantiate(TheMainCamera.GetComponent<CameraController>().cubes[0], new Vector3(transform.position.x, transform.position.y-2, transform.position.z - 4), Quaternion.identity);
        }
    }
}
