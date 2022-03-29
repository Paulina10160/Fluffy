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
    public bool removePlayerPrefsOnExit;
    public void OnStart()
    {
        Time.timeScale = 1;
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
        //TODO: usunac w produkcji
        if(removePlayerPrefsOnExit)
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }
        //----------------------------
        Application.Quit();
    }

    public void BuyBananaBullet(Button button)
    {
        int banana = PlayerPrefs.GetInt("BuyBanana", 0);
        if (banana == 1) //znaczy ze kupiony
        {
            PlayerPrefs.SetInt("Ammo", 1);
            PlayerPrefs.Save();
        }
        else if(coins >= bananaBulletCost)
        {
            coins -= bananaBulletCost;
            PlayerPrefs.SetInt("BuyBanana", 1);
            PlayerPrefs.SetInt("Ammo", 1);
            PlayerPrefs.Save();
            Text priceText = button.GetComponentInChildren<Text>();
            priceText.text = "SOLD";
        }
    }

    public void BuyCarrotBullet(Button button)
    {
        PlayerPrefs.SetInt("Ammo", 0);
        PlayerPrefs.Save();
    }
}
