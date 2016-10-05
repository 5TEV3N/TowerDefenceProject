using UnityEngine;
using System.Collections;

public class DroneController : MonoBehaviour
{
    //This script deals with the drones directly.  Increases speed as game goes on

    DroneManager droneManager;                  // Refference to the DroneManager
    LoseCondition loseCondition;                // Refference to the LoseCondition

    public Rigidbody rb;                        // Access the Rigidbody component
    public int droneHealth;                     // Drone's health

    void Awake()
    {
        loseCondition = GameObject.FindGameObjectWithTag("T_Base").GetComponent<LoseCondition>();
        droneManager = GameObject.FindGameObjectWithTag("T_DronesManager").GetComponent<DroneManager>();
    }

    void FixedUpdate()
    {
        rb.AddForce(transform.right * droneManager.droneSpeed);
        
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "T_Bullets")
        {
            droneHealth--;

            if (droneHealth == 0)
            {
                if (other.gameObject.tag == "T_Bullets")
                {
                    Destroy(gameObject);
                    droneManager.KillCounter();
                    return;
                }
            }
        }
        if (other.gameObject.tag == "T_Base")
        {
            loseCondition.GameOver();
            Destroy(gameObject);
        }
    }
}