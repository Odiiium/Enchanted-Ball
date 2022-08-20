using Zenject;

public interface IStructureHitVisitor
{
    void Visit(Structure structure, DiContainer diContainer);
    void Visit(DoubleDamageWall wall, DiContainer diContainer);
    void Visit(DeathWall wall, DiContainer diContainer);
    void Visit(ReduceDamageWall wall, DiContainer diContainer);

    void Visit(HealWall wall, DiContainer diContainer);
}