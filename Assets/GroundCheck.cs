using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public delegate void OnGrounded();

    public event OnGrounded onGrounded;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if(onGrounded != null)
            {
                onGrounded();
            }
           // Debug.Log("Ground");
        }
    }
}
