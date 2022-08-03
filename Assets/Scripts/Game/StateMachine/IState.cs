using Zenject;

public interface IState
{
    DiContainer DiContainer { get; set; }

    void Construct();
    void Enter();
    void Exit();
}
