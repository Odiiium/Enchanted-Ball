using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHitVisitor
{
    void Visit(Hit hit);
    void Visit(EnemyHit enemyHit);
    void Visit(WallHit Wallhit);
}
