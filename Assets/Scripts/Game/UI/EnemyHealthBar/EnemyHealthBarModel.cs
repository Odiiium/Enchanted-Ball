using UnityEngine;
using UniRx;
internal class EnemyHealthBarModel : MonoBehaviour
{
    internal FloatReactiveProperty HealthPoints = new FloatReactiveProperty(500);
    internal float maxHealth = 500;
}
