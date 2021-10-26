using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillController : MonoBehaviour
{
    [SerializeField] private GameObject drillyPart;
    GameObject cubeToBeCreated;
    Collider[] colliders;
    Vector3 cubePizza;

    bool mineable = false;
    bool conveyors = false;
    public int teir = 0;
    public int speedTeir = 1;
    public GameObject MainCamera;


    // Start is called before the first frame update
    void Start()
    {
        MainCamera = GameObject.Find("Main Camera");
        StartCoroutine(mining());
    }

    // Update is called once per frame
    void Update()
    {
        checkers();
        coolThing();
    }
    private void checkers()
    {
        if ((colliders = Physics.OverlapSphere(transform.position, 3f)).Length > 1)
        {
            foreach (var collider in colliders)
            {
                var go = collider.gameObject;
                if(go.tag == "conveyor")
                {
                    conveyors = true;
                    cubePizza = new Vector3(go.transform.position.x, go.transform.position.y+1, go.transform.position.z);
                }
            }
            if (conveyors)
            { 
                mineable = true;
            }
            else
            {
                mineable = false;
            }
            conveyors = false;
        }
    }
    IEnumerator mining()
    {
        yield return new WaitForSeconds(1 * (teir+1));
        mineOn();
    }
    private void mineOn()
    {
        if (mineable)
        {
            cubeCreater();
        }
        StartCoroutine(mining());
    }
    private void coolThing()
    {
        if (mineable && cubeToBeCreated != null)
        {
            drillyPart.transform.Rotate(new Vector3(0, drillyPart.transform.eulerAngles.y + 1, 0));
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "resource")
        {
            for (int j = 0; j < MainCamera.GetComponent<CameraController>().universalArrayLength; j++)
            {
                if (MainCamera.GetComponent<CameraController>().colorsSolid[j] == other.GetComponent<Renderer>().sharedMaterial)
                {
                    cubeToBeCreated = MainCamera.GetComponent<CameraController>().cubes[j];
                    for (int k = 0; k < transform.childCount; k++)
                    {
                        if (transform.GetChild(k).tag == "drillPart")
                        {
                            transform.GetChild(k).name = j.ToString();
                            transform.GetChild(k).GetComponent<Renderer>().material = MainCamera.GetComponent<CameraController>().colorsSolid[j];
                        }
                    }

                    j = MainCamera.GetComponent<CameraController>().universalArrayLength;
                }
            }
        }
    }
    private void cubeCreater()
    {
        if (cubeToBeCreated != null)
        {
            Instantiate(cubeToBeCreated, cubePizza, Quaternion.identity);
        }
    }
}
