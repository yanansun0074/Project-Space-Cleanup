using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public bool timerOn;
    public float TimeLeft;
    public GameObject end_panel;

    public TMP_Text TimerText;

    // Start is called before the first frame update
    void Start()
    {
        timerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerOn)
        {

            
            TimeLeft -= Time.deltaTime;
            TimerText.text = TimeLeft.ToString();
            
        }
    }
}
