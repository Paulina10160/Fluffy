using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCurrentWeapon : MonoBehaviour
{
    private int currentWeapon = -1;
    public Image[] weaponImages;
    void Update()
    {
        int weaponId = PlayerPrefs.GetInt("Ammo", 0);
        if(weaponId != currentWeapon)
        {
            foreach (var item in weaponImages)
            {
                item.color = Color.white;
            }
            currentWeapon = weaponId;
            weaponImages[weaponId].color = Color.green;
        }
    }
}
