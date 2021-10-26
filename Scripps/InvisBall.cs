using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisBall : MonoBehaviour
{
    Collider coll;
    public int counter;
    public int counter2;
    Vector3 start;
    public GameObject trail1;
    public GameObject trail2;

    // Start is called before the first frame update
    private void Start()
    {
        coll = GetComponent<Collider>();
        trail2.GetComponent<TrailRenderer>().emitting = false;
        start = transform.position;

    }

    // Update is called once per frame
    private void Update()
    {
        if (counter > 0)
        {
            if (transform.position.y > start.y)
            {
                StartCoroutine(Jeff());
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "jumpPad" && other.gameObject.tag != "ball" && other.gameObject.tag != "screen" && other.gameObject.tag != "button")
        {
            if (counter == 0)
            {
                trail1.transform.SetParent(null);
                trail2.transform.SetParent(null);
                transform.position = start;
                counter += 1;
            }
        }
    }
    IEnumerator Jeff()
    {
        if (counter2 % 2 == 0)
        {
            trail2.GetComponent<TrailRenderer>().emitting = false;
            yield return 0;
            trail2.transform.SetParent(gameObject.transform);
            trail2.transform.position = transform.position;
            yield return 0;
            trail2.GetComponent<TrailRenderer>().emitting = true;
        }
        else if (counter2 % 2 == 1)
        {
            trail1.GetComponent<TrailRenderer>().emitting = false;
            yield return 0;
            trail1.transform.SetParent(gameObject.transform);
            trail1.transform.position = transform.position;
            yield return 0;
            trail1.GetComponent<TrailRenderer>().emitting = true;
        }
        counter = 0;
        counter2 += 1;
    }
}
