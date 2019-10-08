using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Effect", menuName = "Effect", order = 1)]
public class Effect : ScriptableObject
{
    public enum Effects
    {
        Multishot,
        Status,
        Statup,
        Bullet
    }

    public enum StatusEffect
    {
        Fire,
        Freeze,
        Poison,
        Shock
    }

    public enum Stats
    {
        Health,
        Speed,
        Damage
    }
    
    public float strength = 1f;

    public Effects effect;
    public StatusEffect statusEffect;
    public Stats stat;

    public string effectName;
    public string desc;
    public Sprite icon;

    public bool spawnOnce;

    public GameObject visualEffect;

    public GameObject newBullet;
    public GameObject newChargedBullet;
}

