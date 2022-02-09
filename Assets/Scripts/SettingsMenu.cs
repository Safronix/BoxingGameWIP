using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{

    public GameObject MainMenuScreen, SettingsMenuScreen;



    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Back()
    {
        SettingsMenuScreen.SetActive(false);
        MainMenuScreen.SetActive(true);
    }



}
//In order to detail the slider for violence filtering, check the value of the slider and have a text box above that will change text
//based on the value; If value is one, filter nothing. If two, filter blood. If three, filter blood, broken bones and whatever else may be violent.