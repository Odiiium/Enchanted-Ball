using UnityEngine;
using Zenject;

public class MusicThemeInstaller : MonoInstaller
{
    [SerializeField] MusicThemeProvider musicThemeProvider;

    public override void InstallBindings()
    {
        MusicThemeProvider musicThemeProviderModel = Container.
            InstantiatePrefabForComponent<MusicThemeProvider>(musicThemeProvider, Vector3.zero, Quaternion.identity, null);
        Container.Bind<MusicThemeProvider>().FromInstance(musicThemeProviderModel).AsSingle().NonLazy();
    }
}