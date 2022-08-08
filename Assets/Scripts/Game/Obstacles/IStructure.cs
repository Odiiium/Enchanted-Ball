using UnityEngine;
using Zenject;
using System.Collections.Generic;
public interface IStructure
{
    void Move();

    void Die(Wall structure, List<Wall> structureList);
    void Die(Obstacle structure, List<Obstacle> structureList);
    void Accept(IStructureHitVisitor iHitVisitor, DiContainer diContainer);

}