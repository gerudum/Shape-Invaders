using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public Effect effect;
    public float splash = 2f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (Collider2D col in Physics2D.OverlapCircleAll(transform.position, splash))
        {
            if (col.CompareTag("Player")) return;
            if (col.CompareTag("Enemy") && !col.GetComponent<StatusEffect>())
            {
                col.gameObject.AddComponent<StatusEffect>().effect = effect;
                GameObject visual = Instantiate(effect.visualEffect, col.gameObject.transform.position, effect.visualEffect.transform.rotation);

                visual.transform.SetParent(col.gameObject.transform);
            }
        }
    }
}
