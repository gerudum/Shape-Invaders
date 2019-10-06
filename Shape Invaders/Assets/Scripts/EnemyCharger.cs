using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharger : Enemy
{
    public float damage;
    public float chargeDuration;

    private bool launched = false;
    public override void Update()
    {
        //base.Update();
        fireCountdown -= Time.deltaTime;
    }

    public override void FixedUpdate()
    {
        //base.FixedUpdate();
        if(InRange() && fireCountdown <= 0 && !launched)
        {
            StartCoroutine("ChargeAttack");
        } else if (!launched)
        {
            Move();
        }
    }

    public IEnumerator ChargeAttack()
    {
     //   Debug.Log("Charge!!!");
        launched = true;
        Charge();

        yield return new WaitForSeconds(chargeDuration);

        fireCountdown = fireDelay;
        launched = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.SendMessage("TakeDamage", damage);
    }
}
