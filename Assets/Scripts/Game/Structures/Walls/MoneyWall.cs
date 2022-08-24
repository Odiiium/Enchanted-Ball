using Zenject;
public class MoneyWall : Wall
{
    public override void Accept(IStructureHitVisitor iHitVisitor, DiContainer diContainer)
    {
        iHitVisitor.Visit(this, diContainer);
    }
}
