using UnityEngine;
using UnityEngine.EventSystems;

public class ItemPickup : Interactible
{
    public Item item;

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);

        PickUp();
    }

    void PickUp()
    {
        Debug.Log("Picking up " + item.name);
        Inventory.instance.Add(item);
        Destroy(gameObject);
    }
}
