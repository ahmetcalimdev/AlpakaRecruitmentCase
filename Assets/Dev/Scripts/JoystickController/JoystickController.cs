using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoystickController : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public Image joystickBackground;
    public Image joystickHandle;
    private Vector2 inputVector;

    public RectTransform canvasRect;
    public bool IsJoystickActive => joystickBackground.gameObject.activeSelf;

    private void Start()
    {
        joystickBackground.gameObject.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, eventData.position, eventData.pressEventCamera, out localPoint);
        joystickBackground.rectTransform.anchoredPosition = localPoint;
        joystickBackground.gameObject.SetActive(true);
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 localPoint;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBackground.rectTransform, eventData.position, eventData.pressEventCamera, out localPoint))
        {
            inputVector = localPoint / (joystickBackground.rectTransform.sizeDelta / 2);
            inputVector = inputVector.magnitude > 1.0f ? inputVector.normalized : inputVector;

            joystickHandle.rectTransform.anchoredPosition = new Vector2(inputVector.x * (joystickBackground.rectTransform.sizeDelta.x / 2), inputVector.y * (joystickBackground.rectTransform.sizeDelta.y / 2));
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        joystickHandle.rectTransform.anchoredPosition = Vector2.zero;
        joystickBackground.gameObject.SetActive(false);

    }

    public float Horizontal()
    {
        return inputVector.x;
    }

    public float Vertical()
    {
        return inputVector.y;
    }
}
