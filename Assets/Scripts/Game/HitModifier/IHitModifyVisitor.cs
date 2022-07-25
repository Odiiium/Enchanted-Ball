using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHitModifyVisitor
{
    void Visit(HitModifier hitModifier);

}
