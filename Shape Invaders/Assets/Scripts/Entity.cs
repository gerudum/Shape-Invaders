using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Entity : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public GameObject deathEffect;

    private Animator anim;

    //Animator
    public void Start()
    {
        health = maxHealth;
        anim = GetComponent<Animator>();
    }

    //Taking Damage
    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        anim.SetFloat("health", health);
    }

    public virtual void Death()
    {
        Instantiate(deathEffect, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
