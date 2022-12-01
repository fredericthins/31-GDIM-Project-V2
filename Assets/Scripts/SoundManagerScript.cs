using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip playerJumpSound;
    public static AudioClip playerCoinCollected;
    public static AudioClip playerDashes;
    static AudioSource audioSrc;


    // Using awake over start allows for the functions to be played.
    // This section focuses on when an action occurs to load the sound effect.
    void Awake()
    {
        playerJumpSound = Resources.Load<AudioClip>("playerJump");
        audioSrc = GetComponent<AudioSource>();

        playerCoinCollected = Resources.Load<AudioClip>("coinCollected");
        audioSrc = GetComponent<AudioSource>();

        playerDashes = Resources.Load<AudioClip>("playerDash");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // This section takes the loaded sound and makes the sound play. 
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "playerJump":
                audioSrc.PlayOneShot(playerJumpSound);
                break;

            case "coinCollected":
                audioSrc.PlayOneShot(playerCoinCollected);
                break;

            case "playerDash":
                audioSrc.PlayOneShot(playerDashes);
                break;
        }
    }
}
