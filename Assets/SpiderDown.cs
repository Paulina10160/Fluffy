using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderDown : MonoBehaviour
{
    public float interval;

    private float nextDown;

    // Start is called before the first frame update
    void Start()
    {
        nextDown = Time.time + interval;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextDown)
        {
            GetComponent<Animator>().SetTrigger("Down");
            nextDown = Time.time + interval;
        }
    }
}
