using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon_Script : MonoBehaviour
{
    public GameObject center;
    public float speed;
    


    // Update is called once per frame
    void Update()
    {
        transform.Rotate (new Vector3 (0, 30, 0) * Time.deltaTime);
        
        transform.RotateAround(center.transform.position, Vector3.up, speed * Time.deltaTime);
    }
}
