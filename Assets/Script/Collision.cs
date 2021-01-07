using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace FluffyAdventure {
    public class Collision : MonoBehaviour
    {
        public Text pointsText;
        private int points;
        //  public GameObject coinPrefab;

        private int hp;

        private float curentTime;

        public int diamonds = 0;

        public HpStrip hpStrip;

        public GameManager gameManager;

        public GameObject ladder { get; set; }

        // Start is called before the first frame update
        void Start()
        {
            points = 0;
            hp = 100;

            

            //Instantiate(coinPrefab);
            curentTime = Time.time;
        }

        public void ResetStats()
        {
            //points = 0;
            hp = 100;
            hpStrip.Value = 100;
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
            else if(collision.gameObject.CompareTag("Diamond"))
            {
                diamonds++;
                Destroy(collision.gameObject);
            }
            else if(collision.gameObject.CompareTag("Coin"))
            {
                points++;
                Destroy(collision.gameObject);
                SoundManager.Instance.PlayCoinCollected();
            }
            else if (collision.gameObject.CompareTag("Enemy"))
            {
                gameOver();
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
            else if(collision.gameObject.CompareTag("Level1Done"))
            {
                SceneManager.LoadScene("Level2");
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("Kolizja");
            if (collision.gameObject.CompareTag("Enemy"))
            {
                gameOver();
            }
            else if (collision.gameObject.CompareTag("Ground"))
            {
                Debug.Log("Ground!!!");
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