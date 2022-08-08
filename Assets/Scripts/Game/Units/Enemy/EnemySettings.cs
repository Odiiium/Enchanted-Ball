using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemySettings : MonoBehaviour
{
    [SerializeField] internal float healthPoints;
    [SerializeField] internal int damage;

    internal void SetUpSettings(float healthpoints, float maxHealthpoints)
    {
        healthpoints = healthPoints;
        maxHealthpoints = healthPoints;
    }
}
