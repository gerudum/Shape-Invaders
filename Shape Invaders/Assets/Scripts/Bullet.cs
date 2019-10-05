using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Bullet : MonoBehaviour
{
    public Vector3 target;
    public Projectile projectile;

    [HideInInspector]
    public string parent;

    private Rigidbody2D rb;
    private Vector3 dir;
    private Animator anim;

    private float lifeTime;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
        lifeTime = Time.time + projectile.duration;

        dir = target - transform.position;
        dir.z = 0.0f;
        dir = dir.normalized;
    }

    public void Target(Vector3 newTarget)
    {
        target = newTarget;
    }

    public void FixedUpdate()
    {
        rb.velocity = dir * projectile.speed;
        anim.SetFloat("duration", lifeTime - Time.time);
    }

    public void Damage(Collider2D collision)
    {
        if (collision.CompareTag(parent))
        {
            return;
        }

        collision.SendMessage("TakeDamage", projectile.damage,SendMessageOptions.DontRequireReceiver);
        Death();
    }

    public void Death()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damage(collision);
    }
}
