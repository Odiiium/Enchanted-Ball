using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skin : MonoBehaviour
{
    internal Animator Animator { get => animator ??= animator = GetComponent<Animator>(); }
    Animator animator;

}
