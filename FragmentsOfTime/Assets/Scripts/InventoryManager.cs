using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Fungus;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;
using System;

[System.Serializable]

public class Item
{
    //public GameObject prefab;
    public string name;
    public Sprite picture;
}


public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance; // Declare static instance

    [SerializeField] private GameObject itemButtonPrefab;
    [SerializeField] private Transform itemListParent;

    private List<GameObject> itemButtons = new List<GameObject>();
    private List<Item> items = new List<Item>();

    private Dictionary<Item, GameObject> itemButtonDictionary = new Dictionary<Item, GameObject>();

    public Sprite wandSprite;
    public Sprite keySprite;
    public Sprite bottleSprite;
    public Sprite hangerOrangeSprite;
    public Sprite hangerBlueSprite;
    public Sprite hangerPinkSprite;
    public Sprite dogMedSprite;
    public Sprite vetNoteSprite;
    public Sprite dogToyArmSprite;
    public Sprite dogToyLegSprite;
    public Sprite dogToyEarSprite;
    public Sprite dogToyButtonSprite;

    public bool itemPending;

    public bool menuState = false;
    private Vector3 originalPosition;
    public GameObject inventoryMenuUI;
    private void Awake()
    {
        // Ensure that there is only one instance of InventoryManager
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Add some items for testing
    private void Start()
    {
        //AddItemToInventory(new Item { name = "wand", picture = wandSprite });
        //AddItemToInventory(new Item { name = "key", picture = keySprite });
        menuState = false;
        
    }

    private void Update()
    {
        if (itemPending)
        {
            AddItemToInventory(new Item { name = "bottle", picture = bottleSprite });
            itemPending = false;
        }
    }

    public void AddItemToInventory(Item item)
    {
        // Check if inventory is full
        if (items.Count >= 5)
        {
            Debug.Log("Inventory is full. Can't pick up more items.");
            return;
        }

        items.Add(item);

        // If there's a free button, update it. Otherwise, create a new one.
        GameObject buttonContainer = itemButtons.Find(button => button.GetComponentInChildren<Button>().interactable == false);
        if (buttonContainer == null)
        {
            buttonContainer = Instantiate(itemButtonPrefab, itemListParent);
            buttonContainer.GetComponentInChildren<DraggableItem>().item = item; // set the item field
            itemButtons.Add(buttonContainer);
            itemButtonDictionary.Add(item, buttonContainer);
        }

        Button itemButton = buttonContainer.GetComponentInChildren<Button>();
        itemButton.GetComponent<Image>().sprite = item.picture;
        itemButton.interactable = true;
    }

    public void UseItem(Item item)
    {
        /*int index = items.IndexOf(item);
        if (index != -1)
        {
            items.RemoveAt(index);
            UpdateInventory();
        }
        else
        {
            Debug.Log("Item not found in the inventory.");
        }*/
        if (itemButtonDictionary.ContainsKey(item))
        {
            GameObject itemButton = itemButtonDictionary[item];
            Destroy(itemButton); // Destroy the button associated with the item
            itemButtons.Remove(itemButton); // Remove the button from the itemButtons list
            itemButtonDictionary.Remove(item); // Remove the button from the dictionary
            items.Remove(item); // Remove the item from the items list
            //Destroy(itemButtonDictionary[item]); // Destroy the button associated with the item
            //itemButtonDictionary.Remove(item); // Remove the button from the dictionary
            //items.Remove(item); // Remove the item from the items list
            // No need to call UpdateInventory() here
        }
        else
        {
            Debug.Log("Item not found in the inventory.");
        }
    }

    private void UpdateInventory()
    {
        // Disable all buttons
        foreach (GameObject itemButton in itemButtons)
        {
            itemButton.GetComponentInChildren<Button>().interactable = false;
        }

        // Enable and update necessary buttons
        for (int i = 0; i < items.Count; i++)
        {
            itemButtons[i].GetComponent<Image>().sprite = items[i].picture;
            itemButtons[i].GetComponent<Button>().interactable = true;
        }
    }

    public void MenuState()
    {
        if(menuState == false)
        {
            OpenMenu();
        }
        else
        {
            CloseMenu();
        }
    }
    public void OpenMenu()
    {
        originalPosition = inventoryMenuUI.GetComponent<RectTransform>().anchoredPosition;
        StartCoroutine(MoveObject(inventoryMenuUI.GetComponent<RectTransform>(), new Vector3(129f, -6.461162f, -2.143231f), 0.25f));
        menuState = true;
    }
    public void CloseMenu() 
    {
        menuState = false;
        StartCoroutine(MoveObject(inventoryMenuUI.GetComponent<RectTransform>(), originalPosition, 0.25f));
    }
    IEnumerator MoveObject(RectTransform objectToMove, Vector3 targetPosition, float duration)
    {
        float elapsed = 0;
        Vector3 startingPosition = objectToMove.anchoredPosition;

        while (elapsed < duration)
        {
            objectToMove.anchoredPosition = Vector3.Lerp(startingPosition, targetPosition, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        objectToMove.anchoredPosition = targetPosition;
    }
}
