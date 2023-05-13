using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;


public class Spacecraft_Script : MonoBehaviour
{
    public float speed;
    private float velocity = 1;

    public Button speed_button;
    private bool boosting;
    private float boostTimer;

    private float movementX;
    private float movementY;

    public float pitchSpeed;
    public float yawSpeed;
    public float rollSpeed;

    private float pitch;
    private float yaw;
    private float roll;

    public Camera cam_front;
    public Camera cam_back;

    public Joystick joystick;
    
    public TMP_Text Value;
    private float trash;
    private float trash_val;

    public GameObject trash_prefab;

    private bool outofbound;
    private bool far;
    public GameObject TooFar;
    public GameObject planet;
    public GameObject Return;

    public GameObject light;
    private Light point_light;

    private float nextActionTime = 0.0f;
    public float period = 3.0f;


    // Start is called before the first frame update
    void Start()
    {
        
        // Set front camera as default
        cam_front.enabled = true;
        cam_back.enabled = false;


        speed_button.onClick.AddListener(Speed_Up);
        boosting = false;
        boostTimer = 0;
        
        // Initialize trash value and number
        trash = 0;
        trash_val = 0;

        outofbound = false;
        far = false;

        point_light = light.GetComponent<Light>();

        
    }
    
    void Update()
    {
        // Get the input of joystick
        pitch = joystick.Vertical;
        yaw = joystick.Horizontal;

        transform.position += transform.forward * Time.deltaTime * speed;
        transform.Rotate(-pitch * pitchSpeed * Time.deltaTime, 
                        yaw * yawSpeed * Time.deltaTime,
                        0);
        

        // When "Speed up" button is pressed
        if (boosting)
        {
            boostTimer+= Time.deltaTime;
            if (boostTimer >= 4)    // Speed up for 4 sec
            {
                boosting = false;
                boostTimer = 0;
                speed -= velocity;  // Back to original speed
            }
        }

        // When the screen is touched
        if (Input.touchCount> 0)
        {
            foreach (Touch touch in Input.touches)
            {

                if (cam_back.enabled)   // Only enable touch-collecting when back camera is active
                {
                    Ray ray = cam_back.ScreenPointToRay(touch.position);    // Convert ray to camera view pos
            
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit))
                    {
                        // If moon trash is hit
                        if (hit.transform.gameObject.CompareTag("Moon Trash"))
                        {
                            hit.transform.gameObject.GetComponent<MoonTrash_Script>().collected = true;
                            
                            IncreaseValue();    // Increase by 20
                        }

                        // If planet trash is hit
                        if (hit.transform.gameObject.CompareTag("Planet Trash"))
                        {
                            hit.transform.gameObject.GetComponent<SpaceTrash_Script>().collected = true;

                            IncreaseValue2();   // Increase by 30
                        }                   
                    }
                }            
            }
        }


        if (Time.time > nextActionTime )    // Execute every period of time
        {
            nextActionTime += period;
            if (far)    // Too far: scores start decreasing
            {
                trash_val -= 1;
                Value.text = trash_val.ToString();

                if(outofbound)      // Out of bound: start auto-return
                {
                    Return.SetActive(true);
                }
            }
        }
    
    }


    // Boosting
    void Speed_Up()
    {
        boosting = true;
        speed += velocity;
        
    }

    // Detect trigger
    void OnTriggerEnter(Collider other)
    {
        // If collide with Moon trash
        if (other.gameObject.CompareTag("Moon Trash")) 
        {

            other.gameObject.GetComponent<MoonTrash_Script>().collected = true;
            IncreaseValue();    // Increase total value by 20

        }
        // If collide with Planet trash
        if (other.gameObject.CompareTag("Planet Trash")) 
        {
            other.gameObject.GetComponent<SpaceTrash_Script>().collected = true;
            IncreaseValue2();   // Increase total value by 30

        }

        // Come back to inbound
        if (other.gameObject.CompareTag("InBound"))
        {
            Return.SetActive(false);    //Turn warning off
            TooFar.SetActive(false);
            outofbound = false;
            far = false;

        }

        // Come back to outbound
        if (other.gameObject.CompareTag("OutBound"))
        {   
            TooFar.SetActive(false);    //Turn warning off
            outofbound = false;
            //far = true;
        }


    }


    void OnCollisionEnter (Collision collision)
    {
        // If collide with moon
        if (collision.gameObject.CompareTag("Moon"))
        {
            // Create new moon trash around the collision
            Vector3 old_pos = collision.gameObject.transform.position;
            Vector3 new_pos = new Vector3(old_pos.x+Random.Range(-1f,1f), old_pos.y+Random.Range(-0.5f,0.5f), old_pos.z + Random.Range(-0.5f,0.5f));
            GameObject new_trash = Instantiate(trash_prefab, new_pos, Quaternion.identity, collision.gameObject.transform);
            MoonTrash_Script moon_trash = new_trash.GetComponent<MoonTrash_Script>();

            moon_trash.center = collision.gameObject.transform;     // Set new trash's center of rotation
            
            point_light.damaged = true;     // Trigger spaceship's red light effect
            
            DecreaseValue();    //Decrease value by 10
        }

        // If collide with others (Planet, Satellites)
        // Similar action but no trash is created
        if (collision.gameObject.CompareTag("Other"))
        {
            point_light.damaged = true;

            DecreaseValue();
        }

    }



    void OnTriggerStay(Collider other)
    {
        // Stay in bound
        if (other.gameObject.CompareTag("InBound"))
        {
            outofbound = false;
            far = false;

        }
        else
        {
            // Stay in bound but leaving
            if (other.gameObject.CompareTag("OutBound"))
            {
                outofbound = false;
                //far = true;
            }
        }
        
    }

    void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("OutBound"))
        {
            outofbound = true;
            far = true;
            relocate();     //Auto return
  
        }
        // Exceed InBound
        if (other.gameObject.CompareTag("InBound"))
        {
            TooFar.SetActive(true);     // Turn warning on
            outofbound = false;
            far = true;
        }
    }


    void relocate()
    {
        transform.Rotate(Vector3.up, 180);      //Auto return: Ship turns 180 degrees around
    }


    void IncreaseValue()
    {
        trash +=1;
        trash_val +=20;
        Value.text = trash_val.ToString();
    }

    void IncreaseValue2()
    {
        trash +=1;
        trash_val +=30;
        Value.text = trash_val.ToString();
    }

    void DecreaseValue()
    {
        trash_val -= 10;
        Value.text = trash_val.ToString();
    }


    void OutOfBound()
    {
        if (far)
        {
            trash_val -= 1;
            Value.text = trash_val.ToString();
        }
        
        
    }


}
