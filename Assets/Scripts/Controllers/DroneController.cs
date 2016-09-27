using UnityEngine;
using System.Collections;

public class DroneController : MonoBehaviour
{
    //This script deals with the drones directly

    public Rigidbody rb;                    // Access the Rigidbody component
    public float droneSpeed;                // Speed of drone
    public int droneHealth;                 // Drone's health
    public int howMuchDmgCanDroneTake;      // Damage taken

    void FixedUpdate()
    {
        rb.AddForce(transform.right * droneSpeed);
        print(droneHealth);
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
                    return;
                }
            }
        }
    }
}