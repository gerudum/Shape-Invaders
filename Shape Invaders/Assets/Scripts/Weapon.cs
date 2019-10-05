﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //Bullet and Firepoint
    public GameObject bullet;
    public Transform firePoint;

    //Fire Projectile
    public void Fire(string parent, Vector3 target)
    {
       
        GameObject newBullet = Instantiate(bullet, firePoint.position, bullet.transform.rotation);

        //Aim towards mouse
        Bullet bulletScript = newBullet.GetComponent<Bullet>();

        bulletScript.Target(target);
        bulletScript.parent = parent;
        newBullet.tag = parent;
    }
}
