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

    [System.Serializable]
    public class Spawn
    {
        public GameObject enemy;
        public float weight;
    }

    public string name;
    public Difficulty difficulty = Difficulty.Easy;

    public Spawn[] spawns;

    public int enemies;
    public float delay = 1f;

    public float weight = 1f;

 
}
