using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public RectTransform joystickBG;
    public RectTransform joystickHandle;
    public float handleLimit = 50f; // maksimal jarak handle dari pusat

    [HideInInspector]
    public Vector2 input = Vector2.zero;

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        input = Vector2.zero;
        joystickHandle.anchoredPosition = Vector2.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBG, eventData.position, eventData.pressEventCamera, out pos))
        {
            pos.x = (pos.x / joystickBG.sizeDelta.x) * 2;
            pos.y = (pos.y / joystickBG.sizeDelta.y) * 2;

            input = new Vector2(pos.x, pos.y);
            input = (input.magnitude > 1) ? input.normalized : input;

            joystickHandle.anchoredPosition = new Vector2(input.x * handleLimit, input.y * handleLimit);
        }
    }
}
