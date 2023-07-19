using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    Vector2 difference = Vector2.zero;

    private Color[] colors = { Color.red, Color.green, Color.blue }; // Add any colors you want here
    private int currentColorIndex = 0;
    private SpriteRenderer spriteRenderer;

    private AudioSource audioSource;
    public AudioClip clickSound;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        difference = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
        ChangeColorOnClick();
        PlayClickSound();
    }

    private void OnMouseDrag()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;
    }

    private void ChangeColorOnClick()
    {
        currentColorIndex = (currentColorIndex + 1) % colors.Length;
        spriteRenderer.color = colors[currentColorIndex];
    }

    private void PlayClickSound()
    {
        if (clickSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }
}
