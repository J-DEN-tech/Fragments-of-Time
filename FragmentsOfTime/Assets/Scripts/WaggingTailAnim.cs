using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaggingTailAnim : MonoBehaviour
{
    public GameObject Dog = null;
    Animator anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }


    void Update()
    {
        bool Wagging = false;
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 up = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D coll = Dog.GetComponent<Collider2D>();
            
           
                Wagging = true;
        

            anim.SetBool("Wagging", Wagging);
        }
    }
}
