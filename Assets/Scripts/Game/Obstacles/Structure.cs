﻿using UnityEngine;
using UniRx;
using System.Collections.Generic;
using Zenject;

public abstract class Structure : MonoBehaviour, IStructure
{
    StructureMovable structureMovable = new StructureMovable();
    internal FloatReactiveProperty HealthPoints = new FloatReactiveProperty(1);

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8) HealthPoints.Value = 0;
    }
    
    public void Move() => structureMovable.Move(transform);
    public virtual void Die(Wall structure, List<Wall> structureList) { }
    public virtual void Die(Obstacle structure, List<Obstacle> structureList) { }

    public virtual void Accept(IStructureHitVisitor iHitVisitor, DiContainer diContainer)
    {
    }
}