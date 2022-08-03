
using Zenject;

public class PlayerIdleState : IState
{
    Player player;
    public DiContainer DiContainer { get { return diContainer; } set { diContainer = value; } }
    DiContainer diContainer;

    public void Construct()
    {
        player = DiContainer.Resolve<Player>();
    }

    public void Enter()
    {
        Construct();
    }

    public void Exit()
    {

    }
}
