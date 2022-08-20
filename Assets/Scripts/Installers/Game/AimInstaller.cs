using UnityEngine;
using Zenject;

public class AimInstaller : MonoInstaller
{
    [SerializeField] FirstPoint firstPoint;
    [SerializeField] SecondPoint secondPoint;
    [SerializeField] AimRay aimRay;
    [SerializeField] AimRayCaster aimRayCaster;

    [SerializeField] GameObject ParentAimObject;

    public override void InstallBindings()
    {
        BindPoints();
        BindAimRay();
        BindAimCaster();
    }
    void BindPoints()
    {
        Container.Bind<FirstPoint>().FromInstance(firstPoint).AsSingle().NonLazy();
        Container.Bind<SecondPoint>().FromInstance(secondPoint).AsSingle().NonLazy();
    }

    void BindAimRay()
    {
        AimRay aimRayModel = Container.
            InstantiatePrefabForComponent<AimRay>(aimRay, firstPoint.transform.position, Quaternion.identity, ParentAimObject.transform);
        Container.Bind<AimRay>().FromInstance(aimRayModel).AsSingle().NonLazy();
    }

    void BindAimCaster()
    {
        AimRayCaster aimRayCasterModel = Container.
            InstantiatePrefabForComponent<AimRayCaster>(aimRayCaster, Vector3.zero, Quaternion.identity, ParentAimObject.transform);
        Container.Bind<AimRayCaster>().FromInstance(aimRayCasterModel).AsSingle().NonLazy();
    }
}