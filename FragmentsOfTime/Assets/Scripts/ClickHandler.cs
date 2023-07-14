using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    public GameObject RoomStart;
    public GameObject WindowView;
    public GameObject ToyChestView;
    public GameObject ShelfView;
    public GameObject WardrobeView;
    public GameObject DeskView;
    public GameObject DogBowlView;

    public int hangerTotal;
    public GameObject CoatHangerOrange;
    
    private void Start()
    {
        RoomStart.SetActive(true);
        WindowView.SetActive(false);
        ToyChestView.SetActive(false);
        ShelfView.SetActive(false);
        WardrobeView.SetActive(false);
        DeskView.SetActive(false);
        DogBowlView.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 0 is the left mouse button
        {
            // Create a ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            // If the ray hit a collider, it will return the first one hit
            if (hit.collider != null)
            {
                GameObject clickedObject = hit.collider.gameObject;
                switch (clickedObject.name)
                {
                    case "Dog":
                        clickedObject.GetComponent<AudioSource>().Play();
                        break;
                    case "Window":
                        WindowView.SetActive(true);
                        RoomStart.SetActive(false);
                        WardrobeView.SetActive(false);
                        break;
                    case "FlowerPot(WindowView)":
                        Debug.Log("FlowerPot Clicked");
                        StartCoroutine(MoveObject(hit.collider.transform.Find("FairyWand"), new Vector3(6.9f, -6.16f, 0), 1f));
                        break;
                    case "FairyWand":
                        Debug.Log("Fairy wand Obtained");
                        clickedObject.SetActive(false);
                        break;
                    case "CoatHanger(WindowView)":
                        clickedObject.SetActive(false);
                        CoatHangerOrange.SetActive(false);
                        hangerTotal += 1;
                        break;
                    case "ToyChest":
                        ToyChestView.SetActive(true);
                        RoomStart.SetActive(false);
                        WardrobeView.SetActive(false);
                        break;
                    case "ToyChest(ToyChestView)":
                        Debug.Log("Toy Chest Opened");
                        clickedObject.GetComponent<ToyChestScript>().ToyChestOpen();
                        clickedObject.GetComponent<AudioSource>().Play();
                        break;
                    case "Wardrobe":
                        WardrobeView.SetActive(true);
                        RoomStart.SetActive(false);
                        break;
                    case "Wardrobe(WardrobeView)":
                        clickedObject.GetComponent<WardrobeScript>().WardrobeOpen();
                        clickedObject.GetComponent<AudioSource>().Play();
                        break;
                    case "Shelf":
                        ShelfView.SetActive(true);
                        RoomStart.SetActive(false);
                        break;
                    case "Key(ShelfView)":
                        Debug.Log("Key Obtained");
                        clickedObject.SetActive(false);
                        break;
                    case "Desk":
                        DeskView.SetActive(true);
                        RoomStart.SetActive(false);
                        break;
                    case "Broom(DeskView)":
                        Debug.Log("Broom Obtained");
                        clickedObject.SetActive(false);
                        break;
                    case "Bottle(DeskView)":
                        Debug.Log("Bottle Obtained");
                        clickedObject.SetActive(false);
                        break;
                    case "DogBowl":
                        DogBowlView.SetActive(true);
                        RoomStart.SetActive(false);
                        break;
                    case "DogBowl(DogBowlView)":
                        clickedObject.GetComponent<DogBowlScript>().DogBowlFill();
                        clickedObject.GetComponent<AudioSource>().Play();
                        break;
                    default:
                        Debug.Log(clickedObject.name + " was clicked!");
                        // Perform default action
                        break;
                }
            }
        }
    }
    public void BackButton()
    {
        if(!RoomStart.activeInHierarchy)
        {
            RoomStart.SetActive(true);
            WindowView.SetActive(false);
            ToyChestView.SetActive(false);
            ShelfView.SetActive(false);
            WardrobeView.SetActive(false);
            DeskView.SetActive(false);
            DogBowlView.SetActive(false);
        }
    }
    IEnumerator MoveObject(Transform objectToMove, Vector3 targetPosition, float duration)
    {
        float elapsed = 0;
        Vector3 startingPosition = objectToMove.localPosition;
        BoxCollider2D collider = objectToMove.GetComponent<BoxCollider2D>();

        while (elapsed < duration)
        {
            objectToMove.localPosition = Vector3.Lerp(startingPosition, targetPosition, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        objectToMove.localPosition = targetPosition;
        collider.enabled = true;
    }

}
