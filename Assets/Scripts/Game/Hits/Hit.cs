using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hit
{
    internal void Accept(IHitVisitor hitVisitor)
    {
        hitVisitor.Visit(this);
    }
}
