using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    [HideInInspector]
    public AudioSource source;

    [Range(0,1)]
    public float volume = 1f;

    [Range(0,3)]
    public float pitch = 1f;
}
