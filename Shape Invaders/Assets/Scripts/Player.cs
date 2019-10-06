using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public Follow cam;
    public HealthBar healthBar;

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        cam.Shake(0.25f, 0.3f);
        healthBar.UpdateHealth(maxHealth, health);

        if(health <= 0)
        {
            WaveManager.instance.GameOver();
        }
    }
}
