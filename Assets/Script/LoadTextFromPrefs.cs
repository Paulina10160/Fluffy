using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadTextFromPrefs : MonoBehaviour
{
    public string key;
    void Start()
    {
        int value = PlayerPrefs.GetInt(key, 0);
        print(key);
        print(value);
        if(value == 1)
        {
            GetComponent<Text>().text = "SOLD";
        }
    }
}
