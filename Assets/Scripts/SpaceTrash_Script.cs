using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceTrash_Script : MonoBehaviour
{

    public GameObject center;   
    public float speed;
    public bool collected;
    public GameObject spaceship;

    // Start is called before the first frame update
    void Start()
    {
        collected = false;
    }

    // Update is called once per frame
    void Update()
    {
        // If the trash is collected
        
        if (collected)
        {
            
            // Change material color to green
            this.GetComponent<MeshRenderer>().material.color = Color.green;

            // Move toward spaceship
            transform.position = Vector3.MoveTowards(transform.position, spaceship.transform.position, 5f * Time.deltaTime);
            

            // Check if the trash still in camera view
            Vector3 viewPos = Camera.allCameras[0].WorldToViewportPoint(transform.position);
            if (viewPos.x < 0 || viewPos.x > 1 || viewPos.y < 0 || viewPos.y > 1 || viewPos.z < 0)
            {
                //Debug.Log("Item disappear");
                this.gameObject.SetActive(false);
            }
        }

        // If the trash is not collected
        // Rotate around the planet in a constant speed
        if (collected == false)
        {
            transform.RotateAround(center.transform.position, Vector3.up, speed * Time.deltaTime);
        }
        
    }
}
