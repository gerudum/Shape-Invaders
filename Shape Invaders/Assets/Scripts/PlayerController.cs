using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    private Rigidbody2D rb;
    private Weapon weapon;
    private Animator anim;
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        weapon = GetComponentInChildren<Weapon>();
        anim = GetComponent<Animator>();
    }

    //Weapon Fire
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            weapon.Fire("Player",Camera.main.ScreenToWorldPoint(Input.mousePosition));
            anim.Play("Fire", -1, 0);
        }
    }

    public void FixedUpdate()
    {
        Move();
        // convert mouse position into world coordinates
        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // get direction you want to point at
        Vector2 direction = (mouseWorldPosition - (Vector2)transform.position).normalized;

        // set vector of transform directly
        transform.up = direction;
    }

    //Move
    public void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(x * moveSpeed, y * moveSpeed);
        rb.velocity = movement;
    }
}
