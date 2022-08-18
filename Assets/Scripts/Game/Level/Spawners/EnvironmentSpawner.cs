using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx.Triggers;
using UniRx;

internal class EnvironmentSpawner : MonoBehaviour
{
    List<Environment.Factory> environmentFactories;
    internal List<Environment> environmentList = new List<Environment>();
    DiContainer diContainer;

    [Inject]
    void Construct(List<Environment.Factory> _environmentFactories, DiContainer _diContainer)
    {
        environmentFactories = _environmentFactories;
        diContainer = _diContainer;
    }

    internal void SpawnEnvironment(Vector3 spawnPosition)
    {
        Environment environment = environmentFactories[Random.Range(0, environmentFactories.Count)].Create();
        environmentList.Add(environment);
        environment.transform.position = spawnPosition;
        environment.Collider.OnCollisionEnterAsObservable().
            Subscribe(collision =>
            {
                if (collision.gameObject.layer == 9) DestroyEnvironment(environment);

            }).AddTo(environment);
    }

    internal void DestroyEnvironment(Environment environment)
    {
        environmentList.Remove(environment);
        Destroy(environment.gameObject);
        SpawnEnvironment(Vector3.forward * 12);
    }


}
