using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustBall : MonoBehaviour
{
    public DustBallManager manager;
    [HideInInspector] public DustBall dustBallRef;

    private void Awake()
    {
        dustBallRef = gameObject.GetComponent<DustBall>();
    }

    public void Start()
    {
        manager.dustBallList.Add(dustBallRef);
    }

    public void CleanUpDust()
    {
        manager.dustBallList.Remove(dustBallRef);
        manager.AreDustBallsCleaned();
        Destroy(gameObject);
    }
}
