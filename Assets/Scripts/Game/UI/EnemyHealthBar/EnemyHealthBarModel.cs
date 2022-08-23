using UnityEngine;
using UniRx;
internal class EnemyHealthBarModel : MonoBehaviour
{
    internal FloatReactiveProperty HealthPoints = new FloatReactiveProperty(300);
    internal float maxHealth = 300;
}
