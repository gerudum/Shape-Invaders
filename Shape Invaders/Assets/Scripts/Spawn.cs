using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public void OnDestroy()
    {
        WaveManager.instance.SendMessage("EnemyKilled");
    }
}
