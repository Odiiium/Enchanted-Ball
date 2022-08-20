
using Zenject;

public class DoubleDamageWall : Wall
{

    public override void Accept(IStructureHitVisitor iHitVisitor, DiContainer diContainer)
    {
        iHitVisitor.Visit(this, diContainer);
    }
}
