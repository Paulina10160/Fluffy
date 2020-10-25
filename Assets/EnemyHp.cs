using FluffyAdventure;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    // Start is called before the first frame update
    public float startHp;
    private float _hp;
    private float hp
    {
        get
        {
            return _hp;
        }
        set
        {
            _hp = value;
            if(_hp <= 0)
            {
                _hp = 0;
            }
            hpStrip.transform.localScale = new Vector3(value / 100f, 1, 1);
        }
    }

    public RectTransform hpStrip;

    void Start()
    {
        hp = startHp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet" && hp > 0)
        {
            hp -= collision.GetComponent<FlyObject>().Power;
            if(hp <= 0)
            {
                Kill();
            }
        }
    }

    public void Kill()
    {
        hp = 0;
        GetComponent<BoxCollider2D>().offset = new Vector2(0.03646641f, -0.1410472f);
        GetComponent<BoxCollider2D>().size = new Vector2(0.4763092f, 0.4401575f);
        GetComponent<SnailRun>().enabled = false;
        GetComponent<Animator>().SetBool("die", true);
        tag = "Ground";
    }

    public void SetAlive()
    {
        hp = startHp;
        GetComponent<BoxCollider2D>().offset = new Vector2(-0.07328892f, -0.09302926f);
        GetComponent<BoxCollider2D>().size = new Vector2(0.6958199f, 0.5361934f);
        GetComponent<SnailRun>().enabled = true;
        GetComponent<Animator>().SetBool("die", false);
        tag = "Enemy";
    }

}
