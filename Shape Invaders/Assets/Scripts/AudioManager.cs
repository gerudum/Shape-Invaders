using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public void Awake()
    {
        instance = this;
        foreach(Sound sound in sounds)
        {
            sound.source = this.gameObject.AddComponent<AudioSource>();
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.clip = sound.clip;
        }
    }

    public List<Sound> sounds = new List<Sound>();

    public void PlaySound(string name)
    {
        Sound sound = Array.Find(sounds.ToArray(), newSound => newSound.name == name);
        sound.source.Play();
    }
}
