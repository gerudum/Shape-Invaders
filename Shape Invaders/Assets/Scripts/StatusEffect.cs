using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffect : MonoBehaviour
{
    public Effect effect;
    public float procRate = 1f;
    private float procCountdown;

    public void Start()
    {
        procCountdown = procRate;
    }

    public void Update()
    {
        procCountdown -= Time.deltaTime;
        if(procCountdown <= 0)
        {
            Proc();
            procCountdown = procRate;
        }
    }

    public void Proc()
    {
        switch (effect.statusEffect)
        {
            case Effect.StatusEffect.Fire:
                this.gameObject.SendMessage("TakeDamage", effect.strength,SendMessageOptions.DontRequireReceiver);
            break;
            case Effect.StatusEffect.Freeze:
                this.gameObject.SendMessage("LoseSpeed", effect.strength, SendMessageOptions.DontRequireReceiver);
            break;
            case Effect.StatusEffect.Poison:

            break;
            case Effect.StatusEffect.Shock:

            break;
        }
    }
}
