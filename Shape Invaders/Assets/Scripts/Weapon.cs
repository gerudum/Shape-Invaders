using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //Bullet and Firepoint
    public GameObject bullet;
    public GameObject specialBullet;

    [HideInInspector]
    public GameObject lastBullet;

    public Transform firePoint;

    public float chargeTime = 3f;

    //Special Upgrades
    public List<Effect> effects = new List<Effect>();

    public void AddEffect(Effect effect)
    {
        effects.Add(effect);

        if(effect.newBullet != null)
        {
            bullet = effect.newBullet;
        }
        if(effect.newChargedBullet != null)
        {
            specialBullet = effect.newChargedBullet;
        }
    }

    //Fire Projectile
    public void Fire(string parent, Vector3 target)
    {
       
        GameObject newBullet = Instantiate(bullet, firePoint.position, firePoint.transform.rotation);

        //Aim towards mouse
        Bullet bulletScript = newBullet.GetComponent<Bullet>();

        bulletScript.Target(target);
        bulletScript.parent = parent;
        newBullet.tag = parent;

        AudioManager.instance.PlaySound(bulletScript.projectile.fireSound);

        Instantiate(bulletScript.projectile.fireEffect, firePoint.position, firePoint.transform.rotation);

        lastBullet = newBullet;

        foreach(Effect effect in effects)
        {
            effect.DoEffect(this);
        }
    }

    public void MirrorFire(string parent, Vector3 target)
    {
        Vector3 offset = firePoint.position - new Vector3(0, -0.5f, 0);
        GameObject newBullet = Instantiate(bullet, offset, firePoint.transform.rotation);
        

        //Aim towards mouse
        Bullet bulletScript = newBullet.GetComponent<Bullet>();

        bulletScript.Target(target);
        bulletScript.parent = parent;
        newBullet.tag = parent;

        AudioManager.instance.PlaySound(bulletScript.projectile.fireSound);

  
        Instantiate(bulletScript.projectile.fireEffect, offset, firePoint.transform.rotation);

        lastBullet = newBullet;
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
