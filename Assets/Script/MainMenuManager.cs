using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public int coins = 500;
    public int bananaBulletCost;
    public void OnStart()
    {
        Time.timeScale = 1;
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        SceneManager.LoadScene("Game");
    }

    public void PlayHistory()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("HistoryScene");
    }

    public void OnExit()
    {
        //to dziala tylko w edytorze unity, pozniej trzeba dodac inna funkcje
        //EditorApplication.ExecuteMenuItem("Edit/Play");
        Application.Quit();
    }

    public void BuyBananaBullet(Button button)
    {
        if(coins >= bananaBulletCost)
        {
            coins -= bananaBulletCost;
            PlayerPrefs.SetInt("Ammo", 1);
            PlayerPrefs.Save();
            button.interactable = false;
            button.transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("Idle", true);
        }
    }
}
