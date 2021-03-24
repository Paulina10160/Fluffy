using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public Transform scroller;
    public GameObject gameOverPanel;
    public int points = 0;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "wall")
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            print("Kolizja!");
        }
        else if(collision.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            points++;
        }
    }

    public void ResetPlayer()
    {
        transform.position = new Vector3(0, 0, transform.position.z);
        Time.timeScale = 1;
        foreach(Transform obj in scroller)
        {
            Destroy(obj.gameObject);
        }
    }
}
