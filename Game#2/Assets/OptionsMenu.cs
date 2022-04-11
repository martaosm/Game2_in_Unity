using System.Collections;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject optionsB;
    public GameObject player;
    private bool menuOpened = false;

    void Update()
    {
        if (Input.GetKey(KeyCode.O))
        {
            menuOpened = true;
        }
        if (menuOpened == true)
        {
            optionsMenu.SetActive(true);
            optionsB.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void ReturnGame()
    {
        optionsMenu.SetActive(false);
        optionsB.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        menuOpened = false;
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}
