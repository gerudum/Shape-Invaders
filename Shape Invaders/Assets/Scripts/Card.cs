using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    //The effect itself
    public Effect effect;

    //The weapon we're adding this effect too
    public Weapon weapon;

    private Animator anim;

    public void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Select()
    {
        weapon.effects.Add(effect);
        anim.Play("Select");
    }
}
