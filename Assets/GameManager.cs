using FluffyAdventure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gamePanel;
    public GameObject gameOverPanel;
    public Transform savePoints;
    public FluffyAdventure.Collision player;

    private void Start()
    {
        Time.timeScale = 1;
    }
    public void OnExit()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnGameOver()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        gamePanel.SetActive(false);
    }

    public void OnWatchAd()
    {
        if (player.GetPoints() > 0)
        {
            player.RemovePoints(1);

            Transform minObject = savePoints.GetChild(0);
            float min = Math.Abs(player.transform.position.x - minObject.transform.position.x);

            for (int i = 1; i < savePoints.childCount; i++)
            {
                float minTmp = Math.Abs(player.transform.position.x - savePoints.GetChild(i).position.x);
                if (minTmp < min)
                {
                    minObject = savePoints.GetChild(i);
                    min = minTmp;
                }
            }

            MakeSnailsAlive();
            player.ResetPosition(minObject.transform.position);
            player.ResetStats();
            Time.timeScale = 1;
            gameOverPanel.SetActive(false);
            gamePanel.SetActive(true);
        }
    }

    private void MakeSnailsAlive()
    {
        FindObjectsOfType<EnemyHp>().ToList().ForEach(x => x.SetAlive());
    }

    public void OnReplay()
    {
        SceneManager.LoadScene("Game");
    }
}
