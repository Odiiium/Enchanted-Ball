using Zenject;

public class HealWall : Wall
{
    public override void Accept(IStructureHitVisitor iHitVisitor, DiContainer diContainer)
    {
        iHitVisitor.Visit(this, diContainer);
    }
}
