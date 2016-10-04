using UnityEngine;
using System.Collections;

public class DroneController : MonoBehaviour
{
    //This script deals with the drones directly.  Increases speed as game goes on

    DroneManager droneManager;                  // Refference to the DroneManager
    LoseCondition loseCondition;                // Refference to the LoseCondition

    public Rigidbody rb;                        // Access the Rigidbody component
    public int droneHealth;                     // Drone's health
    public int howMuchDmgCanDroneTake;          // Damage taken

    void Awake()
    {
        droneManager = GameObject.FindGameObjectWithTag("T_DronesManager").GetComponent<DroneManager>();
        loseCondition = GameObject.FindGameObjectWithTag("T_Base").GetComponent<LoseCondition>();
    }

    void FixedUpdate()
    {
        rb.AddForce(transform.right * droneManager.droneSpeed);
        //print("Drone Speed is now : " + droneManager.droneSpeed);
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "T_Bullets")
        {
            droneHealth = droneHealth - howMuchDmgCanDroneTake;
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
            print("asdf");
            loseCondition.GameOver();
            Destroy(gameObject);
        }
    }
}