using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Obstacle : Structure
{
    public override void Die(Obstacle structure, List<Obstacle> structureList)
    {
        structureList.RemoveAt(structureList.IndexOf(structure));
        Destroy(gameObject);
    }

}
