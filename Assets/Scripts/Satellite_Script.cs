using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satellite_Script : MonoBehaviour
{
    public GameObject center;
    public float speed;


    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(center.transform.position, Vector3.up, speed * Time.deltaTime);
    }
}
