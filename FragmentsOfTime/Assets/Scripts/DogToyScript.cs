using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogToyScript : MonoBehaviour
{
    public List<Sprite> DogToySprite;
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
    public void DogToyChange()
    {
        image.sprite = DogToySprite[1];
    }
}
