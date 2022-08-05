using UnityEngine;
using DG.Tweening;

public abstract class Structure : MonoBehaviour, IStructure
{
    StructureMovable structureMovable = new StructureMovable();

    public void Move()
    {
        structureMovable.Move(transform);
    }
}