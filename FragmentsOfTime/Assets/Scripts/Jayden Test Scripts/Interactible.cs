using UnityEngine;
using UnityEngine.EventSystems;

public class Interactible : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    virtual public void OnPointerClick(PointerEventData eventData)
    {
        
    }

    virtual public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Interacting with " + name);
    }

    virtual public void OnPointerUp(PointerEventData eventData)
    {

    }

    virtual public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    virtual public void OnPointerExit(PointerEventData eventData)
    {
        
    }
}
