using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{

    public string effectName;
    public string descName;
    public Image icon;

    //The effect itself
    public Effect effect;

    //The weapon we're adding this effect too
    public Weapon weapon;
    public void OnEnable()
    {
        effect = EffectManager.instance.GetRandomEffect();

        effectName = effect.effectName;
        descName = effect.desc;
        icon.sprite = effect.icon;
    }

    public void Select()
    {  
        weapon.AddEffect(effect);

        EffectManager.instance.RemoveEffect(effect);
    }
}
