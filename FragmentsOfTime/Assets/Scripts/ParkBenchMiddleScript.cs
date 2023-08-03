using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;


public class ParkBenchMiddleScript : MonoBehaviour
{
    public static ParkBenchMiddleScript instance;
    public Flowchart flowchart;
    Scene currentScene;
    public bool childRoomDone = false;
    public bool teenRoomDone = false;
    public bool adultRoomDone = false;
    public bool seniorRoomDone = false;

    // Start is called before the first frame update
    void Start()
    {
        if(currentScene.name == "Parkbench_Middle")
        {
            if(childRoomDone == true)
            {
                flowchart.ExecuteBlock("AfterChild");
            }
            else if (childRoomDone == true && teenRoomDone == true)
            {
                flowchart.ExecuteBlock("AfterTeen");
            }
            else if(childRoomDone == true && teenRoomDone == true && adultRoomDone == true)
            {
                flowchart.ExecuteBlock("AfterAdult");
            }
            else if (childRoomDone == true && teenRoomDone == true && adultRoomDone == true && seniorRoomDone)
            {

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
