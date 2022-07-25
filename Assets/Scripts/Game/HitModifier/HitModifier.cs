using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HitModifier
{
    void Accept(IHitModifyVisitor hitModifyVisitor)
    {
        hitModifyVisitor.Visit(this);
    }


}
