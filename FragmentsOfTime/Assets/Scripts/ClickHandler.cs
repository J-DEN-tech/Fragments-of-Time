using Fungus;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClickHandler : MonoBehaviour
{
    public Flowchart flowchart;
    Scene currentScene;

    public GameObject RoomStart;
    public GameObject WindowView;
    public GameObject ToyChestView;
    public GameObject ShelfView;
    public GameObject WardrobeView;
    public GameObject DeskView;
    public GameObject DogBowlView;
    public GameObject BedView;
    public GameObject DrawerView;
    public GameObject VetNoteView;
    public GameObject ComputerView;


    public GameObject ToyChest;
    public GameObject DogToy; public GameObject DogToyChildEnd;


    public bool hasKey = false;
    public bool hasWand = false;
    public bool hasDogToy = false;

    public bool bowlfilled = false;
    public bool chestClosed = false;
    public int hangerTotal;
    public bool hangerFinished = false;
    public GameObject CoatHangerOrange;
    public GameObject CoatHangerBlue;
    public GameObject CoatHangerPink;
    public GameObject CoatHangerAll;

    public GameObject DeskLock;
    public TMP_InputField DeskCodeInputField;
    public string drawerCode = "1215";
    public bool isDeskLockOpen = false;

    public GameObject ComputerLock;
    public TMP_InputField ComputerInputField;
    public string computerCode = "462895";
    public bool isComputerLockOpen = false;


    private void Start()
    {
        RoomStart.SetActive(true);
        WindowView.SetActive(false);
        ToyChestView.SetActive(false);
        ShelfView.SetActive(false);
        WardrobeView.SetActive(false);
        DeskView.SetActive(false);
        DogBowlView.SetActive(false);
        BedView.SetActive(false);
        DrawerView.SetActive(false);
        DeskLock.SetActive(false);
        VetNoteView.SetActive(false);
        ComputerView.SetActive(false);
        ComputerLock.SetActive(false);

        currentScene = SceneManager.GetActiveScene();
        Debug.Log("current scene = " + currentScene.name);
        /*switch(currentScene.name)
        {
            case "ChildRoom":
                flowchart.ExecuteBlock("ChildRoomStart");
                break;
        }*/

        DeskCodeInputField = DeskLock.GetComponentInChildren<TMP_InputField>();
        if (DeskCodeInputField == null)
        {
            Debug.Log("DeskCodeInputField is not assigned.");
        }
        else
        {
            Debug.Log("DeskCodeInputField is assigned.");
        }
        ComputerInputField = ComputerLock.GetComponentInChildren<TMP_InputField>(); 
        if (ComputerInputField == null) 
        {
            Debug.Log("ComputerCodeInputField is not assigned.");
        }
        else
        {
            Debug.Log("ComputerCodeInputField is assigned.");
        }
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
                        if(currentScene.name == "ChildRoom")
                        {
                            DogBowlView.SetActive(true);
                            RoomStart.SetActive(false);
                        }
                        break;
                    case "Dog(DogBowlView)":
                        if(currentScene.name == "ChildRoom" && hasDogToy == false)
                        {
                            clickedObject.GetComponent<AudioSource>().Play();
                        }
                        else if(currentScene.name == "ChildRoom" && hasDogToy == true)
                        {
                            clickedObject.GetComponent<AudioSource>().Play();
                            DogToyChildEnd.SetActive(true);
                            flowchart.ExecuteBlock("ChildRoomEnd");
                        }
                        flowchart.ExecuteBlock("Dog(Adult)");
                        break;
                    case "Window":
                        WindowView.SetActive(true);
                        RoomStart.SetActive(false);
                        WardrobeView.SetActive(false);
                        break;
                    case "Window(Adult)":
                        WindowView.SetActive(true);
                        RoomStart.SetActive(false);
                        WardrobeView.SetActive(false);
                        flowchart.ExecuteBlock("Window(Adult)");
                        break;
                    case "FlowerPot(WindowView)":
                        Debug.Log("FlowerPot Clicked");
                        StartCoroutine(MoveObject(hit.collider.transform.Find("FairyWand"), new Vector3(6.9f, -6.16f, 0), 1f));
                        break;
                    case "FairyWand":
                        Debug.Log("Fairy wand Obtained");
                        clickedObject.SetActive(false);
                        hasWand = true;
                        flowchart.ExecuteBlock("FairyWand(Child)");
                        break;
                    case "CoatHanger(WindowView)":
                        clickedObject.SetActive(false);
                        CoatHangerOrange.SetActive(false);
                        hangerTotal += 1;
                        flowchart.ExecuteBlock("CoatHangerOrange");
                        break;
                    case "CoatHangerBlue":
                        clickedObject.SetActive(false);
                        hangerTotal+= 1;
                        break;
                    case "CoatHangerPink":
                        clickedObject.SetActive(false);
                        hangerTotal+= 1;
                        CoatHangerPink.SetActive(false);
                        break;
                    case "ToyChest":
                        ToyChestView.SetActive(true);
                        RoomStart.SetActive(false);
                        WardrobeView.SetActive(false);
                        break;
                    case "ToyChest(ToyChestView)":
                        if(hasKey == false && currentScene.name == "ChildRoom")
                        {
                            flowchart.ExecuteBlock("LockedChest");
                        }
                        else if(hasKey == true && currentScene.name == "ChildRoom")
                        {
                            Debug.Log("Toy Chest Opened");
                            clickedObject.GetComponent<ToyChestScript>().ToyChestOpen();
                            DogToy.SetActive(true);
                            clickedObject.GetComponent<AudioSource>().Play();
                            ToyChest.GetComponent<SpriteRenderer>().sprite = clickedObject.GetComponent<ToyChestScript>().ToyChestSprite[1];
                        }
                        else
                        {
                            Debug.Log("Toy Chest Opened");
                            clickedObject.GetComponent<ToyChestScript>().ToyChestOpen();
                            clickedObject.GetComponent<AudioSource>().Play();
                            chestClosed = true;
                            ToyChest.GetComponent<SpriteRenderer>().sprite = clickedObject.GetComponent<ToyChestScript>().ToyChestSprite[1];
                        }
                        break;
                    case "DogToy":
                        clickedObject.SetActive(false);
                        hasDogToy = true;
                        flowchart.ExecuteBlock("DogToy(Child)");
                        break;
                    case "Wardrobe":
                        WardrobeView.SetActive(true);
                        RoomStart.SetActive(false);
                        BedView.SetActive(false);
                        flowchart.ExecuteBlock("Wardrobe(Child)");
                        break;
                    case "Wardrobe(WardrobeView)":
                        clickedObject.GetComponent<WardrobeScript>().WardrobeOpen();
                        clickedObject.GetComponent<AudioSource>().Play();
                        if(currentScene.name == "Teen_Room" && hangerTotal < 3)
                        {
                            flowchart.ExecuteBlock("Wardrobe1");
                        }
                        else if(currentScene.name == "Teen_Room" && hangerTotal >= 3)
                        {
                            CoatHangerAll.SetActive(true);
                            hangerFinished = true;
                            flowchart.ExecuteBlock("Wardrobe2");
                        }
                        break;
                    case "Shelf":
                        ShelfView.SetActive(true);
                        RoomStart.SetActive(false);
                        break;
                    case "Key(ShelfView)":
                        if(hasWand == false)
                        {
                            flowchart.ExecuteBlock("Shelf(Child)");
                        }
                        else
                        {
                            Debug.Log("Key Obtained");
                            hasKey = true;
                            clickedObject.SetActive(false);
                            flowchart.ExecuteBlock("Key(Child)");
                        }
                        break;
                    case "Desk":
                        DeskView.SetActive(true);
                        RoomStart.SetActive(false);
                        break;
                    case "Desk(DeskView)":
                        if(isDeskLockOpen == false)
                        {
                            Debug.Log("isDeskLockOpen = " + isDeskLockOpen);
                            DeskLock.SetActive(true);
                            flowchart.ExecuteBlock("Drawer1");
                        }
                        else if (isDeskLockOpen == true)
                        {
                            Debug.Log("isDeskLockOpen = " + isDeskLockOpen);
                            DrawerView.SetActive(true);
                            DeskView.SetActive(false);
                            DrawerView.GetComponent<AudioSource>().Play();
                            flowchart.ExecuteBlock("Drawer3");
                        }
                        break;
                    case "DogMeds":
                        clickedObject.SetActive(false);
                        break;
                    case "VetNote":
                        VetNoteView.SetActive(true);
                        DrawerView.SetActive(false);
                        flowchart.ExecuteBlock("VetNote");
                        break;
                    case "Computer":
                        ComputerView.SetActive(true);
                        DeskView.SetActive(false);
                        if(isComputerLockOpen == false) 
                        {
                            Debug.Log("isComputerLockOpen = " + isComputerLockOpen);
                            ComputerLock.SetActive(true);
                            flowchart.ExecuteBlock("Computer1");
                        }
                        else if (isComputerLockOpen == true)
                        {
                            Debug.Log("isComputerLockOpen = " + isComputerLockOpen);
                        }
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
                        bowlfilled = true;
                        flowchart.ExecuteBlock("DogBowl(Teen)");
                        break;
                    case "Bed":
                        BedView.SetActive(true);
                        RoomStart.SetActive(false);
                        flowchart.ExecuteBlock("Bed(Child)");
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
            BedView.SetActive(false);
            DrawerView.SetActive(false);
            DeskLock.SetActive(false);
            VetNoteView.SetActive(false);
            ComputerView.SetActive(false);
            ComputerLock.SetActive(false);
            Debug.Log("Went back to previous screen");
            TeenRoomEnd();

        }
        else
        {
            Debug.Log("No previous screen, or button not working");
        }
    }
    public void DeskCode()
    {
        string enteredCode = DeskCodeInputField.text;

        if(enteredCode == drawerCode)
        {
            Debug.Log("Correct Code");
            isDeskLockOpen = true;
            //DeskLock.GetComponent<AudioSource>().Play();
            GameObject.Find("BackButton").GetComponent<AudioSource>().Play();
            DeskLock.SetActive(false);
            flowchart.ExecuteBlock("Drawer2");
        }
        else
        {
            Debug.Log("incorrect code");
        }
    }
    public void ComputerCode()
    {
        string enteredCode = ComputerInputField.text;

        if (enteredCode == computerCode)
        {
            Debug.Log("Correct Code");
            isComputerLockOpen = true;
            //DeskLock.GetComponent<AudioSource>().Play();
            GameObject.Find("BackButton").GetComponent<AudioSource>().Play();
            ComputerLock.SetActive(false);
        }
        else
        {
            Debug.Log("incorrect code");
        }
    }
    public void TeenRoomEnd()
    {
        if(currentScene.name == "Teen_Room" && chestClosed == true && hangerFinished == true && bowlfilled == true) 
        {
            flowchart.ExecuteBlock("TeenRoomEnd");
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
