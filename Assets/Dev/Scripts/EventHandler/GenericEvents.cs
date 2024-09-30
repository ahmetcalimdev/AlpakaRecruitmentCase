using UnityEngine;
using UnityEngine.Events;

public class GenericEvents : MonoBehaviour
{
    public static UnityEvent onUpdate;
    public static UnityEvent onLateUpdate;
    public static UnityEvent onFixedUpdate;
    private void Update()
    {
        onUpdate?.Invoke();
    }
    private void LateUpdate()
    {
        onLateUpdate?.Invoke();
    }
    private void FixedUpdate()
    {
        onFixedUpdate?.Invoke();
    }
}
