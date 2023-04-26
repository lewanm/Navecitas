using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    AudioSource source;
    AudioClip clip;
    void Start()
    {
        source = GetComponent<AudioSource>();
        clip = source.GetComponent<AudioClip>();
        PlaySound();
    }

    void PlaySound()
    {
        source.PlayOneShot(clip);
    }
}
