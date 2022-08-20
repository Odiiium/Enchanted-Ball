
using Zenject;

public class DeathWall : Wall
{
    public override void Accept(IStructureHitVisitor iHitVisitor, DiContainer diContainer)
    {
        iHitVisitor.Visit(this, diContainer);
    }
}
