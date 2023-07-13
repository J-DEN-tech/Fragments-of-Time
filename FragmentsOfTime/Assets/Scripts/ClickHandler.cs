using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    public GameObject ChildRoomStart;
    public GameObject WindowView;
    public GameObject ToyChestView;

    private void Start()
    {
        ChildRoomStart.SetActive(true);
        WindowView.SetActive(false);
        ToyChestView.SetActive(false);
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
                    case "Window":
                        WindowView.SetActive(true);
                        ChildRoomStart.SetActive(false);
                        break;
                    case "FlowerPot(WindowView)":
                        Debug.Log("FlowerPot Clicked");
                        StartCoroutine(MoveObject(hit.collider.transform.Find("FairyWand"), new Vector3(6.9f, -6.16f, 0), 1f));
                        break;
                    case "FairyWand":
                        Debug.Log("Fairy wand Obtained");
                        clickedObject.SetActive(false);
                        break;
                    case "ToyChest":
                        ToyChestView.SetActive(true);
                        ChildRoomStart.SetActive(false);
                        break;
                    case "ToyChest(ToyChestView)":
                        Debug.Log("Toy Chest Opened");
                        clickedObject.GetComponent<ToyChestScript>().ToyChestOpen();
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
        if(!ChildRoomStart.activeInHierarchy)
        {
            ChildRoomStart.SetActive(true);
            WindowView.SetActive(false);
            ToyChestView.SetActive(false);
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
