using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunEnemy : MonoBehaviour
{
    public Transform leftPos;
    public Transform rightPos;
    bool goLeft = true;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (goLeft)
        {
            transform.position = new Vector3(transform.position.x - (speed * Time.deltaTime), transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x + (speed * Time.deltaTime), transform.position.y, transform.position.z);
        }

        if (transform.position.x <= leftPos.position.x)
        {
            goLeft = false;
        }
        else if (transform.position.x >= rightPos.position.x)
        {
            goLeft = true;
        }
    }
}
