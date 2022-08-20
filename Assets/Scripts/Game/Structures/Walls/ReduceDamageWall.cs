using Zenject;
public class ReduceDamageWall : Wall
{
    public override void Accept(IStructureHitVisitor iHitVisitor, DiContainer diContainer)
    {
        iHitVisitor.Visit(this, diContainer);
    }
}



