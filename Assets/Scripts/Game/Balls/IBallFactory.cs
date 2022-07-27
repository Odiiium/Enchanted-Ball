using UnityEngine;

interface IBallFactory
{
    Ball Create(Vector3 at);
}