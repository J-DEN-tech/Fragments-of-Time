using UnityEngine;
using UnityEngine.EventSystems;

public class ItemReceiver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static ItemReceiver instance; // Singleton instance for simplicity

    public bool isOver { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isOver = true;
        Debug.Log("Pointer entered");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isOver = false;
        Debug.Log("Pointer exited");
    }
}
