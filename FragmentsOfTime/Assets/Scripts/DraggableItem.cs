using Fungus;
//using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private GameObject dragObject;
    private RectTransform rectTransform;
    public Item item;
    //public Flowchart flowchart;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Create a new GameObject to drag
        dragObject = new GameObject("Drag Object");
        Image dragImage = dragObject.AddComponent<Image>();
        CanvasGroup dragCanvasGroup = dragObject.AddComponent<CanvasGroup>();

        // Copy the sprite to the new GameObject
        dragImage.sprite = GetComponent<Image>().sprite;
        dragImage.preserveAspect = true;

        // Set the parent to the canvas so it's on top of other UI elements
        dragObject.transform.SetParent(transform.root);

        // Set the size of the new GameObject
        RectTransform dragObjectRectTransform = dragObject.GetComponent<RectTransform>();
        dragObjectRectTransform.sizeDelta = rectTransform.sizeDelta;

        // Make sure the dragged object doesn't block raycasts
        dragCanvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (dragObject != null)
        {
            dragObject.transform.position = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (dragObject != null)
        {
            Destroy(dragObject);

            // Cast a ray to the point where the mouse cursor is located
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            // Check if the ray hits anything
            if (hit.collider != null)
            {
                GameObject receivingObject = hit.collider.gameObject;
                Debug.Log("Hit " + hit.collider.gameObject.name);
                switch (receivingObject.name)
                {
                    // // // Child Room

                    case "Key(ShelfView)":
                        if (item.name == "FairyWand")
                        {
                            receivingObject.SetActive(false);
                            ClickHandler.instance.GetKey();
                            ClickHandler.instance.inventory.GetComponent<AudioSource>().Play();
                        }
                        break;
                    case "ToyChest(ToyChestView)":
                        if (item.name == "Key")
                        {
                            Debug.Log("Toy Chest Opened");
                            receivingObject.GetComponent<ToyChestScript>().ToyChestOpen();
                            //ClickHandler.instance.DogToy.SetActive(true);
                            receivingObject.GetComponent<AudioSource>().Play();
                            ClickHandler.instance.ToyChest.GetComponent<SpriteRenderer>().sprite = receivingObject.GetComponent<ToyChestScript>().ToyChestSprite[1];
                            ClickHandler.instance.chestClosed = false;
                        }
                        break;
                    case "Dog(DogBowlView)(Child)":
                        if (item.name == "DogToy")
                        {
                            receivingObject.GetComponent<AudioSource>().Play();
                            ClickHandler.instance.DogToyChildEnd.SetActive(true);
                            ClickHandler.instance.flowchart.ExecuteBlock("ChildRoomEnd");
                        }
                        break;
                    

                    // // // Teen Room

                    case "DogBowl(DogBowlView)":
                        if (item.name == "Bottle")
                        {
                            receivingObject.GetComponent<DogBowlScript>().DogBowlFill();
                            receivingObject.GetComponent<AudioSource>().Play();
                            ClickHandler.instance.bowlfilled = true;
                            ClickHandler.instance.flowchart.ExecuteBlock("DogBowl(Teen)");
                            ClickHandler.instance.DogBowl.GetComponent<SpriteRenderer>().sprite = receivingObject.GetComponent<DogBowlScript>().DogBowlSprite[1];
                            InventoryManager.instance.UseItem(this.item);
                        }
                        break;
                    case "EmptyBlue":
                        if (item.name == "HangerBlue")
                        {
                            ClickHandler.instance.emptyHangerblue.SetActive(true);
                            InventoryManager.instance.UseItem(this.item);
                        }
                        break;
                    case "EmptyPink":
                        if (item.name == "HangerPink")
                        {
                            ClickHandler.instance.emptyHangerPink.SetActive(true);
                            InventoryManager.instance.UseItem(this.item);
                        }
                        break;
                    case "EmptyOrange":
                        if (item.name == "HangerOrange")
                        {
                            ClickHandler.instance.emptyHangerOrange.SetActive(true);
                            InventoryManager.instance.UseItem(this.item);
                        }
                        break;
                    case "DustBall":
                        if (item.name == "Broom")
                        {
                            receivingObject.GetComponent<DustBall>().CleanUpDust();
                        }
                        break;
                    /*case "DustBall (1)":
                        if (item.name == "Broom")
                        {
                            receivingObject.GetComponent<DustBall>().CleanUpDust();
                        }
                        break;
                    case "DustBall (2)":
                        if (item.name == "Broom")
                        {
                            receivingObject.GetComponent<DustBall>().CleanUpDust();
                        }
                        break;*/

                    // // // Adult Room

                    case "Dog(DogBowlView)":
                        if (item.name == "DogMeds")
                        {
                            Debug.Log("Meds were dropped");
                            InventoryManager.instance.UseItem(this.item);
                            ClickHandler.instance.flowchart.ExecuteBlock("Dog(Adult)2");
                        }
                        break;

                    // // // Senior Room

                    case "DogToy(EmptyArm)":
                        if(item.name == "DogToy(Arm)")
                        {
                            Debug.Log("Arm was dropped");
                            InventoryManager.instance.UseItem(this.item);
                            receivingObject.GetComponent<SpriteRenderer>().enabled = true;
                            ClickHandler.instance.dogToyParts += 1;
                        }
                        break;
                    case "DogToy(EmptyEar)":
                        if (item.name == "DogToy(Ear)")
                        {
                            Debug.Log("Ear was dropped");
                            InventoryManager.instance.UseItem(this.item);
                            receivingObject.GetComponent<SpriteRenderer>().enabled = true;
                            ClickHandler.instance.dogToyParts += 1;
                        }
                        break;
                    case "DogToy(EmptyLeg)":
                        if (item.name == "DogToy(Leg)")
                        {
                            Debug.Log("Leg was dropped");
                            InventoryManager.instance.UseItem(this.item);
                            receivingObject.GetComponent<SpriteRenderer>().enabled = true;
                            ClickHandler.instance.dogToyParts += 1;
                        }
                        break;
                    case "DogToy(EmptyButton)":
                        if (item.name == "DogToy(Button)")
                        {
                            Debug.Log("Button was dropped");
                            InventoryManager.instance.UseItem(this.item);
                            receivingObject.GetComponent<SpriteRenderer>().enabled = true;
                            ClickHandler.instance.dogToyParts += 1;
                        }
                        break;

                    // // // Tutorial Scene

                    case "ToyChest":
                        if (item.name == "KeyTut")
                        {
                            //receivingObject.SetActive(false);
                            receivingObject.GetComponent<ToyChestScript>().ToyChestOpen();
                            //ClickHandler.instance.DogToy.SetActive(true);
                            receivingObject.GetComponent<AudioSource>().Play();

                        }
                        break;
                    default:
                        Debug.Log("Item dropped on an unrecognized object");
                        break;
                }
            }
            else
            {
                Debug.Log("No hit detected.");
            }
        }
    }


    public void ChoreList()
    {
        if (item.name == "ChoreList")
        {
            ClickHandler.instance.ChoreListView.SetActive(true);
        }
        /*
        else
        {
            Debug.Log("not chore list");
        }
        */
    }
}
