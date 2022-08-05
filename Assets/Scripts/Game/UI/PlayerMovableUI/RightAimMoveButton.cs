
using UnityEngine.EventSystems;
using UnityEngine;

public class RightAimMoveButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    internal bool isMoving = false;

    public void OnPointerDown(PointerEventData eventData) => isMoving = true;
    public void OnPointerUp(PointerEventData eventData) => isMoving = false;
}
