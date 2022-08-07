using UnityEngine;
using System.Collections.Generic;
public interface IStructure
{
    void Move();

    void Die(Wall structure, List<Wall> structureList);
    void Die(Obstacle structure, List<Obstacle> structureList);

}