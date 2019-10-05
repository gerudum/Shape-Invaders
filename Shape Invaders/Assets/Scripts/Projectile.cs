using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Projctile", menuName = "Projectile", order = 1)]
public class Projectile : ScriptableObject
{
    public float damage = 1f;
    public float speed = 15f;
    public float duration = 5f;
}
