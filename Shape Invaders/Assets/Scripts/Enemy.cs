using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

   
    public float moveSpeed;
    public float fireDelay;
    public float shootRange = 10f;

    private float fireCountdown;
    private Transform player;
    private Rigidbody2D rb;

    private Vector3 dir;
    private Weapon weapon;

    private Animator anim;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        weapon = GetComponentInChildren<Weapon>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        fireCountdown = fireDelay;
    }

    public void Update()
    {
        if (InRange())
        {
            fireCountdown -= Time.deltaTime;
        }
    
        if(fireCountdown <= 0)
        {
            Fire();
            fireCountdown = fireDelay;
        }
    }

    public void FixedUpdate()
    {
        Move();    
    }

    public void FindPlayer()
    {
        dir = player.position - transform.position;
        dir = dir.normalized;
    }

    public void Aim()
    {
        // convert mouse position into world coordinates
        Vector2 playerPosition = player.transform.position;

        // get direction you want to point at
        Vector2 direction = (playerPosition - (Vector2)transform.position).normalized;

        // set vector of transform directly
        transform.up = direction;
    }

    public void Fire()
    {
        weapon.Fire("Enemy", player.transform.position);
        anim.Play("Shoot", -1, 0);
    }

    public void Move()
    {
        FindPlayer();

        if (!InRange())
        {
            rb.velocity = dir * moveSpeed;
        } else
        {
            rb.velocity = new Vector2(0, 0);
        }
    
        Aim();
    }

   
    private bool InRange()
    {
        return Physics2D.OverlapCircle(transform.position, shootRange, LayerMask.GetMask("Player"));
    }
}
