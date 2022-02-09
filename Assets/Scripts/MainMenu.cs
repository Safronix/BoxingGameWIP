using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuScreen, SettingsMenuScreen;

    void Awake()
    {
        MainMenuScreen.SetActive(true);
        SettingsMenuScreen.SetActive(false);
    }

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

    public void NewGame()
    {
        //Loads the main game scene by name
        SceneManager.LoadScene(sceneName: "MainGame");
    }

    /*public void LoadGame()
    {

    }
    */

    public void Settings()
    {
        MainMenuScreen.SetActive(false);
        SettingsMenuScreen.SetActive(true);
    }

}
