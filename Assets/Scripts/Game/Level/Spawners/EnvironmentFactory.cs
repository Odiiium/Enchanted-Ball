using UnityEngine;

internal class EnvironmentFactory
{
    public Environment Create(Environment environment, Vector3 position)
    {
        var environmentModel = GameObject.Instantiate(environment, position, environment.transform.rotation, null);
        return environmentModel;
    }
}
