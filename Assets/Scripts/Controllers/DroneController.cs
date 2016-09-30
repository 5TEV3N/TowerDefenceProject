using UnityEngine;
using System.Collections;

public class DroneController : MonoBehaviour
{
    //This script deals with the drones directly.  Increases speed as game goes on

    DroneManager droneManager;              // Refference to the DroneManager
    public Rigidbody rb;                    // Access the Rigidbody component
    public float droneSpeed;                // Speed of drone
    public float droneSpeedUp;              // Speeds up the drone after certain criterias are met
    public int droneHealth;                 // Drone's health
    public int howMuchDmgCanDroneTake;      // Damage taken

    void FixedUpdate()
    {
        rb.AddForce(transform.right * droneSpeed);
    }

    void Awake()
    {
        droneManager = GameObject.FindGameObjectWithTag("T_DronesManager").GetComponent<DroneManager>();
    }

    public void OnCollisionEnter(Collision bullet)
    {
        if (bullet.gameObject.tag == "T_Bullets")
        {
            droneHealth = droneHealth - howMuchDmgCanDroneTake;
            if (droneHealth == 0)
            {
                if (bullet.gameObject.tag == "T_Bullets")
                {
                    Destroy(gameObject);
                    droneManager.KillCounter();
                    return;
                }
            }
        }
    }

    public void SpeedUp()
    {

    }
}