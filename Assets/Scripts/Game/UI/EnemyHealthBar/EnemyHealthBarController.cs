using UnityEngine;
using UniRx;

internal class EnemyHealthBarController : MonoBehaviour
{
    CompositeDisposable Disposable { get => disposable ??= new CompositeDisposable(); }
    CompositeDisposable disposable;
    internal EnemyHealthBarView View { get => enemyHealthBarView ??= GetComponent<EnemyHealthBarView>(); }
    EnemyHealthBarView enemyHealthBarView;
    internal EnemyHealthBarModel Model { get => enemyHealthBarModel ??= GetComponent<EnemyHealthBarModel>(); }
    EnemyHealthBarModel enemyHealthBarModel;

    private void OnEnable()
    {
        Model.HealthPoints.
            Subscribe(health => StartCoroutine(View.FillHealthBarImage(health, Model.maxHealth))).
            AddTo(Disposable);
    }

    private void OnDisable()
    {
        Disposable.Dispose(); 
        disposable = null;
    }
}
