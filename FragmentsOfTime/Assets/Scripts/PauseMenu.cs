using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject settingsMenu;
    public GameObject MasterObject;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ActivateSettings()
    {
        settingsMenu.GetComponent<Canvas>().enabled = true;
        MasterObject.GetComponent<ColliderToggler>().DisableColliders();
    }
    public void CloseSettings()
    {
        settingsMenu.GetComponent<Canvas>().enabled = false;
        MasterObject.GetComponent<ColliderToggler>().EnableColliders();
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
