using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.EventSystems;

public class TutorialClickHandler : MonoBehaviour
{
    public Flowchart flowchart;
    Scene currentScene;
    public GameObject tutView;
    public GameObject inventory;
    public GameObject clickMe;
    public GameObject inventoryState;
    public TMP_Text stateText;
    public GameObject firstControls;
    public GameObject chestText;
    public GameObject key;
    public GameObject quitButton;
    public GameObject chest;

    // Start is called before the first frame update
    public void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        Debug.Log("current scene = " + currentScene.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (tutView.activeInHierarchy == true)
        {
            StartCoroutine(WaitAndExecute(2.2f));
        }
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
                        firstControls.SetActive(false);
                        inventoryState.SetActive(true);
                        break;
                    default:
                        Debug.Log(clickedObject.name + " was clicked!");
                        // Perform default action
                        break;
                }
            }
        }
        if (InventoryManager.instance.menuState == true)
        {
            stateText.text = "Close Inventory";
        }
        else
        {
            stateText.text = "Open Inventory";
        }
        if (InventoryManager.instance.menuState == true && key.activeInHierarchy == false)
        {
            chestText.SetActive(true);
        }
        if (chest.GetComponent<ToyChestScript>().isOpen == true)
        {
            quitButton.SetActive(true);
            chestText.SetActive(false);
            inventoryState.SetActive(false);
        }
    }
    IEnumerator WaitAndExecute(float delay)
    {
        yield return new WaitForSeconds(delay);

        firstControls.SetActive(false);
        clickMe.SetActive(true);
    }
}

