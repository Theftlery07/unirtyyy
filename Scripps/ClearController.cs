using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearController : MonoBehaviour
{
    Collider[] colliders;
    public bool interfierence = false;
    bool checkplus;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        chercks();
    }
    private void chercks()
    {
        if (gameObject.transform.tag == "mine")
        {
            if ((colliders = Physics.OverlapBox(transform.position, transform.localScale*1.45f)).Length > 1)
            {
                foreach (var collider in colliders)
                {
                    var go = collider.gameObject;
                    if (go.tag != "floor" && go.tag != "ball" && go.tag != "text")
                    {
                        checkplus = true;
                    }

                }
            }
        }
        if (checkplus)
        {
            interfierence = true;
        }
        else
        {
            interfierence = false;
        }
        checkplus = false;
    }
}
