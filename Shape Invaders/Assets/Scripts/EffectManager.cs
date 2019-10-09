using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public static EffectManager instance;
    public void Awake()
    {
        instance = this;
    }

    public List<Effect> effectPool = new List<Effect>();
    public GameObject cardHolder;
    public void EnableCards()
    {
        cardHolder.SetActive(true);
    }

    public void HideCards()
    {
        cardHolder.SetActive(false);
    }

    public void RemoveEffect(Effect effect)
    {
        if (effect.spawnOnce)
        {
            effectPool.Remove(effect);
        }

        cardHolder.SetActive(false);
    }

    public Effect GetRandomEffect()
    {
        int rand = Random.Range(0, effectPool.Count);
        return effectPool[rand];
    }
}
