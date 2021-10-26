using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreController : MonoBehaviour
{
    public int[] cubeCounts;
    public int limit = 100;
    public bool deleteExtra = true;

    // Start is called before the first frame update
    void Start()
    {
        cubeCounts = new int[8];
    }

    // Update is called once per frame
    void Update()
    {
        limit = 100 + cubeCounts[7];
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ball")
        {
            if (cubeCounts[int.Parse(other.name)] < limit)
            {
                cubeCounts[int.Parse(other.name)] += 1;
                Destroy(other.gameObject);
            }
            else
            {
                if (deleteExtra)
                {
                    other.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z + 3);
                }
                else
                {
                    Destroy(other.gameObject);
                }
            }
        }
    }
}
