using UnityEngine;
using Zenject;

internal class EnvironmentFactory
{
    DiContainer diContainer;
    public EnvironmentFactory (DiContainer _diContainer) => diContainer = _diContainer;

    public Environment Create(Environment environment, Vector3 position)
    {
        var environmentModel = diContainer.InstantiatePrefabForComponent<Environment>
            (environment, position, environment.transform.rotation, null);
        return environmentModel;
    }
}
