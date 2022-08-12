using System.Collections;
using UnityEngine;

public class BallToBuy : MonoBehaviour
{
    internal Material Material { get => material ??= GetComponent<MeshRenderer>().material;
        set => GetComponent<MeshRenderer>().material = value; }
    Material material;
}   