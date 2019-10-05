using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public enum Difficulty
    {
        Easy,
        Normal,
        Hard,
        Insane
    }

    public string name;
    public Difficulty difficulty = Difficulty.Easy;

    public GameObject enemy;
    public float weight = 1f;
}
