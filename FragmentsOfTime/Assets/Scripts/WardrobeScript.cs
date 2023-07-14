using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WardrobeScript : MonoBehaviour
{
    public List<Sprite> WardrobeSprite; //All backgrounds can be placed in here
    public SpriteRenderer image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void WardrobeOpen()
    {
        image.sprite = WardrobeSprite[1];
    }
}
