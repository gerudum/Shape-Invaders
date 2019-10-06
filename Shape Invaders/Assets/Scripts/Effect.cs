using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Effect", menuName = "Effect", order = 1)]
public class Effect : ScriptableObject
{
    public enum Effects
    {
        Multishot,
        Fire,
        Freeze,
        Shock,
        Poison,
        SpeedUp,
        DamageUp,
        Vortex,
        Pulse,
        Explosive,
        Repulsive,
        Laser
    }
    
    public float strength = 1f;
    public Effects effect;

    public GameObject newBullet;
    public GameObject newChargedBullet;

    public void DoEffect(Weapon weapon)
    {
        switch (effect)
        {
            case Effects.Multishot:
                for(int i = 0; i < strength; i++)
                {
                    weapon.Fire("Player", Camera.main.ScreenToWorldPoint(Input.mousePosition));
                }
            break;
        }
    }
}
