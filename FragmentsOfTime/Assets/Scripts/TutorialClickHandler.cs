using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;
using Unity.VisualScripting;
using UnityEngine.EventSystems;

public class TutorialClickHandler : MonoBehaviour
{
    public Flowchart flowchart;
    Scene currentScene;
    public GameObject inventory;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        Debug.Log("current scene = " + currentScene.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 0 is the left mouse button
        {
            if (EventSystem.current.IsPointerOverGameObject(-1)) // Pass -1 to consider all pointers
            {
                PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
                eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

                List<RaycastResult> results = new List<RaycastResult>();
                EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

                if (results.Count > 0)
                {
                    // If we are here, the mouse is over a UI element
                    Debug.Log("UI element clicked");
                    return;
                }
            }
            // Create a ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            // If the ray hit a collider, it will return the first one hit
            if (hit.collider != null)
            {
                GameObject clickedObject = hit.collider.gameObject;
                switch (clickedObject.name)
                {
                    case "ToyChest":

                        break;
                    case "KeyTut":
                        clickedObject.SetActive(false);
                        inventory.GetComponent<InventoryManager>().AddItemToInventory(
                            new Item { name = "KeyTut", picture = inventory.GetComponent<InventoryManager>().keySprite });
                        break;
                    default:
                        Debug.Log(clickedObject.name + " was clicked!");
                        // Perform default action
                        break;
                }
            }
        }
    }
}

