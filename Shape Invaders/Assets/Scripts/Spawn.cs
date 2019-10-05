using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public void OnDestroy()
    {
        if(WaveManager.instance != null)
        WaveManager.instance.SendMessage("EnemyKilled");
    }
}
