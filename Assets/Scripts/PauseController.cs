using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class PauseController : MonoBehaviour
{
    public Button help_button;
    private bool is_Active;
    public GameObject help_panel;

    public TMP_Text buttonText;

    // Start is called before the first frame update
    void Start()
    {
        help_button.onClick.AddListener(PauseGame);
        is_Active = false;
    }



    void PauseGame()
    {
        is_Active = !is_Active;     // If button is hit, switch between active and inactive

        if (is_Active)
        {
            Time.timeScale = 0;
            help_panel.SetActive(true);
            buttonText.text = "Back";       // "Help" >>> "Back"
        }
        else
        {
            Time.timeScale = 1;
            help_panel.SetActive(false);
            buttonText.text = "Help";       // "Back" >>> "Help"
        }
        
    }
}
