using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Effect", menuName = "Effect", order = 1)]
public class Effect : ScriptableObject
{
    public enum Effects
    {
        Multishot,
        Status,
        SpeedUp,
        DamageUp,
        Vortex,
        Pulse,
        Explosive,
        Repulsive,
        Laser
    }

    public enum StatusEffect
    {
        Fire,
        Freeze,
        Poison,
        Shock
    }
    
    public float strength = 1f;

    public Effects effect = Effects.Multishot;
    public StatusEffect statusEffect = StatusEffect.Fire;

    public string effectName;
    public string desc;
    public Sprite icon;

    public GameObject visualEffect;

    public GameObject newBullet;
    public GameObject newChargedBullet;

    public void DoEffect(Weapon weapon)
    {
        switch (effect)
        {
            case Effects.Multishot:
                for(int i = 0; i < strength; i++)
                {
                    weapon.MirrorFire("Player", Camera.main.ScreenToWorldPoint(Input.mousePosition));
                }
            break;
            case Effects.Status:
                weapon.lastBullet.AddComponent<Status>().effect = this;
            break;
        }
    }
}

[CustomEditor(typeof(Effect))]
public class EffectInspector : Editor
{
    public override void OnInspectorGUI()
    {
        var effect = target as Effect;
        effect.strength = EditorGUILayout.FloatField("Strength", effect.strength);
        effect.effect = (Effect.Effects)EditorGUILayout.EnumFlagsField("Effect", effect.effect);

        bool isEffect = effect.effect == Effect.Effects.Status;

        if (isEffect)
        {
            effect.statusEffect = (Effect.StatusEffect)EditorGUILayout.EnumFlagsField("Status Effect", effect.statusEffect);
            effect.visualEffect = (GameObject)EditorGUILayout.ObjectField("Status Visual Effect", effect.visualEffect, typeof(GameObject), false);
        }

        effect.effectName = EditorGUILayout.TextField("Card Name", effect.effectName);
        effect.desc = EditorGUILayout.TextField("Card Description", effect.desc);

        effect.icon = (Sprite)EditorGUILayout.ObjectField("Card Icon", effect.icon, typeof(Sprite), false);

        if (!isEffect)
        {
            effect.newBullet = (GameObject)EditorGUILayout.ObjectField("New Bullet", effect.newBullet, typeof(GameObject), false);
            effect.newChargedBullet = (GameObject)EditorGUILayout.ObjectField("New Charged Bullet", effect.newChargedBullet, typeof(GameObject), false);
        }
    }
}
