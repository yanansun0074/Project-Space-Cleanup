using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    public Button restart;
    // Start is called before the first frame update
    void Start()
    {
        restart.onClick.AddListener(Click);
    }

    // Update is called once per frame
    void Click()
    {
    
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
