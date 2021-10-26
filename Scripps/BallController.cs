using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    bool death = true;
    public GameObject MainCamera;
    // Start is called before the first frame update
    void Start()
    {
        MainCamera = GameObject.Find("Main Camera");
        for(int j = 0; j < MainCamera.GetComponent<CameraController>().universalArrayLength; j++)
        {
            if (MainCamera.GetComponent<CameraController>().colorsSolid[j] == gameObject.GetComponent<Renderer>().sharedMaterial)
            {
                name = j.ToString();
                j = MainCamera.GetComponent<CameraController>().universalArrayLength;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "floor")
        {
            StartCoroutine(delete());
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "floor")
        {
            death = false;
        }
    }
    IEnumerator delete()
    {
        yield return new WaitForSeconds(5);
        if (death)
        {
            Destroy(this.gameObject);
        }
        else
        {
            death = true;
        }
    }
}
