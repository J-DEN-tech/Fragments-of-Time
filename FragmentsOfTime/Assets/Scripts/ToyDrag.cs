using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyDrag : MonoBehaviour
{
    Vector2 difference = Vector2.zero;

    private AudioSource audioSource;
    public AudioClip clickSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        difference = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
        PlayClickSound();
    }

    private void OnMouseDrag()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;
    }

    private void PlayClickSound()
    {
        if (clickSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }
}
