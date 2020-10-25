using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyObject : MonoBehaviour
{
    public float speed { get; set; }
    public float Power;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            if(!collision.name.Contains("snail"))
            {
                Destroy(collision.gameObject);
            }
            Destroy(gameObject);
        }
        if(collision.name != "Player")
        {
            Destroy(gameObject);
        }
    }
}
