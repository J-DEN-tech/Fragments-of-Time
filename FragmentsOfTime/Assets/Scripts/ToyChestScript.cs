using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToyChestScript : MonoBehaviour
{
    public List<Sprite> ToyChestSprite; //All backgrounds can be placed in here
    public SpriteRenderer image;
    public bool isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToyChestOpen()
    {
        image.sprite = ToyChestSprite[1];
        isOpen = true;
    }
}
