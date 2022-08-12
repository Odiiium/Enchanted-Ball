using UnityEngine;
internal class MainMenuUIController : MonoBehaviour 
{
    internal MainMenuUIView View { get => mainMenuUIView ??= GetComponent<MainMenuUIView>(); }
    MainMenuUIView mainMenuUIView;
    internal MainMenuUIModel Model { get => mainMenuUIModel ??= GetComponent<MainMenuUIModel>(); }
    MainMenuUIModel mainMenuUIModel;
}
