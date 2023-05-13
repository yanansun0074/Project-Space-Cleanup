using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CameraScript : MonoBehaviour
{
    public Button button1; 
    public Button button2;
    public Camera cam1;
    public Camera cam2;

    // Start is called before the first frame update
    void Start()
    {

        button1.onClick.AddListener(Button1Click);
        button2.onClick.AddListener(Button2Click);
        button1.gameObject.SetActive(true);
        button2.gameObject.SetActive(false);

    }

    

    void Button1Click()
    {
        cam1.enabled = false;
        cam2.enabled = true;
        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(true);
    }
    void Button2Click()
    {
        cam2.enabled = false;
        cam1.enabled = true;
        button2.gameObject.SetActive(false);
        button1.gameObject.SetActive(true);
    }
}
