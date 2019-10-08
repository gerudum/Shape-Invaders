using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public Effect effect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) return;
        if (collision.gameObject.GetComponent<StatusEffect>())
        {
            if(collision.gameObject.GetComponent<StatusEffect>().effect == effect)
            {
                return;
            }
        }

        collision.gameObject.AddComponent<StatusEffect>().effect = effect;
        GameObject visual = Instantiate(effect.visualEffect, collision.gameObject.transform.position, effect.visualEffect.transform.rotation);

        visual.transform.SetParent(collision.gameObject.transform);
    }
}
