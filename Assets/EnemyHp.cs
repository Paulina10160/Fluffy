using FluffyAdventure;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    // Start is called before the first frame update
    public float startHp; //startowa wartosc zycia ustalana jest w insepkorze unity
    private float _hp;
    private float hp
    {
        get
        {
            return _hp; //zwraca aktualna wartosc punktow zycia
        }
        set
        {
            _hp = value; //ustawia aktualna wartosc punktow zycia
            if(_hp <= 0) 
            {
                _hp = 0; //jesli wyjdzie hp ujemne to zerujemy
            }
            hpStrip.transform.localScale = new Vector3(value / 100f, 1, 1); //pasek nad slimakiem zmeinia sie wraz zmiana ilosci zycia
        }
    }

    public RectTransform hpStrip; //pasek zycia przekazujemy przez inspektora

    void Start()
    { 
        hp = startHp;  //nadajemy poczatkowa wartosc zycia dla przeciwnika
    }

    private void OnTriggerEnter2D(Collider2D collision) //wykrycie kolizji
    { 
        if(collision.tag == "Bullet" && hp > 0) //jesli nastapila kolizja z amunicja i przeciwnik ma jeszcze hp
        {
            hp -= collision.GetComponent<FlyObject>().Power; //collision - obiekt z ktorym wystapila kolizja, za pomoca getComponent pobieramy odpowiedni skrypt z ktorego bierziemy moc amunicji
            //i odejmujemy od punktow zycia slimaka, automatycznie wywola sie seter z linii 20 i skroci pasek
            
            if(hp <= 0)
            {
                Kill(); //zabijamy slimaka jestli nie ma hp
            }
        }
    }

    public void Kill()
    {
        hp = 0; 
        GetComponent<BoxCollider2D>().offset = new Vector2(0.03646641f, -0.1410472f); //collider dostosowuje sie do wielkosci samej skorupy slimaka
        GetComponent<BoxCollider2D>().size = new Vector2(0.4763092f, 0.4401575f); //collider dostosowuje sie do wielkosci samej skorupy slimaka
        GetComponent<SnailRun>().enabled = false; //wylaczamy skrypt od chodzenia
        GetComponent<Animator>().SetBool("die", true); //zmiana stanu animacji, animacja smierci
        tag = "Ground"; //nadajemy ten tag zeby gracz mogl chodzic po slimaku a jednocznie zeby nie byl przez niego zabity
    }

    public void SetAlive()
    {
        hp = startHp; //ustawiamy startowe hp (z inspektora)
        GetComponent<BoxCollider2D>().offset = new Vector2(-0.07328892f, -0.09302926f); //przywracamy collider dla normalnego slimaka
        GetComponent<BoxCollider2D>().size = new Vector2(0.6958199f, 0.5361934f);//przywracamy collider dla normalnego slimaka
        GetComponent<SnailRun>().enabled = true; //uruchamiamy skrypt od chodzenia
        GetComponent<Animator>().SetBool("die", false); //zmiana stanu animacji, przejscie ze stanu smierci w stan normalny
        tag = "Enemy"; //z powrotem przywracamy tag zeby smilak mogl miec mozliwosc zabijcia gracza
    }

}
