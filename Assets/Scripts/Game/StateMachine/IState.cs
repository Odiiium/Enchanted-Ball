using Zenject;

public interface IState
{
    DiContainer diContainer { get; set; }

    void Enter();
    void Exit();
}
