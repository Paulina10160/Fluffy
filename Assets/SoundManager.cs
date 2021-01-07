using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance { get => instance; set => instance = value; }

    public AudioClip GunSound;
    public AudioClip JumpSound;
    public AudioClip CoinSound;

    private AudioSource audioPlayer;

    private void Awake()
    {
        audioPlayer = GetComponent<AudioSource>();
        if(instance == null)
        {
            instance = this;
        }
    }

    public void PlayJumpSound()
    {
        audioPlayer.PlayOneShot(JumpSound);
    }

    public void PlayGunSound()
    {
        audioPlayer.PlayOneShot(GunSound);
    }

    public void PlayCoinCollected()
    {
        audioPlayer.PlayOneShot(CoinSound, 0.3f);
    }
}
