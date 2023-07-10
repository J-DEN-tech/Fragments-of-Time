using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{

    public void MouseClick()
    {
        Debug.Log(" was clicked!");
        // Add any additional code to run when the object is clicked
    }

    void OnMouseDown()
    {
        Debug.Log(gameObject.name + " was clicked!");
        // Add any additional code to run when the object is clicked
    }

}
