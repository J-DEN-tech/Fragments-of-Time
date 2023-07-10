using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundSwapper : MonoBehaviour
{
    public List<Sprite> backgroundImageList; //All backgrounds can be placed in here
    public Image image;
    public float fadeDuration = 0.2f;
    public int backgroundImageValue;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    public void BackgroundStart()// called by the dialogue
    {
        backgroundImageValue = 0; // change this to the position of the image you're switching to in the list
        StartCoroutine(FadeToBlack()); // fades background to black, changes the image, then fades back
    }
    public void WindowBackground()// called by the dialogue
    {
        backgroundImageValue = 1; // change this to the position of the image you're switching to in the list
        StartCoroutine(FadeToBlack()); // fades background to black, changes the image, then fades back
    }

    IEnumerator FadeToBlack()
    {
        // fades the background to black
        Color originalColor = image.color;
        float timer = 0.0f;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float ratio = timer / fadeDuration;
            image.color = Color.Lerp(originalColor, Color.black, ratio);
            yield return null;
        }

        image.color = Color.black; // Ensure final color is black
        image.sprite = backgroundImageList[backgroundImageValue]; // changes the background image
        StartCoroutine(FadeBack()); // fades back to the new image
    }

    IEnumerator FadeBack()
    {
        Color originalColor = image.color;
        float timer = 0.0f;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float ratio = timer / fadeDuration;
            image.color = Color.Lerp(originalColor, Color.white, ratio);
            yield return null;
        }

        image.color = Color.white;
    }
}
