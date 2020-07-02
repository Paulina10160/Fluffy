using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void OnStart()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnExit()
    {
        //to dziala tylko w edytorze unity, pozniej trzeba dodac inna funkcje
        EditorApplication.ExecuteMenuItem("Edit/Play");
        //Application.Quit();
    }
}
