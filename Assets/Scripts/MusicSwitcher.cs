using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitcher : MonoBehaviour
{
    public AudioSource initialMusic;
    public AudioSource newMusic;

    private bool isPlayingInitialMusic = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isPlayingInitialMusic)
            {
                if (initialMusic.isPlaying)
                {
                    initialMusic.Stop();
                }

                if (!newMusic.isPlaying)
                {
                    newMusic.Play();
                }
            }
            else
            {
                if (newMusic.isPlaying)
                {
                    newMusic.Stop();
                }

                if (!initialMusic.isPlaying)
                {
                    initialMusic.Play();
                }
            }

            isPlayingInitialMusic = !isPlayingInitialMusic;
        }
        
    }
}
