using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCounter : MonoBehaviour
{
    private GameObject[] trash_list1;
    private GameObject[] trash_list2;
    public GameObject finish;
    private Timer timer;
    public GameObject digital_clock;


    void Start()
    {
        timer = digital_clock.GetComponent<Timer>();

    }
    void Update()
    {
        // Find all objects with Tags
        // "Planet Trash" or "Moon Trash"

        trash_list1 = GameObject.FindGameObjectsWithTag("Planet Trash");
        trash_list2 = GameObject.FindGameObjectsWithTag("Moon Trash");

        // When there is no trash in the scene
        // Finish the game with a finished panel
        if (trash_list1.Length == 0 && trash_list2.Length == 0)
        {
            finish.SetActive(true);
            timer.timerOn = false;
        }
    }
}
