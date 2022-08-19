using System.Collections;
using UnityEngine;
using Zenject;
public class EnemyFacade
{
    internal Enemy enemy;

    public class Factory : PlaceholderFactory<EnemyFacade> { }
}
