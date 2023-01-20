using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RandomizedLoopClip : MonoBehaviour
{
    public AudioClip[] clips;
    new AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        PlayRandomClip();
    }

    void PlayRandomClip()
    {
        audio.clip = clips[Random.Range(0, clips.Length)];
        audio.Play();
        Invoke("PlayRandomClip", audio.clip.length);
    }
}
