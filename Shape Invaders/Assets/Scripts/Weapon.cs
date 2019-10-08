using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //Bullet and Firepoint
    public GameObject player;
    public GameObject bullet;
    public GameObject specialBullet;

    public Transform firePoint;

    public float chargeTime = 3f;
    public GameObject bulletPrefab;
    public GameObject specialBulletPrefab;

    public int shootCount = 1;
    private Projectile bulletProjectile;
    private Projectile specialProjectile;
    public List<Effect> effects = new List<Effect>();

    public void Start()
    {
        if(this.gameObject.tag == "Enemy")
        {
            EnemyBullet("Enemy");
        } else
        {
            NewBullet("Player");
        } 
    }

    public void EnemyBullet(string parent)
    {
        bulletPrefab = bullet;
        specialBulletPrefab = specialBullet;

        bulletProjectile = bulletPrefab.GetComponent<Bullet>().projectile;
        specialProjectile = specialBulletPrefab.GetComponent<Bullet>().projectile;
    }

    public void NewBullet(string parent)
    {
        Vector3 nowwhere = new Vector3(1000, 1000, 1000);
        bulletPrefab = Instantiate(bullet,nowwhere,bullet.transform.rotation);
        specialBulletPrefab = Instantiate(specialBullet,nowwhere,specialBullet.transform.rotation);

        //Normal Bullets
        Bullet bulletScript = bulletPrefab.GetComponent<Bullet>();
        bulletProjectile = bulletScript.projectile;

        bulletScript.parent = parent;
        bulletPrefab.tag = parent;
        bulletScript.perpetuate = true;

        //Special Bullets
        Bullet specialBulletScript = specialBulletPrefab.GetComponent<Bullet>();
        specialProjectile = specialBulletScript.projectile;

        specialBulletScript.parent = parent;
        specialBulletScript.tag = parent;
        specialBulletScript.perpetuate = true;

        bulletScript.damageModifier = player.GetComponent<PlayerController>().damageModifier;
        specialBulletScript.damageModifier = player.GetComponent<PlayerController>().damageModifier;

        foreach (Effect effect in effects)
        {
            if (effect.effect == Effect.Effects.Status)
            {
                bulletPrefab.AddComponent<Status>().effect = effect;
                specialBulletPrefab.AddComponent<Status>().effect = effect;
            }
        }
    }

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

        switch (effect.effect)
        {
            case Effect.Effects.Multishot:
                shootCount += 1;
            break;
            case Effect.Effects.Status:
                // bulletPrefab.AddComponent<Status>().effect = effect;
                //specialBulletPrefab.AddComponent<Status>().effect = effect;
                NewBullet("Player");
            break;
            case Effect.Effects.Bullet:
                NewBullet("Player");
            break;
            case Effect.Effects.Statup:
                switch (effect.stat)
                {
                    case Effect.Stats.Health:
                        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
                        player.TakeDamage(-effect.strength);
                        break;
                    case Effect.Stats.Speed:
                        PlayerController playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
                        playerController.moveSpeed += effect.strength;
                        break;
                    case Effect.Stats.Damage:
                        PlayerController playerCon = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
                        playerCon.damageModifier += effect.strength;
                        break;
                }

                effects.Remove(effect);
           break;
        }
    }

    //Fire Projectile
    public void Fire(Vector3 target)
    {
        //Shoot bullets
        GameObject newBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.transform.rotation);
        newBullet.SendMessage("Target", target, SendMessageOptions.DontRequireReceiver);
        
        if(shootCount > 1)
        {
            StartCoroutine("LaunchBullet", target);
        }

        //Aim towards mouse
        AudioManager.instance.PlaySound(bulletProjectile.fireSound);

        Instantiate(bulletProjectile.fireEffect, firePoint.position, firePoint.transform.rotation);
    }

    public IEnumerator LaunchBullet(Vector3 target)
    {
        yield return new WaitForSeconds(0.03f);

        GameObject newBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.transform.rotation);
        newBullet.SendMessage("Target", target, SendMessageOptions.DontRequireReceiver);

        AudioManager.instance.PlaySound(bulletProjectile.fireSound);
    }

    public void ChargedShot(Vector3 target)
    {
        GameObject newBullet = Instantiate(specialBulletPrefab, firePoint.position, specialBullet.transform.rotation);
        newBullet.SendMessage("Target", target, SendMessageOptions.DontRequireReceiver);

        AudioManager.instance.PlaySound(specialProjectile.fireSound);

        Instantiate(specialProjectile.fireEffect, firePoint.position, specialBullet.transform.rotation);
    }
}
