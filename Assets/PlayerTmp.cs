using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTmp : MonoBehaviour
{
    public float moveSpeed;
    private void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

        if (move > 0.2 || move < -0.2)
        {
            if (move < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            GetComponent<Animator>().SetBool("Walking", true);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
            GetComponent<Animator>().SetBool("Walking", false);
        }
    }

    private void LateUpdate()
    {
        transform.localRotation = new Quaternion(0, 0, 0, 0);
    }
}
