﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FluffyAdventure {
    public class Collision : MonoBehaviour
    {
        public Text pointsText;
        private int points;
        //  public GameObject coinPrefab;

        private int hp;

        private float curentTime;

        public HpStrip hpStrip;

        public GameManager gameManager;

        public GameObject ladder;

        // Start is called before the first frame update
        void Start()
        {
            points = 0;
            hp = 100;

            

            //Instantiate(coinPrefab);
            curentTime = Time.time;
        }

        public int GetPoints()
        {
            return points;
        }

        public void RemovePoints(int count)
        {
            points -= count;
        }

        public void ResetPosition(Vector3 newPosition)
        {
            transform.position = newPosition;
        }

        // Update is called once per frame
        void Update()
        {
            pointsText.text = ": " + points.ToString();

            if (Time.time - curentTime > 0.5)
            {
                hp--;
                hpStrip.Value = hp;
                curentTime = Time.time;
                if(hp == 0)
                {
                    gameManager.OnGameOver();
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Food"))
            {
                hp += 2;
                if(hp > 100)
                {
                    hp = 100;
                }
                hpStrip.Value = hp;
                curentTime = Time.time;

                Destroy(collision.gameObject);
            }
            else if(collision.gameObject.CompareTag("Coin"))
            {
                points++;
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.CompareTag("Enemy"))
            {
                if (Mathf.Abs(transform.position.y - collision.gameObject.transform.position.y) < 0.3)
                {
                    gameOver();
                }
                else
                {
                    Destroy(collision.gameObject);
                }
            }
            else if(collision.gameObject.CompareTag("Spikes"))
            {
                gameOver();
            }
            else if(collision.gameObject.CompareTag("Spider"))
            {
                gameOver();
            }
            else if(collision.gameObject.CompareTag("Ladder"))
            {
                ladder = collision.gameObject; 
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if(collision.gameObject.CompareTag("Ladder"))
            {
                ladder = null;
            }
        }

        private void gameOver()
        {
            gameManager.OnGameOver();
            Time.timeScale = 0;
        }

        
    }

}