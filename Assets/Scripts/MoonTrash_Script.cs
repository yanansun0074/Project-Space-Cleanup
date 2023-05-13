using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonTrash_Script : MonoBehaviour
{
    //public Transform center;
    public Transform center;
    private float OrbitSpeed = 10f;
    private float Radius;
    public bool collected;
    public GameObject spaceship;

    // Start is called before the first frame update
    void Start()
    {
        Radius = Vector3.Distance(center.position, transform.position);
        collected = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Not hit/collided, rotate around its moon
        if (collected == false)
        {
            

        //fix possible changes in distance
            float currentMoonDistance = Vector3.Distance(center.position, transform.position);
            Vector3 towardsTarget = transform.position - center.position;
            transform.position += (Radius - currentMoonDistance) * towardsTarget.normalized;

            transform.RotateAround(center.position, Vector3.up, OrbitSpeed * Time.deltaTime);
        }

        // Hit/collided, move toward spaceship
        if (collected)
        {
            Debug.Log("Moon trash is collected");
            // Change material color to green
            this.GetComponent<MeshRenderer>().material.color = Color.green;
            transform.position = Vector3.MoveTowards(transform.position, spaceship.transform.position, 10f * Time.deltaTime);
            
            // Check if the trash still in camera view
            Vector3 viewPos = Camera.allCameras[0].WorldToViewportPoint(transform.position);
            Debug.Log(Camera.allCameras[0]);
            if (viewPos.x < 0 || viewPos.x > 1 || viewPos.y < 0 || viewPos.y > 1 || viewPos.z < 0)
            {
                Debug.Log("Item disappear");
                this.gameObject.SetActive(false);
            }
        }
        
    }
}
