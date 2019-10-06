using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //Bullet and Firepoint
    public GameObject bullet;
    public GameObject specialBullet;
    public Transform firePoint;

    public float chargeTime = 3f;

    //Fire Projectile
    public void Fire(string parent, Vector3 target)
    {
       
        GameObject newBullet = Instantiate(bullet, firePoint.position, bullet.transform.rotation);

        //Aim towards mouse
        Bullet bulletScript = newBullet.GetComponent<Bullet>();

        bulletScript.Target(target);
        bulletScript.parent = parent;
        newBullet.tag = parent;

        AudioManager.instance.PlaySound(bulletScript.projectile.fireSound);

        Instantiate(bulletScript.projectile.fireEffect, firePoint.position, bullet.transform.rotation);
    }

    public void ChargedShot(string parent, Vector3 target)
    {

        GameObject newBullet = Instantiate(specialBullet, firePoint.position, specialBullet.transform.rotation);

        //Aim towards mouse
        Bullet bulletScript = newBullet.GetComponent<Bullet>();

        bulletScript.Target(target);
        bulletScript.parent = parent;
        newBullet.tag = parent;

        AudioManager.instance.PlaySound(bulletScript.projectile.fireSound);

        Instantiate(bulletScript.projectile.fireEffect, firePoint.position, specialBullet.transform.rotation);
    }
}
