using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class ColliderToggler : MonoBehaviour
{
    private List<Collider2D> allColliders;

    private void Awake()
    {
        // Cache all colliders at the start
        allColliders = new List<Collider2D>(FindObjectsOfType<Collider2D>(true));
    }

    public void DisableColliders()
    {
        Debug.Log("Disabling colliders.");
        // Disable all colliders when dialogue starts
        foreach (var collider in allColliders)
        {
            if (collider) 
            {
                collider.enabled = false;
            }
        }
    }

    public void EnableColliders()
    {
        Debug.Log("Enabling colliders.");
        // Enable all colliders when dialogue ends
        foreach (var collider in allColliders)
        {
            if (collider) collider.enabled = true;
        }
    }
}
