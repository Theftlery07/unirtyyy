using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCombinerController : MonoBehaviour
{
    public GameObject cube1;
    public GameObject cube2;
    public GameObject TheMainCamera;
    public bool[] flaggedForCube1;
    public bool[] flaggedForCube2;
    int rotation = 0;
    // Start is called before the first frame update
    void Start()
    {
        TheMainCamera = GameObject.Find("Main Camera");
        flaggedForCube1 = new bool[TheMainCamera.GetComponent<CameraController>().universalArrayLength];
        flaggedForCube2 = new bool[TheMainCamera.GetComponent<CameraController>().universalArrayLength];

        if (transform.eulerAngles.y == 0)
        {
            rotation = 0;
        }
        else if (transform.eulerAngles.y == 90)
        {
            rotation = 90;
        }
        else if (transform.eulerAngles.y == 180)
        {
            rotation = 180;
        }
        else if (transform.eulerAngles.y == 270)
        {
            rotation = 270;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "ball")
        {
            if (cube1 == null && !flaggedForCube1[int.Parse(other.name)])
            {
                cube1 = other.gameObject;
            }
            else if(cube2 == null && !flaggedForCube2[int.Parse(other.name)])
            {
                cube2 = other.gameObject;
            }
            if(cube2 != null && cube1 != null)
            {
                //red
                if(cube1.GetComponent<Renderer>().sharedMaterial == TheMainCamera.GetComponent<CameraController>().colorsSolid[1])
                {
                    //yellow
                    if(cube2.GetComponent<Renderer>().sharedMaterial == TheMainCamera.GetComponent<CameraController>().colorsSolid[3])
                    {
                        //orange
                        cubeCombination(2);
                    }
                    //green
                    else if (cube2.GetComponent<Renderer>().sharedMaterial == TheMainCamera.GetComponent<CameraController>().colorsSolid[4])
                    {
                        //yellow
                        cubeCombination(3);
                    }
                    //blue
                    else if (cube2.GetComponent<Renderer>().sharedMaterial == TheMainCamera.GetComponent<CameraController>().colorsSolid[5])
                    {
                        //purple
                        cubeCombination(6);
                    }
                    //nothing works
                    else
                    {
                        flaggedForCube2[int.Parse(cube2.name)] = true;
                        cube2 = null;
                    }
                }
                //yellow
                else if (cube1.GetComponent<Renderer>().sharedMaterial == TheMainCamera.GetComponent<CameraController>().colorsSolid[3])
                {
                    //yellow
                    if (cube2.GetComponent<Renderer>().sharedMaterial == TheMainCamera.GetComponent<CameraController>().colorsSolid[1])
                    {
                        //orange
                        cubeCombination(2);
                    }
                    //nothing works
                    else
                    {
                        flaggedForCube2[int.Parse(cube2.name)] = true;
                        cube2 = null;
                    }
                }
                //green
                else if (cube1.GetComponent<Renderer>().sharedMaterial == TheMainCamera.GetComponent<CameraController>().colorsSolid[4])
                {
                    //red
                    if (cube2.GetComponent<Renderer>().sharedMaterial == TheMainCamera.GetComponent<CameraController>().colorsSolid[1])
                    {
                        //yellow
                        cubeCombination(3);
                    }
                    //nothing works
                    else
                    {
                        flaggedForCube2[int.Parse(cube2.name)] = true;
                        cube2 = null;
                    }
                }
                //blue
                else if (cube1.GetComponent<Renderer>().sharedMaterial == TheMainCamera.GetComponent<CameraController>().colorsSolid[5])
                {
                    //red
                    if (cube2.GetComponent<Renderer>().sharedMaterial == TheMainCamera.GetComponent<CameraController>().colorsSolid[1])
                    {
                        //purple
                        cubeCombination(6);
                    }
                    //nothing works
                    else
                    {
                        flaggedForCube2[int.Parse(cube2.name)] = true;
                        cube2 = null;
                    }
                }
            }
            if(cube1 != null && cube2 != null)
            {
                flaggedForCube1[int.Parse(cube1.name)] = true;
                arrayReseter(flaggedForCube2);
                cube1 = null;
                cube2 = null;
            }
        }
    }
    private void arrayReseter(bool[] arrayToBeReset)
    {
        for (int i = 0; i < TheMainCamera.GetComponent<CameraController>().universalArrayLength; i++)
        {
            arrayToBeReset[i] = false;
        }
    }

    private void cubeCombination(int numberOfColor)
    {
        if (rotation == 0)
        {
            Instantiate(TheMainCamera.GetComponent<CameraController>().cubes[numberOfColor], new Vector3(transform.position.x, transform.position.y, transform.position.z - 2), Quaternion.identity);
        }
        else if (rotation == 90)
        {
            Instantiate(TheMainCamera.GetComponent<CameraController>().cubes[numberOfColor], new Vector3(transform.position.x - 2, transform.position.y, transform.position.z), Quaternion.identity);
        }
        else if (rotation == 180)
        {
            Instantiate(TheMainCamera.GetComponent<CameraController>().cubes[numberOfColor], new Vector3(transform.position.x, transform.position.y, transform.position.z + 2), Quaternion.identity);
        }
        else if (rotation  == 270)
        {
            Instantiate(TheMainCamera.GetComponent<CameraController>().cubes[numberOfColor], new Vector3(transform.position.x + 2, transform.position.y, transform.position.z), Quaternion.identity);
        }
        Destroy(cube1);
        Destroy(cube2);
        arrayReseter(flaggedForCube1);
        arrayReseter(flaggedForCube2);
    }
}
