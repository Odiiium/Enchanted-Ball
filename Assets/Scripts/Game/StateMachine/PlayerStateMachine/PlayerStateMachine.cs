using Zenject;

public class PlayerStateMachine : StateMachine
{
    [Inject]
    void Construct(DiContainer _diContainer)
    {
        diContainer = _diContainer;
    }

    public class Factory : PlaceholderFactory<PlayerStateMachine> { }
}
