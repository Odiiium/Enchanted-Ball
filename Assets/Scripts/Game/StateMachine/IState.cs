using Zenject;

public interface IState
{
    DiContainer DiContainer { get; set; }

    void Enter();
    void Exit();
}
