using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustBallManager : MonoBehaviour
{
    [HideInInspector]public List<DustBall> dustBallList = new List<DustBall>();
    [HideInInspector] public bool dustBallsCleaned = false;

    public void AreDustBallsCleaned()
    {
        if (dustBallList.Count == 0)
        {
            Debug.Log("Dust balls have been cleaned");
            dustBallsCleaned = true;
            ClickHandler.instance.flowchart.ExecuteBlock("DustFinished");
        }
    }
}
