using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailRun : MonoBehaviour
{
    // Start is called before the first frame update
    public bool moveLeft;
    public float speed = 30;

    public Transform upPos;
    public Transform downPos;

    public bool movingUp;
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(moveLeft)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-speed * Time.deltaTime, GetComponent<Rigidbody2D>().velocity.y);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed * Time.deltaTime, GetComponent<Rigidbody2D>().velocity.y);
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if(movingUp)
        {
            int changeY = Random.Range(0, 50);
            if (changeY == 25)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, Random.Range(-1, 1) * speed * 0.01f);
                StartCoroutine("Reset", 1.0f);
            }

            if(transform.position.y > upPos.position.y)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -1 * speed * 0.01f);
            }
            else if(transform.position.y < downPos.position.y)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 1 * speed * 0.01f);
            }
        }
        
        
    }
    IEnumerator Reset(float Count)
    {
        yield return new WaitForSeconds(Count); //Count is the amount of time in seconds that you want to wait.

        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);

        yield return null;
    }
    private void LateUpdate()
    {
        transform.localRotation = new Quaternion(0, 0, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Point"))
        {
            if(collision.gameObject.name.Contains("left"))
            {
                moveLeft = false;
            }
            else if(collision.gameObject.name.Contains("right"))
            {
                moveLeft = true;
            }
        }
    }
}
