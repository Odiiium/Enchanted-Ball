using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx.Triggers;
using UniRx;

internal class EnvironmentSpawner : MonoBehaviour
{
    DiContainer diContainer;
    EnvironmentFactory environmentFactory;
    [SerializeField] List<Environment> environments;
    internal List<Environment> environmentList = new List<Environment>();

    [Inject]
    void Construct(EnvironmentFactory _environmentFactory, DiContainer _diContainer)
    {
        environmentFactory = _environmentFactory;
        diContainer = _diContainer;
    }

    internal void SpawnEnvironment(Vector3 spawnPosition)
    {
        Environment environment = environmentFactory.Create(environments[Random.Range(0, environments.Count)], spawnPosition);
        environmentList.Add(environment);
        environment.Collider.OnCollisionEnterAsObservable().
            Subscribe(collision => 
            { if (collision.gameObject.layer == 9) DestroyEnvironment(environment); })
            .AddTo(environment);
    }

    internal void DestroyEnvironment(Environment environment)
    {
        environmentList.Remove(environment);
        Destroy(environment.gameObject);
        SpawnEnvironment(Vector3.forward * 12);
    }


}
