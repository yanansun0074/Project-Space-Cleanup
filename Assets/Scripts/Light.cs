using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Light : MonoBehaviour
{

    public float speed = 0.5f;
    public float RotAngleY = 90;
    public bool damaged;
    public UnityEngine.Light myLight;
    private float timeElapsed;
    public float length;
    public float minIntensity;
    public float maxIntensity;
    public Color damaged_color;
    public Color normal_color;
    // Start is called before the first frame update
    void Start()
    {
        damaged = false;
        myLight.intensity = 3;
    }


    // Update is called once per frame
    void Update()
    {

        float rY = Mathf.SmoothStep(0,RotAngleY,Mathf.PingPong(Time.time * speed,1));
        transform.rotation = Quaternion.Euler(0,rY,0);

        if (damaged)
        {
            Debug.Log("Light changed");
            ToggleLight();
            timeElapsed += Time.deltaTime;
            
 
            // if the amount of time passed is greater than or equal to the delay
            if(timeElapsed >= length)
            {
                // reset the time elapsed
                timeElapsed = 0;
                damaged = false;
                ToggleLight();
                // toggle the light
                
            }
        }

    }

    public void ToggleLight()
    {
        // if the variable is not empty
        if (damaged == false)
        {
            myLight.color = normal_color;
            myLight.intensity = minIntensity;
        }
        if(damaged)
        {
            myLight.color = damaged_color;
            // if the intensity is currently the minimum, switch to max
            if(myLight.intensity == minIntensity)
            {
                myLight.intensity = maxIntensity;
            }
            // if the intensity is currently the max, switch to min
            else if(myLight.intensity == maxIntensity)
            {
                myLight.intensity = minIntensity;
            }
        }
        
    }
}
