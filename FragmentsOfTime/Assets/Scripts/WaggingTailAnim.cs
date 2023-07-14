using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaggingTailAnim : MonoBehaviour
{
    public GameObject Dog = null;
    Animator anim;
    bool Wagging = false;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !Wagging)
        {
            Wagging = true;
            anim.SetBool("Wagging", true);
        }

          if (Input.GetMouseButtonUp(0) && Wagging)
        {
            Wagging = false;
            anim.SetBool("Wagging", false);
        }
    }

    // This function will be called when the animation finishes playing
    public void AnimationFinished()
    {
        Wagging = false;
        anim.SetBool("Wagging", false);
    }
}