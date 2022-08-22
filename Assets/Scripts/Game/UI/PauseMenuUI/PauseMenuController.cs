using UnityEngine;
using UniRx;
using System;

public class PauseMenuController : MonoBehaviour
{
    internal PauseMenuModel Model { get => pauseMenuModel ??= GetComponent<PauseMenuModel>(); }
    PauseMenuModel pauseMenuModel;
    internal PauseMenuView View { get => pauseMenuView ??= GetComponent<PauseMenuView>(); }
    PauseMenuView pauseMenuView;

    private void Awake() => SubscribeToObservables();


    void SubscribeToObservables()
    {
        SubscribeToExitToMenu();
        SubscribeToOpenPauseMenu();
        SubscribeToRestart();
        SubscribeToBackToGame();
        HidePauseMenu();
    }

    private void SubscribeToBackToGame() => View.BackButton.Button.OnClickAsObservable().
        Subscribe(_ => View.BackButton.GoBackToTheGame
        (View.Panel, Model.MovementCanvas, Model.Player)).AddTo(this);

    private void SubscribeToOpenPauseMenu() => View.PauseButton.Button.OnClickAsObservable().
    Subscribe(_ => View.PauseButton.MakePause
    (View.Panel, Model.MovementCanvas)).AddTo(this);

    private void SubscribeToRestart() => View.RestartButton.Button.OnClickAsObservable().
        Subscribe(_ => View.RestartButton.DoRestart()).AddTo(this);

    private void SubscribeToExitToMenu() => View.ExitButton.Button.OnClickAsObservable().
        Subscribe(_ => View.ExitButton.DoExitToMenu()).AddTo(this);

    private void HidePauseMenu() => View.Panel.gameObject.SetActive(false);



}
