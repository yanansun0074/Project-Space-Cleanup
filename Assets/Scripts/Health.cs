using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    public int health;      // Keep track of health value
    public Image[] hearts;      // Place heart image

    public GameObject lose_panel;


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Moon") || other.gameObject.CompareTag("Other"))
        {
            // When collide with moon or planet or satellite, health decreses
            health -=1;
            if (health>0)
            {
                for (int i = 0; i<hearts.Length; i++)
                {
                    if (i>= health)
                    {
                        hearts[i].enabled = false;
                    }
                }
            }

            // Health <= 0: player loses
            else
            {
                hearts[0].enabled = false;
                lose_panel.SetActive(true);
            }
            
        } 
    }


    
}
