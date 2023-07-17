using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class TimeLine_SceneChange : MonoBehaviour
{
    public float changeTime;
    public string sceneName;
    public Flowchart flowchart;

    void Update()
    {
      changeTime -= Time.deltaTime;
      if(changeTime <= 0)
      {
            flowchart.ExecuteBlock("Start");
      }
    }
}
