using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISounds : MonoBehaviour
{
    public AudioSource sounds;
    public AudioClip clickAudio;
    public AudioClip switchAudio;

    public void ClickAudioOn()
    {
        sounds.PlayOneShot(clickAudio);
    }

    public void SwitchAudioOn()
    {
        sounds.PlayOneShot(switchAudio);
    }
}
